function solve(inputArr) {
    inputArr.sort((a, b) => a - b);
    
    let outputArr = [];

    outputArr = inputArr.slice(Math.floor(inputArr.length/2))
    
    return outputArr;
}

console.log(solve([4, 7, 2, 5]));
console.log(solve([3, 19, 14, 7, 2, 19, 6]));

function solveDirect(numbers) {

    numbers.sort((a, b) => a - b)
           .slice(Math.floor(numbers.length/2));
    
    return numbers;
}
