function solution() {
    const recipes = {
        apple: {
            carbohydrate: 1,
            flavour: 2,
            ingredient: ['carbohydrate', 'flavour'],
        },

        lemonade: {
            carbohydrate: 10,
            flavour: 20,
            ingredient: ['carbohydrate', 'flavour'],
        },

        burger: {
            carbohydrate: 5,
            fat: 7,
            flavour: 3,
            ingredient: ['carbohydrate', 'fat', 'flavour'],
        },

        eggs: {
            protein: 5,
            fat: 1,
            flavour: 1,
            ingredient: ['protein', 'fat', 'flavour'],
        },

        turkey: {
            protein: 10,
            carbohydrate: 10,
            fat: 10,
            flavour: 10,
            ingredient: ['protein', 'carbohydrate', 'fat', 'flavour'],
        }
    }

    let microelements = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0,
    }

    return instructions;

    function instructions(instruction) {
        const [command, x, quantity] = instruction.split(' ');

        if (command == 'restock') {
            microelements[x] += Number(quantity);
            return 'Success'
        }

        if (command == 'prepare') {
            const receiptRequired = Object.assign({}, recipes[x]); ;

            receiptRequired.ingredient.forEach(i => {
                receiptRequired[i] *= Number(quantity)
            });

            for (let i of receiptRequired.ingredient) {
                if (microelements[i] < receiptRequired[i]) {
                    return `Error: not enough ${i} in stock`;
                }
            };

            receiptRequired.ingredient.forEach(i => microelements[i] -= receiptRequired[i]);

            return 'Success';
        } 
        
        if (command == 'report') {
            return `protein=${microelements.protein} carbohydrate=${microelements.carbohydrate} fat=${microelements.fat} flavour=${microelements.flavour}`
        }
    }
}

// let manager = solution();
// console.log(manager('restock flavour 50'));
// console.log(manager('prepare lemonade 4 '));
// console.log(manager('restock carbohydrate 10'));
// console.log(manager('restock flavour 10'));
// console.log(manager('prepare apple 1'));
// console.log(manager('restock fat 10'));
// console.log(manager('prepare burger 1'));
// console.log(manager('report'));

let manager = solution();
console.log(manager('prepare turkey 1'));
console.log(manager('restock protein 10'));
console.log(manager('prepare turkey 1'));
console.log(manager('restock carbohydrate 10'));
console.log(manager('prepare turkey 1'));
console.log(manager('restock fat 10'));
console.log(manager('prepare turkey 1'));
console.log(manager('restock flavour 10'));
console.log(manager('prepare turkey 1'));
console.log(manager('report'));