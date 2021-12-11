window.addEventListener('load', solve);

function solve() {
    let genreEl = document.getElementById('genre');
    let nameEl = document.getElementById('name');
    let authorEl = document.getElementById('author');
    let dateEl = document.getElementById('date');

    let addBtn = document.getElementById('add-btn');
    addBtn.addEventListener('click', addSonds);

    let songCollection = document.querySelectorAll('.all-hits-container')[0];
    let songSavedCollection = document.querySelectorAll('.saved-container')[0];

    function addSonds(event) {
        event.preventDefault();

        if (genreEl.value == '' ||
            nameEl.value == '' ||
            authorEl.value == '' ||
            dateEl.value == '') {
            return;
        }

        let divElCollection = document.createElement('div');
        divElCollection.classList.add("hits-info");
        divElCollection.innerHTML = '<img src="./static/img/img.png"><h2>Genre: ' + genreEl.value + '</h2><h2>Name: ' + nameEl.value + '</h2><h2>Author: ' + authorEl.value + '</h2><h3>Date: ' + dateEl.value + '</h3><button class="save-btn">Save song</button><button class="like-btn">Like song</button><button class="delete-btn">Delete</button>';

        songCollection.appendChild(divElCollection);

        let saveBtn = divElCollection.querySelector('.save-btn');
        let likeBtn = divElCollection.querySelector('.like-btn');
        let deleteBtn = divElCollection.querySelector('.delete-btn');

        genreEl.value = '';
        nameEl.value = '';
        authorEl.value = '';
        dateEl.value = '';
        addBtn.value = '';

        likeBtn.addEventListener('click', likeSong);
        // likeBtn.addEventListener('click', () => {
        //     totalLikes += 1;
        //     likeBtn.disabled = true;
        //     let likesCounter = document.querySelector('#total-likes p');
        //     likesCounter.textContent = `Total Likes: ${totalLikes}`;
        // });



        saveBtn.addEventListener('click', saveSong);
        // saveBtn.addEventListener('click', () => {
        //     const divSavedHit = document.querySelector('.saved-container');
        //     divSavedHit.appendChild(div);
        //     saveBtn.remove();
        //     likeBtn.remove();
        // });

        deleteBtn.addEventListener('click', deleteSong);
        // deleteBtn.addEventListener('click', () => {
        //     div.remove();
        // });
    }

    function likeSong(event) {
        let likeSongCount = Number(document.querySelectorAll('p')[1].textContent.split(': ')[1]);
        likeSongCount++;
        document.querySelectorAll('p')[1].textContent = `Total Likes: ${likeSongCount}`;

        event.currentTarget.disabled = true;
    }

    function saveSong(ev) {
        let savedList = ev.target.parentElement;

        let saveBtn = savedList.querySelectorAll('button')[0];
        let likeBtn = savedList.querySelectorAll('button')[1];
        savedList.removeChild(saveBtn)
        savedList.removeChild(likeBtn)

        songSavedCollection.appendChild(savedList);
    }

    function deleteSong(event) {
        let divElCollection = event.target.parentElement;
        divElCollection.remove();
    }
}