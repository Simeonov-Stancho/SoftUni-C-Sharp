// function solve(inputArr, string) {
//     return string == 'asc' ? inputArr.sort((a, b) => a - b) : inputArr.sort((a, b) => b - a)
// }

function solve(inputArr, string) {
    if (string == 'asc') {
        return inputArr.sort((a, b) => a - b);
    } else if(string == 'desc') {
        return inputArr.sort((a, b) => b - a);
    } else {
        return 'Invalid argument!!!';
    }
}

console.log(solve([14, 7, 17, 6, 8], 'asc'));
console.log(solve([14, 7, 17, 6, 8], 'desc'));
console.log(solve([14, 7, 17, 6, 8], 'err'));