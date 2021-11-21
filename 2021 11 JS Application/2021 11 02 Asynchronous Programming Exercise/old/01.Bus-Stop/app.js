function getInfo() {
    const stopIdElement = document.getElementById('stopId');
    const ulElement = document.getElementById('buses');
    let stopNameElement = document.getElementById('stopName');

    fetch(`http://localhost:3030/jsonstore/bus/businfo/${stopIdElement.value}`)
    .then(res=>res.json())
    .then(data=>{
        stopIdElement.value = '';
        ulElement.innerHTML = '';

        
        stopNameElement.textContent = data.name;
        
        let buses = Object.keys(data.buses);
        let liHTMLElement = buses.map(x=>`<li>Bus ${x} arrives in ${data.buses[x]}</li>`).join(' ');
        ulElement.innerHTML = liHTMLElement;
    })
    .catch(err=>{
        ulElement.innerHTML = '';
        stopNameElement.textContent = 'Error';
    })
}