function solve(inputArr) {
    let count = 0;
    let output = "";

    while(count < 2){
    let currentMinNum = Math.min.apply(Math, inputArr);
    output += currentMinNum + " ";
    count ++;
    inputArr.splice(inputArr.indexOf(currentMinNum), 1)
    }

    return output;
}

console.log(solve([30, 15, 50, 5]))
console.log(solve([3, 0, 10, 4, 7, 3]))