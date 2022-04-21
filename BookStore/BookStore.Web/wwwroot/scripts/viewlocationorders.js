var locationList;
var orderList;
var customers;

function loadLocationData() {
    return fetch('/api/locations')
        .then(resp => {
            if (!resp.ok) {
                throw new Error(`failed to get locations (${resp.status})`);
            }
            return resp.json();
        });
}

loadLocationData().then(locations => {
    locationList = locations;
    let locationSelect = document.getElementById("view-location");
    for (const l of locations) {
        let o = document.createElement("option");
        o.text = `${l.name}`;
        o.value = l.id
        locationSelect.appendChild(o);
    }
});

function loadCustomerData() {
    return fetch('/api/customers')
        .then(resp => {
            if (!resp.ok) {
                throw new Error(`failed to get customers (${resp.status})`);
            }
            return resp.json();
        });
}

loadCustomerData().then(c => { customers = c });

function getCustomerNameByID(id) {
    for(let i = 0; i < customers.length; i++) {
        if (customers[i].id === id) {
            return `${customers[i].firstName} ${customers[i].lastName}`;
        }
    }
}

function selectedLocation(event) {
    fetch(`/api/locations/${event.target.value}/orders`)
        .then(resp => {
            if (!resp.ok) {
                throw new Error(`failed to get orders by location (${resp.status})`);
            }
            return resp.json();
        })
        .then(orders => {
            orderList = orders;
            let table = document.getElementById("order-list-table");
            
            clearOrderListTable();
            clearOrderDetailTable();

            orderList.forEach(o => {
                const row = table.insertRow();
                row.innerHTML = `
                <td class="center-table-data">${o.id}</td>
                <td class="center-table-data">${getCustomerNameByID(o.customerID)}</td>
                <td class="center-table-data">${o.total.toFixed(2)}</td>
                <td class="center-table-data">${new Date(o.time).toLocaleString()}</td>`
                row.addEventListener("click", () => {showOrderDetails(o)});
            });
            document.getElementById("order-info").hidden = false;
        })
}

showOrderDetails = (order) => {
    let table = document.getElementById("order-detail-table");

    clearOrderDetailTable();

    order.items.forEach(item => {
        const row = table.insertRow();
        row.innerHTML = `
        <td>${order.id}</td>
        <td>${item.name}</td>
        <td class="center-table-data">${item.price.toFixed(2)}</td>
        <td class="center-table-data">${item.amount}</td>`
    });
}

function clearOrderListTable() {
    let table = document.getElementById("order-list-table");
    let tableHeaderRowCount = 1;
    let rowCount = table.rows.length;
    for(let i = tableHeaderRowCount; i < rowCount; i++) {
        table.deleteRow(tableHeaderRowCount);
    }
}

function clearOrderDetailTable() {
    let table = document.getElementById("order-detail-table");
    let tableHeaderRowCount = 1;
    let rowCount = table.rows.length;
    for(let i = tableHeaderRowCount; i < rowCount; i++) {
        table.deleteRow(tableHeaderRowCount);
    }
}