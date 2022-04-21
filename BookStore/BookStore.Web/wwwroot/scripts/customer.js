var locations;
function loadLocationData() {
    return fetch('/api/locations')
        .then(resp => {
            if (!resp.ok) {
                throw new Error(`failed to get locations (${resp.status})`);
            }
            return resp.json();
        });
}

loadLocationData()
    .then(locs => {
        locations = locs;
        let locIDSelect = document.getElementById("defaultLocId");
        for (const l of locations) {
            let o = document.createElement("option");
            o.text = `${l.id} - ${l.name}`;
            o.value = `${l.id}`;
            locIDSelect.appendChild(o);
        }
    });

const table = document.getElementById("customer-list-table");
const tableCard = document.getElementById("table-card");

function loadCustomerData() {
    return fetch('/api/customers')
        .then(resp => {
            if (!resp.ok) {
                throw new Error(`failed to get customers (${resp.status})`);
            }
            return resp.json();
        });
}

loadCustomerData()
    .then(customers => {
        for (const c of customers) {
            const r = table.insertRow();
            r.innerHTML = `
            <td>${c.id}</td>
            <td>${c.firstName}</td>
            <td>${c.lastName}</td>
            <td>${c.defaultLocationID}</td>`;
        }
        table.hidden = false;
        tableCard.hidden = false;
    })
    .catch(e => {
        // handle the error
    });



const submitBtn = document.getElementById("addCustomer");
addCustomer.addEventListener('click', function(event) {
    event.preventDefault();

    let fName = document.getElementById("customer-firstName").value;
    let lName = document.getElementById("customer-lastName").value;
    let locID = document.getElementById("defaultLocId").value;

    if (fName == "" || lName == "") {
        alert("Please enter a first and last name for the customer.");
        return;
    }

    let c = {
        firstName: document.getElementById("customer-firstName").value,
        lastName: document.getElementById("customer-lastName").value,
        defaultLocationId: locID == "" ? 0 : locID  
    }

    fetch('/api/customers', {method: 'POST', headers: {'Content-Type': "application/json"}, body: JSON.stringify(c)})
        .then(resp => {
            if (resp.ok) {
                location.reload();
            }
        });
});
