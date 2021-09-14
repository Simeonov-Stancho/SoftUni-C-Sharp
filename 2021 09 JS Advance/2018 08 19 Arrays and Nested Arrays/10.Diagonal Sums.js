function solve(inputArr) {
    let mainDiagonal = 0;
    let secondaryDiagonal = 0;

    let mainIndex = 0;
    let secondaryIndex = inputArr[0].length - 1;

    inputArr.forEach(currentArray => {
        mainDiagonal += currentArray[mainIndex++]
        secondaryDiagonal += currentArray[secondaryIndex--]

    });

    return `${mainDiagonal} ${secondaryDiagonal}`;
}

console.log(solve([[20, 40],
            [10, 60]]));