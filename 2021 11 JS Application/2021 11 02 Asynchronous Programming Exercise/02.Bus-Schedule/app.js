function solve() {
    let info = document.getElementById('info');
    let departBtn = document.getElementById('depart');
    let arriveBtn = document.getElementById('arrive');
    let stops = {
        name: 'Depot',
        next: 'depot',
    };

    async function depart() {
        departBtn.disabled = true;
        arriveBtn.disabled = false;

        try {
            let url = `http://localhost:3030/jsonstore/bus/schedule/${stops.next}`;
            const response = await fetch(url);
            const data = await response.json();
            
            stops = data;
            info.textContent = `Next stop ${stops.name}`;

        } catch (error) {
            disableBtn()
        }
    }

    async function arrive() {
        arriveBtn.disabled = true;
        departBtn.disabled = false;
        try {
            info.textContent = `Arriving at ${stops.name}`;
        } catch (error) {
            disableBtn()
        }
    }

    function disableBtn(){
        arriveBtn.disabled = true;
            departBtn.disabled = true;
    }
    return {
        depart,
        arrive
    };
}

let result = solve();