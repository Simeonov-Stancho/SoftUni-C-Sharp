function addItem() {
    const text = document.getElementById('newItemText');
    const li = document.createElement('li');
    li.textContent = text.value;
    document.getElementById('items').appendChild(li);

    text.value = '';
}

//obj
function addItem() {
    const data = {
        text: document.getElementById("newItemText"),
        collection: document.getElementById("items"),
    }

    function elFactory(tag, content) {
        const temp = document.createElement(tag)
        temp.textContent = content
        return temp
    }

    data.collection.appendChild(elFactory("li", data.text.value))
    data.text.value = '';
}