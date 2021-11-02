function solution() {
    let giftName = document.querySelector('[placeholder="Gift name"]');
    let addBtn = document.querySelector('button');

    addBtn.addEventListener('click', addGift);

    let giftsList = document.querySelector('ul');

    function addGift(event) {
        event.preventDefault();

        let liEl = document.createElement('li');
        liEl.classList.add('gift');

        liEl.innerHTML = `${giftName.value}<button id="sendButton">Send</button><button id="discardButton">Discard</button>`;
        giftsList.appendChild(liEl);

        Array.from(giftsList.children)
            .sort((a, b) => a.textContent.localeCompare(b.textContent.toLowerCase()))
            .forEach(element => giftsList.appendChild(element));

        let sendBtn = liEl.querySelectorAll('button')[0];
        let discardBtn = liEl.querySelectorAll('button')[1];

        sendBtn.addEventListener('click', sendGift);
        discardBtn.addEventListener('click', discardGift);

        giftName.value = '';
    }

    function sendGift(e) {
        let giftSendEl = e.target.parentElement;
        let discBtn = giftSendEl.lastElementChild;
        giftSendEl.removeChild(discBtn);
        let sendBtn = giftSendEl.lastElementChild;
        giftSendEl.removeChild(sendBtn);

        let ulElSendGifts = document.querySelectorAll('ul')[1];
        ulElSendGifts.appendChild(giftSendEl);
    }

    function discardGift(ev) {
        let giftDiscEl = ev.target.parentElement;
        let discBtn = giftDiscEl.lastElementChild;
        giftDiscEl.removeChild(discBtn);
        let sendBtn = giftDiscEl.lastElementChild;
        giftDiscEl.removeChild(sendBtn);

        let ulElDiscardGifts = document.querySelectorAll('ul')[2];
        ulElDiscardGifts.appendChild(giftDiscEl);
    }
}