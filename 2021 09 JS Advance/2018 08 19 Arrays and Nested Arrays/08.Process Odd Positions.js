function solve(inputArr) {
    let outputArr = [];

    for (let i = 0; i < inputArr.length; i++) {
        if (i % 2 != 0) {
            outputArr.unshift(inputArr[i] * 2);
        }
    }

    let output = "";
    for (j = 0; j < outputArr.length; j++){
        output += outputArr[j] + " ";
    }

    return output
}

console.log(solve([10, 15, 20, 25]));
console.log(solve([3, 0, 10, 4, 7, 3]));