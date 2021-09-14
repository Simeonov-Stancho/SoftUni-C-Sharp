function solve(inputArr) {
    let outputArr = [];
    let currentMaxNumber = 0;

    for (let element of inputArr) {
        if (currentMaxNumber <= element) {
            outputArr.push(element);
            currentMaxNumber = element;
        }
    }

    return outputArr;
}

console.log(solve([1, 3, 8, 4, 10, 12, 3, 2, 24]));
console.log(solve([1, 2, 3, 4]));
console.log(solve([20, 3, 2, 15, 6, 1]));