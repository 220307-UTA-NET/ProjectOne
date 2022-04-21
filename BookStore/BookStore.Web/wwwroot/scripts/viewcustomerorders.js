var customerList;
var orderList;
var locations;

function loadCustomerData() {
    return fetch('/api/customers')
        .then(resp => {
            if (!resp.ok) {
                throw new Error(`failed to get customers (${resp.status})`);
            }
            return resp.json();
        });
}

loadCustomerData().then(customers => {
    customerList = customers;
    let customerSelect = document.getElementById("view-customer");
    for (const c of customers) {
        let o = document.createElement("option");
        o.text = `${c.firstName} ${c.lastName}`;
        o.value = c.id
        customerSelect.appendChild(o);
    }
});

function loadLocationData() {
    return fetch('/api/locations')
        .then(resp => {
            if (!resp.ok) {
                throw new Error(`failed to get locations (${resp.status})`);
            }
            return resp.json();
        });
}

loadLocationData().then(l => { locations = l });

function getLocationByID(id) {
    for(let i = 0; i < locations.length; i++) {
        if (locations[i].id === id) {
            return locations[i];
        }
    }
}

function selectedCustomer(event) {
    fetch(`/api/customers/${event.target.value}/orders`)
        .then(resp => {
            if (!resp.ok) {
                throw new Error(`failed to get orders for customer (${resp.status})`);
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
                <td class="center-table-data">${getLocationByID(o.locationID).name}</td>
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