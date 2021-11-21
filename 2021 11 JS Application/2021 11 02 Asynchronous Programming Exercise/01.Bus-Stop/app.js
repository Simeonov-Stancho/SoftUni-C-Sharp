async function getInfo() {
    let stopId = document.getElementById('stopId');
    const url = `http://localhost:3030/jsonstore/bus/businfo/${stopId.value}`;

    const stopName = document.getElementById('stopName');
    const buses = document.getElementById('buses');
    //my
    // try {
    //     const response = await fetch(url);
    //     
    //     if (response.status == 200) {
    //         const data = await response.json();

    //         stopName.textContent = data.name;
    //         buses.innerHTML = '';
    //         for (const bus in data.buses) {
    //             let liEl = document.createElement('li');
    //             liEl.textContent = `Bus ${bus} arrives in ${data.buses[bus]} minutes`;
    //             buses.appendChild(liEl);
    //         }
    //     } else {
    //         stopName.textContent = "Error"
    //         buses.innerHTML = '';
    //     }
    // } catch (error) {
    //     console.log(error)
    // }

    //Victor
    try {
        buses.innerHTML = '';
        const response = await fetch(url);
        
        if (response.status != 200) {
            throw new Error('Error')
        }

        const data = await response.json();

        stopName.textContent = data.name;

        Object.entries(data.buses).forEach(bus => {
            let liEl = document.createElement('li');
            liEl.textContent = `Bus ${bus[0]} arrives in ${bus[1]} minutes`; //return array an use 0 and 1
            buses.appendChild(liEl);
        });
    } catch (error) {
        stopName.textContent = "Error"
        buses.innerHTML = '';
    }

    stopId.value = '';
}