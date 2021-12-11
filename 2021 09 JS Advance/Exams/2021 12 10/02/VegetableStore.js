class VegetableStore {
    constructor(owner, location) {
        this.owner = owner;
        this.location = location;
        this.availableProducts = [];
        this._currentAvaibleVegetables = [];
    }

    loadingVegetables(vegetables) {
        vegetables.forEach(v => {
            const vegetableType = v.split(' ')[0];
            const vegetableQuantity = Number(v.split(' ')[1]);
            const vegetablePrice = Number(v.split(' ')[2]);

            let currentVegetable = this.availableProducts.find(p => p.type == vegetableType);

            if (currentVegetable != undefined) {
                currentVegetable.quantity += vegetableQuantity;
                if (currentVegetable.price < vegetablePrice) {
                    currentVegetable.price = vegetablePrice;
                }
            } else {
                this.availableProducts.push({
                    type: vegetableType,
                    quantity: vegetableQuantity,
                    price: vegetablePrice,
                });

                this._currentAvaibleVegetables.push(vegetableType);
            }
        });

        return `Successfully added ${this._currentAvaibleVegetables.join(', ').trimEnd()}`;
    }

    buyingVegetables(selectedProducts) {

        let totalPrice = 0;

        selectedProducts.forEach(p => {
            const selectedVegetableType = p.split(' ')[0];
            const selectedVegetableQuantity = Number(p.split(' ')[1]);

            // let isPresent = this._currentAvaibleVegetables.some(p=> p==selectedVegetableType);
            let isPresentProduct = this.availableProducts.find(c => c.type == selectedVegetableType);

            if (isPresentProduct == undefined) {
                throw new Error(`${selectedVegetableType} is not available in the store, your current bill is $${totalPrice.toFixed(2)}.`);
            }

            if (selectedVegetableQuantity > isPresentProduct.quantity) {
                throw new Error(`The quantity ${selectedVegetableQuantity} for the vegetable ${selectedVegetableType} is not available in the store, your current bill is $${totalPrice.toFixed(2)}.`)
            }

            let price = isPresentProduct.price * selectedVegetableQuantity;
            isPresentProduct.quantity -= selectedVegetableQuantity;
            totalPrice += price;
        })

        return `Great choice! You must pay the following amount $${totalPrice.toFixed(2)}.`
    }

    rottingVegetable(type, quantity) {
        let isPresentProduct = this.availableProducts.find(c => c.type == type);

        if (isPresentProduct == undefined) {
            throw new Error(`${type} is not available in the store.`)
        }

        if (quantity > isPresentProduct.quantity) {
            isPresentProduct.quantity = 0;
            return `The entire quantity of the ${type} has been removed.`
        }

        isPresentProduct.quantity -= quantity;
        return `Some quantity of the ${type} has been removed.`
    }

    revision() {
        let result = [];

        result.push("Available vegetables:");
        this.availableProducts.sort((a, b) => a.price - b.price);
        this.availableProducts.forEach(p => result.push(`${p.type}-${p.quantity}-$${p.price}`));
        result.push(`The owner of the store is ${this.owner}, and the location is ${this.location}.`)
        return result.join('\n').trim();
    }
}

// let vegStore = new VegetableStore("Jerrie Munro", "1463 Pette Kyosheta, Sofia");
// console.log(vegStore.loadingVegetables(["Okra 2.5 3.5", "Beans 10 2.8", "Celery 5.5 2.2", "Celery 0.5 2.5"]));


// let vegStore = new VegetableStore("Jerrie Munro", "1463 Pette Kyosheta, Sofia");
//  console.log(vegStore.loadingVegetables(["Okra 2.5 3.5", "Beans 10 2.8", "Celery 5.5 2.2", "Celery 0.5 2.5"]));
//  console.log(vegStore.buyingVegetables(["Okra 1"]));
//  console.log(vegStore.buyingVegetables(["Beans 8", "Okra 1.5"]));
//  console.log(vegStore.buyingVegetables(["Banana 1", "Beans 2"]));


// let vegStore = new VegetableStore("Jerrie Munro", "1463 Pette Kyosheta, Sofia");
// console.log(vegStore.loadingVegetables(["Okra 2.5 3.5", "Beans 10 2.8", "Celery 5.5 2.2", "Celery 0.5 2.5"]));
// console.log(vegStore.rottingVegetable("Okra", 1));
// console.log(vegStore.rottingVegetable("Okra", 2.5));
// console.log(vegStore.buyingVegetables(["Beans 8", "Okra 1.5"]));


let vegStore = new VegetableStore("Jerrie Munro", "1463 Pette Kyosheta, Sofia");
console.log(vegStore.loadingVegetables(["Okra 2.5 3.5", "Beans 10 2.8", "Celery 5.5 2.2", "Celery 0.5 2.5"]));
console.log(vegStore.rottingVegetable("Okra", 1));
console.log(vegStore.rottingVegetable("Okra", 2.5));
console.log(vegStore.buyingVegetables(["Beans 8", "Celery 1.5"]));
console.log(vegStore.revision());
