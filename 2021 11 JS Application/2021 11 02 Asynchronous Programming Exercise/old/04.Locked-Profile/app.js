function lockedProfile() {
    
    

    let mainElement = document.getElementById('main');
    fetch(`http://localhost:3030/jsonstore/advanced/profiles`)
    .then(res=>res.json())
    .then(userData=>{
        console.log(userData)

        Object.entries(userData).forEach(([element,value]) => {
            let username = value.username;
            let email = value.email;
            let age = value.age;
            let divElement = document.createElement('div');
            divElement.classList.add("profile");
            divElement.innerHTML = generateUser(username,email,age)
            mainElement.appendChild(divElement);


        });



    });

    mainElement.addEventListener('click',function(e){
        if(e.target.textContent === 'Show more'||e.target.textContent === 'Hide it'){
            let lock = e.target.parentElement.querySelector('input[value="lock"]');

            let hiddenDiv = e.target.previousElementSibling;

            if(hiddenDiv.style.display === '' && lock.checked === false){
                hiddenDiv.style.display = 'block';
                e.target.textContent = 'Hide it';

            }else if(hiddenDiv.style.display === 'block' && lock.checked === false){
                hiddenDiv.style.display = '';
                e.target.textContent = 'Show more';
            }
        }

    })

    
        











    function generateUser(username,email,age){
        let template = 
        `
            <img src="./iconProfile2.png" class="userIcon" />
            <label>Lock</label>
            <input type="radio" name="user1Locked" value="lock" checked>
            <label>Unlock</label>
            <input type="radio" name="user1Locked" value="unlock"><br>
            <hr>
            <label>Username</label>
            <input type="text" name="user1Username" value="${username}" disabled readonly />
            <div id="user1HiddenFields">
                <hr>
                <label>Email:</label>
                <input type="email" name="user1Email" value="${email}" disabled readonly />
                <label>Age:</label>
                <input type="email" name="user1Age" value="${age}" disabled readonly />
            </div>
            <button>Show more</button>
        `;
        return template;
    }
}