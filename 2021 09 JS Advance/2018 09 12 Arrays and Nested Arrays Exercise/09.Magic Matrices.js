function solve(inputArr) {
    let rowSum = 0;
    let nextRowSum = 0;
    
    for (let i = 1; i < inputArr.length; i++) {
        rowSum = inputArr[i - 1].reduce((acc, c) => acc + c);
        nextRowSum = inputArr[i].reduce((acc, c) => acc + c);
        if (rowSum != nextRowSum) {
            return false;
        }
    }

    for (let col = 0; col < inputArr[col].length - 1; col++) {
        let columnSum = 0;
        for (let row = 0; row < inputArr.length; row++) {
            columnSum += inputArr[row][col];
        }
        if (columnSum != rowSum) {
            return false;
        }
    }

    return true;
}

console.log(solve([[4, 5, 6],
[6, 5, 4],
[5, 5, 5]]));

console.log(solve([[11, 32, 45],
[21, 0, 1],
[21, 1, 1]]));

console.log(solve([[1, 0, 0],
[0, 0, 1],
[0, 1, 0]]));