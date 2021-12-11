window.addEventListener('load', solve);

//working on 100% - delete trHiddenEl
function solve() {
    const model = document.getElementById('model');
    const year = document.getElementById('year');
    const description = document.getElementById('description');
    const price = document.getElementById('price');

    const addBtn = document.getElementById('add');
    addBtn.addEventListener('click', addFurniture)

    let furnitureListEl = document.getElementById('furniture-list');
    let totalPrice = document.querySelector('.total-price');

    function addFurniture(event) {
        event.preventDefault();
        const yearValue = Number(year.value);
        const priceValue = Number(price.value);

        if (model.value == '' || description.value == '' ||
            yearValue <= 0 || priceValue <= 0) {
            return;
        }

        let trEl = document.createElement('tr');
        trEl.classList.add('info');
        trEl.innerHTML = `<td>${model.value}</td><td>${priceValue.toFixed(2)}</td><td><button class="moreBtn">More Info</button><button class="buyBtn">Buy it</button></td>`;

        let trHiddenEl = document.createElement('tr');
        trHiddenEl.classList.add('hide');
        trHiddenEl.innerHTML = `<td>Year: ${yearValue}</td><td colspan="3">Description: ${description.value}</td>`;

        furnitureListEl.appendChild(trEl);
        furnitureListEl.appendChild(trHiddenEl);

        let moreBtn = trEl.querySelector('button');
        let buyBtn = trEl.querySelectorAll('button')[1];

        moreBtn.addEventListener('click', () => {
            if (moreBtn.textContent == 'More Info') {
                moreBtn.textContent = 'Less Info';
                trHiddenEl.style.display = 'contents';
            } else if (moreBtnt.textContent == 'Less Info') {
                moreBtn.textContent = 'More Info';
                trHiddenEl.style.display = 'none';
            }
        });

        buyBtn.addEventListener('click', () => {
            const totalPriceBefore = Number(totalPrice.textContent);
            let totalPriceAfter = totalPriceBefore + priceValue;
            totalPrice.textContent = totalPriceAfter.toFixed(2);

            trEl.remove();
            trHiddenEl.remove();
        })

        model.value = '';
        year.value = '';
        description.value = '';
        price.value = '';
    }
}


//not deleting trHiddenEl
// function solve() {
//     let modelField = document.getElementById('model');
//     let yearField = document.getElementById('year');
//     let descriptionField = document.getElementById('description');
//     let priceField = document.getElementById('price');
//     //console.log(modelField, yearField, descriptionField, priceField);

//     const addButton = document.getElementById('add');
//     addButton.addEventListener('click', addFurniture);

//     const tableFields = document.getElementById('furniture-list');
//     //console.log(tableFields);

//     let totalPrice = document.querySelector('.total-price');

//     function addFurniture(event) {
//         event.preventDefault();
//         const yearValue = Number(yearField.value);
//         const priceValue = Number(priceField.value);

//         if (modelField.value == '' ||
//             descriptionField.value == '' ||
//             yearValue <= 0 || Number.isNaN(yearValue) ||
//             priceValue <= 0 || Number.isNaN(priceValue)) {
//             return;
//         }

//         let trElInfo = document.createElement('tr');
//         trElInfo.classList.add("info");
//         trElInfo.innerHTML = `<td>${modelField.value}</td><td>${priceValue.toFixed(2)}</td><td><button class="moreBtn">More Info</button><button class="buyBtn">Buy it</button></td>`;

//         let trElHide = document.createElement('tr');
//         trElHide.classList.add("hide");
//         trElHide.innerHTML = `<td>Year: ${yearField.value}</td><td colspan="3">Description: ${descriptionField.value}</td>`;

//         tableFields.appendChild(trElInfo);
//         tableFields.appendChild(trElHide);

//         //console.log(tableFields);

//         let moreBtn = trElInfo.querySelectorAll('button')[0];
//         let buyBtn = trElInfo.querySelectorAll('button')[1];

//         //console.log(moreBtn, buyBtn);
//         moreBtn.addEventListener('click', furnitureInfo);
//         buyBtn.addEventListener('click', buyFurniture);

//         modelField.value = '';
//         yearField.value = '';
//         descriptionField.value = '';
//         priceField.value = '';
//     }

//     function furnitureInfo(e) {
//         let furnitureDescription = e.target.parentElement.parentElement.nextElementSibling;

//         if (e.target.textContent == 'More Info') {
//             e.target.textContent = 'Less Info';
//             furnitureDescription.style.display = 'contents';
//         } else {
//             e.target.textContent = 'More Info';
//             furnitureDescription.style.display = 'none';
//         }
//     }

//     function buyFurniture(ev) {
//         let tableRow = ev.target.parentElement.parentElement;
//         let currentPrice = Number(tableRow.children[1].textContent);

//         let newTotalPrice = Number(totalPrice.textContent) + currentPrice;
//         totalPrice.textContent = newTotalPrice.toFixed(2);
//         tableRow.parentElement.removeChild(tableRow);
//     }
// }