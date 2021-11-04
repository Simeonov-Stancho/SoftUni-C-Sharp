class Restaurant {

    constructor(budget) {
        this.budgetMoney = budget;
        this.menu = {};
        this.stockProducts = {};
        this.history = [];
    }

    loadProducts(products) {

        products.forEach(product => {
            let productName = product.split(' ')[0];
            let productQuantity = Number(product.split(' ')[1]);
            let productTotalPrice = Number(product.split(' ')[2]);

            if (this.budgetMoney >= productTotalPrice) {
                if (this.stockProducts.hasOwnProperty(productName)) {
                    this.stockProducts[productName] += productQuantity;
                } else {
                    this.stockProducts[productName] = productQuantity;
                }

                this.budgetMoney -= productTotalPrice;

                this.history.push(`Successfully loaded ${productQuantity} ${productName}`);

            } else {
                this.history.push(`There was not enough money to load ${productQuantity} ${productName}`);
            }
        });

        return this.history.join('\n')
    }

    addToMenu(meal, products, price) {
        if (!this.menu.hasOwnProperty(meal)) {
            this.menu[meal] = {
                products,
                price,
            };
        } else {
            return `The ${meal} is already in the our menu, try something different.`;
        }

        let mealsNumber = Object.keys(this.menu).length;

        if (mealsNumber == 1) {
            return `Great idea! Now with the ${meal} we have 1 meal in the menu, other ideas?`;
        } else {
            return `Great idea! Now with the ${meal} we have ${mealsNumber} meals in the menu, other ideas?`;
        }
    }

    showTheMenu() {
        let mealsNumber = Object.keys(this.menu).length;
        let result = [];

        if (mealsNumber == 0) {
            return "Our menu is not ready yet, please come later...";
        }

        for (let i = 0; i < Object.entries(this.menu).length; i++) {
            let meal = Object.entries(this.menu)[i][0];
            let mealInfo = Object.entries(this.menu)[i][1];

            result.push(`${meal} - $ ${mealInfo.price}`)
        }

        // for (const [meal, mealInfo] of Object.entries(this.menu)) {
        //     result.push(`${meal} - $ ${mealInfo.price}`);
        // }

        return result.join('\n')
    }

    makeTheOrder(certainMeal) {
        if (!this.menu.hasOwnProperty(certainMeal)) {
            return `There is not ${certainMeal} yet in our menu, do you want to order something else?`;
        } else {

            let meal = this.menu[certainMeal];
            for (const productInfo of meal.products) {
                let productName = productInfo.split(' ')[0];
                let productQty = Number(productInfo.split(' ')[1]);
                if (!this.stockProducts.hasOwnProperty(productName) || this.stockProducts[productName] < productQty) {
                    return `For the time being, we cannot complete your order (${certainMeal}), we are very sorry...`;
                }
            }

            for (const productInfo of meal.products) {
                let productName = productInfo.split(' ')[0];
                let productQty = Number(productInfo.split(' ')[1]);

                this.stockProducts[productName] -= productQty;
                this.budgetMoney += meal.price;

            }

            return `Your order (${certainMeal}) will be completed in the next 30 minutes and will cost you ${meal.price}.`;
        }
    }
}

// let kitchen = new Restaurant(1000);
// console.log(kitchen.loadProducts(['Banana 10 5', 'Banana 20 10', 'Strawberries 50 30', 'Yogurt 10 10', 'Yogurt 500 1500', 'Honey 5 50']));

// let kitchen = new Restaurant(1000);
// console.log(kitchen.addToMenu('frozenYogurt', ['Yogurt 1', 'Honey 1', 'Banana 1', 'Strawberries 10'], 9.99));
// console.log(kitchen.addToMenu('Pizza', ['Flour 0.5', 'Oil 0.2', 'Yeast 0.5', 'Salt 0.1', 'Sugar 0.1', 'Tomato sauce 0.5', 'Pepperoni 1', 'Cheese 1.5'], 15.55));

// console.log(kitchen.showTheMenu());


let kitchen = new Restaurant(1000);
kitchen.loadProducts(['Yogurt 30 3', 'Honey 50 4', 'Strawberries 20 10', 'Banana 5 1']);
kitchen.addToMenu('frozenYogurt', ['Yogurt 1', 'Honey 1', 'Banana 1', 'Strawberries 10'], 9.99);
console.log(kitchen.makeTheOrder('frozenYogurt'));
