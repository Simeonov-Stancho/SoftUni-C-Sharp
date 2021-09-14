function solve(inputArr, delimiter) {
    let output = inputArr.join(delimiter);

    return output;
}

console.log(solve(['One', 'Two', 'Three', 'Four', 'Five' ], '-'));
console.log(solve(['How about no?', 'I','will', 'not', 'do', 'it!'], '_'));
