function encodeAndDecodeMessages() {
    Array.from(document.getElementsByTagName('button')).forEach(b => b.addEventListener('click', onClick));
    
    const senderTextArea = document.querySelector('textarea[placeholder ="Write your message here..."');
    const receiverTextArea = document.querySelector('textarea[placeholder ="No messages..."');

    function onClick(event) {
        const button = event.target;
        if (button.textContent == 'Encode and send it') {
            for (let i = 0; i < senderTextArea.value.length; i++) {
                receiverTextArea.textContent += String.fromCharCode(senderTextArea.value.charCodeAt(i) + 1);
            }
            senderTextArea.value = '';

        } else if (button.textContent == 'Decode and read it') {
            let decodeMessage = '';
            for (let i = 0; i < receiverTextArea.textContent.length; i++) {
                decodeMessage += String.fromCharCode(receiverTextArea.textContent.charCodeAt(i) - 1);
            }
            receiverTextArea.textContent = decodeMessage;
        }
    }
}

//The password for my bank account is 123pass321


function encodeAndDecodeMessages() {
    Array.from(document.getElementsByTagName('button')).forEach(b => b.addEventListener('click', onClick));
    
    const senderTextArea = document.querySelector('textarea[placeholder ="Write your message here..."');
    const receiverTextArea = document.querySelector('textarea[placeholder ="No messages..."');

    function onClick(event) {
        const button = event.target;
        if (button.textContent == 'Encode and send it') {
            let encodedMessage = '';
            let message = senderTextArea.value;
            for (let i = 0; i < message.length; i++) {
                encodedMessage += String.fromCharCode(message.charCodeAt(i) + 1);
            }
            senderTextArea.value = '';
            receiverTextArea.textContent = encodedMessage;

        } else if (button.textContent == 'Decode and read it') {
            let decodedMessage = '';
            let message = receiverTextArea.value;
            for (let i = 0; i < message.length; i++) {
                decodedMessage += String.fromCharCode(message.charCodeAt(i) - 1);
            }
            receiverTextArea.textContent = decodedMessage;
        }
    }
}