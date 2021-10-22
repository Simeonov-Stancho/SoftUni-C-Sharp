function solve(input) {
    let manifactures = {};

    for (let i = 0; i < input.length; i++) {

        let [carBrand, carModel, producedCars] = input[i].split(' | ');
        producedCars = Number(producedCars);

        if (!manifactures.hasOwnProperty(carBrand)) {
            manifactures[carBrand] = { [carModel]: producedCars };
        } else {
            if (!manifactures[carBrand].hasOwnProperty(carModel)) {
                manifactures[carBrand][carModel] = producedCars;
            } else {
                manifactures[carBrand][carModel] += producedCars;
            }
        }
    }

    for (let brand in manifactures) {
        console.log(brand);
        let models = Object.entries(manifactures[brand]);
        for (let modelInfo of models) {
            console.log(`###${modelInfo[0]} -> ${modelInfo[1]}`);
        }
    }
}

solve(['Audi | Q7 | 1000',
    'Audi | Q6 | 100',
    'BMW | X5 | 1000',
    'BMW | X6 | 100',
    'Citroen | C4 | 123',
    'Volga | GAZ-24 | 1000000',
    'Lada | Niva | 1000000',
    'Lada | Jigula | 1000000',
    'Citroen | C4 | 22',
    'Citroen | C5 | 10']
);