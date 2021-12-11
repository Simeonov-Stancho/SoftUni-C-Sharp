window.addEventListener('load', solve);

function solve() {
    const productType = document.getElementById('type-product');
    const description = document.getElementById('description');
    const clientName = document.getElementById('client-name');
    const clientPhone = document.getElementById('client-phone');

    const sendBtn = document.querySelectorAll('button')[0];
    sendBtn.addEventListener('click', sendInformation);

    let receivedOrders = document.getElementById('received-orders');
    let completedOrders = document.getElementById('completed-orders');

    function sendInformation(event) {
        event.preventDefault();

        if (description.value == '' || clientName.value == '' || clientPhone.value == '') {
            return;
        }

        let divEl = document.createElement('div');
        divEl.classList.add('container');
        divEl.innerHTML = `<h2>Product type for repair: ${productType.value}</h2><h3>Client information: ${clientName.value}, ${clientPhone.value}</h3><h4>Description of the problem: ${description.value}</h4><button class="start-btn">Start repair</button><button class="finish-btn" disabled>Finish repair</button>`;

        receivedOrders.appendChild(divEl);

        let startBtn = divEl.querySelectorAll('button')[0];
        let finishBtn = divEl.querySelectorAll('button')[1];

        startBtn.addEventListener('click', () => {
            startBtn.disabled = true;
            finishBtn.disabled = false;
        });

        finishBtn.addEventListener('click', () => {
            divEl.removeChild(startBtn);
            divEl.removeChild(finishBtn);
            completedOrders.appendChild(divEl);

            let clearBtn = divEl.parentElement.querySelector('button');
            clearBtn.addEventListener('click', () => {
                divEl.remove();
            })
        })

        productType.value = '';
        description.value = '';
        clientName.value = '';
        clientPhone.value = '';
    }
}