function solve(inputArr) {
    let count = 0;

    for (let i = 0; i < inputArr.length; i++) {
        for (let x = 0; x < inputArr[i].length; x++) {
            if (x + 1 < inputArr[i].length 
                && inputArr[i][x] === inputArr[i][x + 1]) {
                count++;
            }

            if (i + 1 < inputArr.length 
                && inputArr[i][x] === inputArr[i + 1][x]) {
                count++;
            }

        }
    }

    return count;
}

console.log(solve([['2', '2', '5', '7', '4'],
                   ['4', '0', '5', '3', '4'],
                   ['2', '5', '5', '4', '2']]
));

console.log(solve([['2', '3', '4', '7', '0'],
['4', '0', '5', '3', '4'],
['2', '3', '5', '4', '2'],
['9', '8', '7', '5', '4']]
));

console.log(solve([['test', 'yes', 'yo', 'ho'],
['well', 'done', 'yo', '6'],
['not', 'done', 'yet', '5']]
));
