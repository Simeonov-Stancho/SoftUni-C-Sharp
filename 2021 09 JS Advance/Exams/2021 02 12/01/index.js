function solve() {
    const lectureField = document.querySelectorAll('form input')[0];
    const dateField = document.querySelectorAll('form input')[1];
    const moduleField = document.querySelector('select');
    const addBtn = document.querySelector('form button');

    addBtn.addEventListener('click', addHandler);

    function addHandler(event) {
        event.preventDefault();
        const lecture = lectureField.value;
        let date = dateField.value;
        const module = moduleField.value;

        if (lecture == '' || date == '' || module == 'Select module') {
            return;
        }

        const delBtn = e('button', { className: 'red' }, "Del");
        const div = document.querySelector('.modules');
        const ul = e('ul', {},);
        const li = e('li', { className: 'flex' },
            e('h4', { className: date }, `${lecture} - ${date.split('-').join('/').split('T').join(' - ')}`),
            delBtn);
        ul.appendChild(li);

        if (document.querySelector(`.${module}`)) {
            document.querySelector(`.${module}`).parentElement.appendChild(ul);
        } else {
            const divToAttach = e('div', { className: 'module' },
                e('h3', { className: module }, `${module.toUpperCase()}-MODULE`),
                ul);
            div.appendChild(divToAttach);
        }

        const currentModule = document.querySelector(`.${module}`).parentElement;
        const liArr = currentModule.querySelectorAll('li');

        Array.from(liArr)
            .sort((a, b) => a.querySelector('h4').className.localeCompare(b.querySelector('h4').className))
            .forEach(x => ul.appendChild(x));


        delBtn.addEventListener('click', () => {

            const liCoumt = Array.from(currentModule.querySelectorAll('li')).length;
            if (liCoumt == 1) {
                li.parentElement.parentElement.remove();
            } else {
                li.remove();
            }
        });
    }

    function e(type, attributes, ...content) {
        const result = document.createElement(type);

        for (let [attr, value] of Object.entries(attributes || {})) {
            if (attr.substring(0, 2) == 'on') {
                result.addEventListener(attr.substring(2).toLocaleLowerCase(), value);
            } else {
                result[attr] = value;
            }
        }

        content = content.reduce((a, c) => a.concat(Array.isArray(c) ? c : [c]), []);

        content.forEach(e => {
            if (typeof e == 'string' || typeof e == 'number') {
                const node = document.createTextNode(e);
                result.appendChild(node);
            } else {
                result.appendChild(e);
            }
        });

        return result;
    }
}