function solve() {
  const inputArray = document.querySelector('textarea[rows ="5"]');
  const outputArray = document.querySelector('textarea[rows ="4"]');
  let table = document.querySelector('tbody');

  const generateButton = document.getElementById('exercise').children[2];
  const buyButton = document.getElementById('exercise').children[5];

  generateButton.addEventListener('click', generateFurnitureList);
  buyButton.addEventListener('click', buyFurniture);

  function generateFurnitureList() {
    let array = JSON.parse(inputArray.value)

    for (let i = 0; i < array.length; i++) {
      let furniture = array[i];

      const trField = document.createElement('tr');

      insertRow(trField, 'img', { src: furniture.img });
      insertRow(trField, 'p', {}, furniture.name);
      insertRow(trField, 'p', {}, furniture.price);
      insertRow(trField, 'p', {}, furniture.decFactor);
      insertRow(trField, 'input', { type: 'checkbox' });

      table.appendChild(trField);
    }
  }

  function insertRow(trField, tag, atributes, content) {
    const tdTag = document.createElement('td');
    const cellTag = document.createElement(tag);

    for (const atrubute in atributes) {
      cellTag[atrubute] = atributes[atrubute]
    }

    if (content) {
      cellTag.textContent = content;
    }

    tdTag.appendChild(cellTag);
    trField.appendChild(tdTag);
  }

  function buyFurniture() {
    const checkBoxArrey = Array.from(document.querySelectorAll('input[type = "checkbox"]'));

    let boughtFurnitures = [];
    let totalPrice = 0;
    let totalDecFactor = 0;

    for (let i = 0; i < checkBoxArrey.length; i++) {
      if (checkBoxArrey[i].checked) {
        boughtFurnitures.push(table.children[i].children[1].textContent);
        totalPrice += Number(table.children[i].children[2].textContent);
        totalDecFactor += Number(table.children[i].children[3].textContent);
      }
    }

    outputArray.textContent += `Bought furniture: ${boughtFurnitures.join(', ')}\n`;
    outputArray.textContent += `Total price: ${totalPrice.toFixed(2)}\n`;
    outputArray.textContent += `Average decoration factor: ${totalDecFactor / boughtFurnitures.length}`;
  }
}

//[{"name": "Sofa", "img": "https://res.cloudinary.com/maisonsdumonde/image/upload/q_auto,f_auto/w_200/img/grey-3-seater-sofa-bed-200-13-0-175521_9.jpg", "price": 150, "decFactor": 1.2}, {"name": "Trata", "img": "https://res.cloudinary.com/maisonsdumonde/image/upload/q_auto,f_auto/w_200/img/grey-3-seater-sofa-bed-200-13-0-175521_9.jpg", "price": 1250, "decFactor": 10.20}]