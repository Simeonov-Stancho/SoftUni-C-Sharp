function solve(inputArr) {
    let foodsCalories = {};

    for (let i = 0; i < inputArr.length; i += 2) {
        let food = inputArr[i];
        let calories = inputArr[i + 1]; // of 100 grams

        foodsCalories[food] = Number(calories);
    }

    return foodsCalories;
}

console.log(solve(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']));
console.log(solve(['Potato', '93', 'Skyr', '63', 'Cucumber', '18', 'Milk', '42']));