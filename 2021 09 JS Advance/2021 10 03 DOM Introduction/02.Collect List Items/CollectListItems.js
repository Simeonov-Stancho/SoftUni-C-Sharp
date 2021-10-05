function extractText() {
   const itemsCollection = document.getElementById('items').textContent;
   const result = document.getElementById('result').textContent;

    result = itemsCollection;
}


//with querySelectorAll
function extractText() {
    const itemsCollection = document.querySelectorAll('#items li');
    const result = document.getElementById('result');

    const returnedText = Array.from(itemsCollection)
                              .map(i => i.textContent)
                              .join('\n');

    result.textContent = returnedText;
}

//with getElementById
function extractText() {
    const itemsCollection = document.getElementById('items').children;
    const result = document.getElementById('result');

    const returnedText = Array.from(itemsCollection)
                              .map(i => i.textContent)
                              .join('\n');

    result.textContent = returnedText;
}