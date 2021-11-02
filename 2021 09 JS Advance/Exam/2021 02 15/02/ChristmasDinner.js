class ChristmasDinner {
    constructor(budget) {
        if (budget < 0) {
            throw new Error("The budget cannot be a negative number");
        }
        this.budget = budget;
        this.dishes = [];
        this.products = [];
        this.guests = {};
    }

    shopping(product) {
        const currentProduct = product[0];
        const currentProductPrice = Number(product[1]);
        if (this.budget - currentProductPrice < 0) {
            throw new Error("Not enough money to buy this product");
        }

        this.products.push(currentProduct);
        this.budget -= currentProductPrice;

        return `You have successfully bought ${currentProduct}!`
    }

    recipes({ recipeName, productsList }) {
        productsList.forEach(p => {
            if (!this.products.includes(p)) {
                throw new Error("We do not have this product");
            }
        });

        this.dishes.push({ recipeName, productsList });

        return `${recipeName} has been successfully cooked!`
    }

    inviteGuests(name, dish) {
        let isThisDishes = this.dishes.some(d=>d.recipeName == dish);
        if (!isThisDishes) {
            throw new Error("We do not have this dish");
        }
        
        if (this.guests.hasOwnProperty(name)) {
            throw new Error("This guest has already been invited");
        }
        
        this.guests[name] = dish;

        return `You have successfully invited ${name}!`
    }

    showAttendance() {
        let result = [];

        for (const guest in this.guests) {
            let dishName = this.guests[guest];
            let productsInDish = this.dishes.find(d=>d.recipeName == dishName).productsList;

            result.push(`${guest} will eat ${dishName}, which consists of ${productsInDish.join(', ')}`);
        }

        return result.join('\n');
    }
}

let dinner = new ChristmasDinner(300);

dinner.shopping(['Salt', 1]);
dinner.shopping(['Beans', 3]);
dinner.shopping(['Cabbage', 4]);
dinner.shopping(['Rice', 2]);
dinner.shopping(['Savory', 1]);
dinner.shopping(['Peppers', 1]);
dinner.shopping(['Fruits', 40]);
dinner.shopping(['Honey', 10]);

dinner.recipes({
    recipeName: 'Oshav',
    productsList: ['Fruits', 'Honey']
});
dinner.recipes({
    recipeName: 'Folded cabbage leaves filled with rice',
    productsList: ['Cabbage', 'Rice', 'Salt', 'Savory']
});
dinner.recipes({
    recipeName: 'Peppers filled with beans',
    productsList: ['Beans', 'Peppers', 'Salt']
});

dinner.inviteGuests('Ivan', 'Oshav');
dinner.inviteGuests('Petar', 'Folded cabbage leaves filled with rice');
dinner.inviteGuests('Georgi', 'Peppers filled with beans');

console.log(dinner.showAttendance());
