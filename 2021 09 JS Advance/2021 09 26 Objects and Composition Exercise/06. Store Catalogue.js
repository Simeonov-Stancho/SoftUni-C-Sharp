function solve(inputArr) {
    let products = {};
    let result = "";

    for (let i = 0; i < inputArr.length; i++) {
        let productInfo = inputArr[i].split(" : ");
        let productName = productInfo[0];
        let productPrice = Number(productInfo[1]);
        products[productName] = productPrice;
    }

    let sortedProducts = Object.entries(products).sort();

    let currentLetter = result.charAt(0);
    for (const product of sortedProducts) {
        let firstLetter = product[0].charAt(0);

        if (firstLetter != currentLetter) {
            result += `${product[0].charAt(0)}\n`;
            currentLetter = product[0].charAt(0);
        }
        result += `  ${product[0]}: ${product[1]}\n`;
    }

    return result;
}

console.log(solve(
    ['Appricot : 20.4',
        'Fridge : 1500',
        'TV : 1499',
        'Deodorant : 10',
        'Boiler : 300',
        'Apple : 1.25',
        'Anti-Bug Spray : 15',
        'T-Shirt : 10']));

console.log(solve(
    ['Banana : 2',
        'Rubic`s Cube : 5',
        'Raspberry P : 4999',
        'Rolex : 100000',
        'Rollon : 10',
        'Rali Car : 2000000',
        'Pesho : 0.000001',
        'Barrel : 10']));