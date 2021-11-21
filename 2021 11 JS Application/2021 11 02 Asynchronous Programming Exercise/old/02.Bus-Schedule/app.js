function solve() {
    infoElement = document.getElementById('info');
    departBtn = document.getElementById('depart');
    arriveBtn = document.getElementById('arrive');
    let next = 'depot';
    let url = `http://localhost:3030/jsonstore/bus/schedule/`

    function depart() {
        fetch(`${url}${next}`)
        .then(res=>res.json())
        .then(data=>{
            infoElement.textContent = `Next stop ${data.name}`
            departBtn.disabled = true;
            arriveBtn.disabled = false;
        })
    }

    function arrive() {
        fetch(`${url}${next}`)
        .then(res=>res.json())
        .then(data=>{
            infoElement.textContent = `Arriving at ${data.name}` 
            departBtn.disabled = false;
            arriveBtn.disabled = true;
            next = data.next;
        })      
    }

    return {
        depart,
        arrive
    };
}

let result = solve();