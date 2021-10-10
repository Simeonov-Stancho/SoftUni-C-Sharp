function lockedProfile() {
    Array.from(document.querySelectorAll('.profile button')).forEach(button =>
        button.addEventListener('click', onClick));

    function onClick(event) {
        const isUnlocked = event.target.parentNode.children[4].checked;
        if (event.target.textContent == 'Show more' && isUnlocked) {
            event.target.previousElementSibling.style.display = 'block'; //event.target.parentElement.querySelectorAll('div')
            event.target.textContent = 'Hide it';
        } else if (event.target.textContent == 'Hide it' && isUnlocked) {
            event.target.previousElementSibling.style.display = 'none';
            event.target.textContent = 'Show more';
        }
    }
}