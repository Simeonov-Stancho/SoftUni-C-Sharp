function deleteByEmail() {
    const text = document.getElementById('newItemText');
    const li = document.createElement('li');
    li.textContent = text.value;
    document.getElementById('items').appendChild(li);

    text.value = '';
}