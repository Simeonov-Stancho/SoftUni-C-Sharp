function solve(inputArr, number){
    for (let i = 0; i < number; i++) {
        inputArr.unshift(inputArr.pop());    
    }

    return inputArr.join(" ");
}

console.log(solve(['1', '2', '3', '4'], 2));
console.log(solve(['Banana', 'Orange', 'Coconut', 'Apple'], 15));