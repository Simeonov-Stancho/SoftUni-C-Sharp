function sumTable() {
    const products = (Array.from
            (document.querySelectorAll('table tbody tr > td:nth-child(2)')))
            .pop();
   
    let result = 0
    products.forEach(price => {
        result += Number(price.textContent);
    });

    const sum = document.getElementById('sum');
    sum.textContent = result;
}

function sumTable() {
    const products = Array.from(document.querySelectorAll('table tbody tr > td'));

    let result = 0;
    for (let i = 1; i < products.length - 1; i += 2) {
        result += Number(products[i].textContent);
    }

    const sum = document.getElementById('sum');

    sum.textContent = result;
}

function sumTable() {
    const products = Array.from(document.querySelectorAll('table tbody tr > td:nth-child(2)'));
    products.pop();

    let result = 0;
    for (let i = 0; i < products.length; i++) {
        result += Number(products[i].textContent);
    }

    const sum = document.getElementById('sum');

    sum.textContent = result;

}