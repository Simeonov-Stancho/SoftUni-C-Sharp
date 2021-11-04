




function solve() {
    let lectureName = document.querySelectorAll('form input')[0];
    let date = document.querySelectorAll('form input')[1];
    let module = document.querySelector('select');
    let addBtn = document.querySelectorAll('button')[0];

    addBtn.addEventListener('click', addLecture);
    let modules = document.getElementsByClassName('modules')[0];


    function addLecture(event) {
        event.preventDefault();

        if (lectureName.value == '' || date.value == '' || module.value == 'Select module') {
            return
        }

        let divEl = document.createElement('div');
        divEl.classList.add('module');

        let ulEl = document.createElement('ul');

        let liEl = document.createElement('li');
        liEl.classList.add('flex');
        liEl.innerHTML = `<h4>${lectureName.value} - ${(date.value).split('-').join('/').split('T').join(' - ')}</h4><button class="red">Del</button>`

        let moduleArr = Array.from(document.querySelectorAll('.module'));

        let isPersist = moduleArr.find(m => m.firstChild.textContent == `${(module.value).toUpperCase()}-MODULE`)
        if (!isPersist) {
            divEl.innerHTML = `<h3>${(module.value).toUpperCase()}-MODULE</h3>`;
            divEl.appendChild(ulEl);
            ulEl.appendChild(liEl);
            modules.appendChild(divEl);
        } else {
            isPersist.children[1].appendChild(liEl)
            const lis = isPersist.querySelectorAll('li');
            console.log(lis[0].querySelector('h4').textContent.split(' - ').shift())//.join(' - '));
            Array.from(lis)
                .sort((a, b) => a.querySelector('h4').localeCompare(b.querySelector('h4').textContent))
                .forEach(x => lis.parentElement.appendChild(x));


        }




        lectureName.value = '';
        date.value = '';
        module.value = 'Select module...'
    }

};