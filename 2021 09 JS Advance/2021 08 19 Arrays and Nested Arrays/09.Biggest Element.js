function solve(inputArr) {
   return Math.max(...inputArr.reduce((acc, c) => acc.concat(c)));
}

function solve(inputArr) {
    let maxElement = inputArr[0][0];

    for (let i = 0; i < inputArr.length; i++) {
        if (maxElement < Math.max(...inputArr[i])) {
            maxElement = Math.max(...inputArr[i]);
        }
    }
    return maxElement;
}

console.log(solve([[20, 50, 10, 1000], [8, 33, 145]]))
