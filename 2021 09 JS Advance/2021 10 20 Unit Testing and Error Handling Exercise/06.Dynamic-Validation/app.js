function validate() {
    let email = document.getElementById('email');
    console.log(email.value)

    email.addEventListener('change', attachError);

    function attachError(event) {
        const emailPattern = /^([a-z]+@[a-z]+\.[a-z]+)$/g;
        let isValidEmail = emailPattern.test(email.value);

        if (!isValidEmail) {
            event.target.classList.add('error');
        } else {
            event.target.classList.remove('error');
        }
    }
}