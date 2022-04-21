var orderCustomer;
var orderLocation;
var order;

function loadLocationData() {
    return fetch('/api/locations')
        .then(resp => {
            if (!resp.ok) {
                throw new Error(`failed to get locations (${resp.status})`);
            }
            return resp.json();
        });
}

function loadCustomerData() {
    return fetch('/api/customers')
        .then(resp => {
            if (!resp.ok) {
                throw new Error(`failed to get customers (${resp.status})`);
            }
            return resp.json();
        });
}


loadLocationData().then(locs => {
    locations = locs;
    let locSelect = document.getElementById("order-location");
    for (const l of locations) {
        let o = document.createElement("option");
        o.text = `${l.id} - ${l.name}`;
        o.value = l.id;
        locSelect.appendChild(o);
    }
});

var customerList;
loadCustomerData().then(customers => {
    customerList = customers;
    let customerSelect = document.getElementById("order-customer");
    for (const c of customers) {
        let o = document.createElement("option");
        o.text = `${c.firstName} ${c.lastName}`;
        o.value = c.id
        customerSelect.appendChild(o);
    }
});

function selectedCustomer(event) {
    let selectedID = parseInt(event.target.value);
    for(let i = 0; i < customerList.length; i++) {
        if (customerList[i].id === selectedID) {
            orderCustomer = customerList[i];
            break;
        }
    }
}

const inventory = document.getElementById("inventory");
const inventoryTable = document.getElementById("product-list-table");
function selectedLocation(event) {
    let selectedID = parseInt(event.target.value);
    for(let i = 0; i < locations.length; i++) {
        let loc = locations[i];
        if (loc.id === selectedID) {
            orderLocation = loc;
            
            let tableHeaderRowCount = 1;
            let rowCount = inventoryTable.rows.length;
            for(let i = tableHeaderRowCount; i < rowCount; i++) {
                inventoryTable.deleteRow(tableHeaderRowCount);
            }

            for(const p of orderLocation.inventory) {
                const row = inventoryTable.insertRow();
                row.innerHTML = `
                <td class="productID">${p.id}</td>
                <td class="productName">${p.name}</td>
                <td class="productPrice">${p.price.toFixed(2)}</td>
                <td class="center-table-data">${p.amount}</td>
                <td class="center-table-data">
                    <input class="productAmount" type="number" placeholder="0">
                </td>`;
            }
            inventory.hidden = false;
            inventoryTable.hidden = false;
        }
    };
}

function submitOrder(event) {
    event.preventDefault();

    items = [{}];
    for (i = 0; i < inventoryTable.rows.length-1; i++) {
        let productID = document.getElementsByClassName("productID")[i].innerHTML;
        let productName = document.getElementsByClassName("productName")[i].innerHTML;
        let productPrice = document.getElementsByClassName("productPrice")[i].innerHTML;
        let productAmount = document.getElementsByClassName("productAmount")[i].value;

        let p = {
            "id": productID,
            "name": productName,
            "price": productPrice,
            "amount": productAmount
        }

        items.push(p);
    }
    removeUnorderedItems(items);
}

function removeUnorderedItems(items) {
    items = items.filter(i => (i.amount > 0) && (i.amount != undefined));
    buildAndSendOrder(items);
}

function buildAndSendOrder(items) {
    let total = 0.0;
    for(let j = 0; j < items.length; j++) {
        i = items[j];
        total += i.price * i.amount;
        updateLocationInventory(i);
    }
    let o = {
        "id": undefined,
        "customerID": orderCustomer.id,
        "locationID": orderLocation.id,
        "time": new Date().toJSON(),
        "items": items,
        "total": total
    }

    fetch("/api/orders", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(o)
    }).then(resp => {
        if(!resp.ok) {
            throw new Error(`failed to submit order (${resp.status})`);
        }

        fetch("/api/locations", {
            method: "PUT",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(orderLocation)
        }).then(resp => {
            if(!resp.ok) {
                throw new Error(`failed to update the location (${resp.status})`);
            }

            alert("Order submitted!");
            window.location.reload();
        })
    });
}

function updateLocationInventory(item) {
    for (let i = 0; i < orderLocation.inventory.length; i++) {
        if (parseInt(item.id) === orderLocation.inventory[i].id) {
            orderLocation.inventory[i].amount -= item.amount;
            break;
        }
    }
}