function solve(inputArr) {
    let products = {};
    let output = "";

    for (let i = 0; i < inputArr.length; i++) {
        let [town, product, price] = inputArr[i].split(" | ");
        price = Number(price);

        if (products[product] != undefined) {
            products[product][town] = price;
        }else{
            products[product] = {[town]: price};
        }
    }

    for (const key in products) {
        let sortedProducts = Object.entries(products[key]).sort((a, b) => a[1] - b[1]);
        output += `${key} -> ${sortedProducts[0][1]} (${sortedProducts[0][0]})\n`
    }

    return output;
}

console.log(solve(['Sample Town | Sample Product | 1000',
'Sample Town | Orange | 2',
'Sample Town | Peach | 1',
'Sofia | Orange | 3',
'Sofia | Peach | 2',
'New York | Sample Product | 1000.1',
'New York | Burger | 10']));

console.log(solve(['Sample Town | Sample Product | 1000',
'Sample Town | Sample Product | 2000',
'Sample Town | Peach | 1',
'New York | Sample Product | 1000.1',
'New York | Burger | 10']));