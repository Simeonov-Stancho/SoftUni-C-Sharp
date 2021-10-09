function addItem() {
    //create element
    const text = document.getElementById('newItemText');
    const li = document.createElement('li');
    li.textContent = text.value;
    document.getElementById('items').appendChild(li);

    text.value = '';

    //create button and append it to element of DOM
    const deleteButton = document.createElement('a');
    deleteButton.href = '#';
    deleteButton.textContent = '[Delete]';
    li.appendChild(deleteButton);
    
    //append button event
    deleteButton.addEventListener('click', deleteElement);

    //remove element
    function deleteElement (event){
        const parentEl = event.target.parentNode;
        parentEl.remove();
    }
}