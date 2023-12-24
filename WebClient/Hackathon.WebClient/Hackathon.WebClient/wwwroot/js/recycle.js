const dropdown_content = document.getElementById('dropdown-content');
const electionsContainer = document.getElementById('elections');
const dropdownButton = document.getElementById('dropdownMenuButton');
const btnAdd = document.getElementById('btn_add');
const btnDone = document.getElementById('btn_done');

let materialTypes = [];
let materials = [];
const state = {
    selectedItem: null,
    elections: [],
    addForElections() {
        const found = this.elections.find(item => item.id === this.selectedItem.id);
        if (found) return;
        const election = { ...this.selectedItem, count: 1 }
        this.elections.push(election)
        drawElection(election);
    },
    setSelectedItem(item) {
        if (!item) return;
        this.selectedItem = item;
        dropdownButton.innerHTML = `<img class="dropdown-item-image" src="${this.selectedItem.imagePath}" alt=""> ${this.selectedItem.name}`
    }
}


btnAdd.addEventListener('click', function () {
    if (!state.selectedItem) {
        alert("Lütfen bir materyal seçiniz")
        return;
    }
    state.addForElections();
})

btnDone.addEventListener('click', async function () {
    const elections = [...document.querySelectorAll("input[data-id]")].map(input => ({ id: input.dataset.id, count: +input.value }))
    for (const item of elections) {
        const found = state.elections.find(election => election.id == item.id);
        if (!found) continue;
        found.count = item.count;
    }
    

    state.elections = state.elections.map(x => {
        x.count = Math.abs(x.count);
        x.total = x.value * x.count;
        return x;
    })



    const totalCarbon = state.elections.reduce((total, current) => {
        return total + current.total;
    }, 0)

    console.log(state.elections);


    const requestData = JSON.stringify({
        materials: state.elections
    });
    console.log(requestData)
    const response = await fetch("http://localhost:5244/Home/Recycle", {
        method: "POST",
        headers: {
            'Content-Type': 'application/json'
        },
        body: requestData
    }).then(res => {
        return res.json()
    }).catch(err => {
        console.log(err)
        return err;
    });
    console.log(response)
    alert(`Total Corbon: ${totalCarbon}`)

    window.location="/Home/Transactions"
})


function drawElection(election) {
    const template =
        `<li class="list-group-item d-flex justify-content-between ">
    <div>
        <img class="card-image" src="${election.imagePath}" alt="${election.name}"> ${election.name}
    </div>
    <div class="w-auto">
        <input data-id="${election.id}" class="form-control" placeholder="Enter the value" type="number" min="1" value="${election.count}">
    </div>
    </li>`;
    electionsContainer.innerHTML += template;

    document.querySelector(`input[data-id='${election.id}'`).addEventListener('change', function (e) {
        e.target.setAttribute('value', e.target.value)
    });
}

function drawMeteralType(materialType) {
    let items = "";
    materialType.materials.forEach(material => {
        items += `<li>
        <a class="dropdown-item material-type" data-value="${material.id}" href="#">
            <span data-value="${material.id}"><img class="dropdown-item-image" src="${material.imagePath}" alt=""> ${material.name}</span> <b data-value="${material.id}">${material.value}</b>
        </a>
    </li>`
    })

    const materialTypeItem = `<li>
    <a class="dropdown-item" href="#">
        <img class="dropdown-item-image" src="${materialType.imagePath}" alt=""> ${materialType.name}
        &raquo;
    </a>
    <ul class="dropdown-menu dropdown-submenu">
       ${items}
    </ul>
    </li>`;
    dropdown_content.innerHTML += materialTypeItem;
}

function load(data) {
    dropdown_content.innerHTML = "";
    elections.innerHTML = "";
    materialTypes = data;
    materials = materialTypes.map(x => x.materials).flat();

    materialTypes.forEach(item => drawMeteralType(item))


    const items = dropdown_content.querySelectorAll('a[data-value]')
    items.forEach(item => {
        item.addEventListener('click', function (e) {
            e.preventDefault()
            const value = e.target.dataset.value;
            const material = materials.find(x => x.id == value)
            state.setSelectedItem(material);
        })
    })
}


fetch("http://localhost:5244/api/materialtypes")
    .then(res => res.json())
    .then(data => load(data))