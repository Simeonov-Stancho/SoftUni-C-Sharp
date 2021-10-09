function focused() {
    let inputFields = document.getElementsByTagName('input');

    for (let i = 0; i < inputFields.length; i++) {
        inputFields[i].addEventListener('focus', onFocus);
        inputFields[i].addEventListener('blur', onBlur);
    }

    function onFocus(event) {
        event.target.parentNode.classList.add('focused');
        //event.target.parentNode.className = 'focused';
    }

    function onBlur(event) {
        event.target.parentNode.classList.remove('focused');
        //event.target.parentNode.className = 'blur';
    }
}

// function focused() {
//     Array.from(document.getElementsByTagName('input')).forEach(element => {
//         element.addEventListener('focus', onFocus);
//         element.addEventListener('blur', onBlur);
//     });

//     function onFocus(event) {
//         event.target.parentNode.className = 'focused';
//     }

//     function onBlur(event) {
//         event.target.parentNode.className = 'blur';
//     }
// }