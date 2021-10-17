function solve() {
    let movieName = document.querySelector('input[placeholder="Name"]');
    let hallName = document.querySelector('input[placeholder="Hall"]');
    let ticketPrice = document.querySelector('input[placeholder="Ticket Price"]');

    const onScreenButton = document.querySelectorAll('button')[0];
    const clearButton = document.querySelectorAll('button')[1];

    let movieUlElement = document.querySelector('#movies > ul');
    let archiveUlElement = document.querySelector('#archive > ul');

    onScreenButton.addEventListener('click', addMovie);
    clearButton.addEventListener('click', clearArchive);

    function addMovie(event) {
        event.preventDefault();

        if (movieName.value != '' &&
            hallName.value != '' &&
            !isNaN(ticketPrice.value) && 
            ticketPrice.value != '') {

            // DOM of Movies on Screen
            let liEl = document.createElement('li');

            let spanEl = document.createElement('span');
            spanEl.textContent = movieName.value;
            liEl.appendChild(spanEl);

            let strongEl = document.createElement('strong');
            strongEl.textContent = `Hall: ${hallName.value}`;
            liEl.appendChild(strongEl);

            let divEl = document.createElement('div');

            let strongElPrice = document.createElement('strong');
            strongElPrice.textContent = Number(ticketPrice.value).toFixed(2);
            divEl.appendChild(strongElPrice);

            let inputEl = document.createElement('input');
            inputEl.placeholder = 'Tickets Sold';
            divEl.appendChild(inputEl);

            let buttonEl = document.createElement('button');
            buttonEl.textContent = 'Archive';
            divEl.appendChild(buttonEl);
            buttonEl.addEventListener('click', archiveMovie)

            liEl.appendChild(divEl);
            movieUlElement.appendChild(liEl);

            //Clear the input
            movieName.value = '';
            hallName.value = '';
            ticketPrice.value = '';
        }
    }

    function archiveMovie(event) {
        const movieLiEl = event.target.parentElement.parentElement;
        const ticketsCount = movieLiEl.querySelector('input[placeholder = "Tickets Sold"]');
        

        if (!isNaN(ticketsCount.value) && ticketsCount.value != '') {
            let archivedMovieName = movieLiEl.querySelector('span');
            let archivedMoviePrice = movieLiEl.querySelector('div strong');

            let liArchiveEl = document.createElement('li')

            let spanArchiveEl = document.createElement('span');
            spanArchiveEl.textContent = archivedMovieName.textContent;

            liArchiveEl.appendChild(spanArchiveEl);

            let strongArchiveEl = document.createElement('strong');
            strongArchiveEl.textContent = `Total amount: ${(ticketsCount.value * Number(archivedMoviePrice.textContent)).toFixed(2)}`;
            liArchiveEl.appendChild(strongArchiveEl);

            let buttonArchiveEl = document.createElement('button');
            buttonArchiveEl.textContent = 'Delete';
            liArchiveEl.appendChild(buttonArchiveEl);
            buttonArchiveEl.addEventListener('click', deleteArchiveMovie)

            archiveUlElement.appendChild(liArchiveEl);
            movieLiEl.remove();
        }
    }

    function deleteArchiveMovie(ev) {
        let archivedRow = ev.target.parentElement;

        archivedRow.remove();
    }

    function clearArchive(e) {
        let archiveLiElements = Array.from(e.target.parentElement.querySelectorAll('ul li'));
        archiveLiElements.forEach(el => el.remove());
    }
}