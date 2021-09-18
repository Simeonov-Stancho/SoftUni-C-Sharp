function solve(arr) {
    arr = arr.map(x => x.split(" ").map(Number));

    const getDiagSum = arr => arr.reduce((a, v, i) => a + v[i], 0);

    const mapToSum = (arr, sum) =>
        arr.map((x, i) => x.map((y, j) => (j === i || j === x.length - i - 1 ? y : sum)));
    const print = arr => arr.map(x => x.join(" ")).join("\n");

    const [reversedMatrix, resultMatrix] = [arr.reverse(), arr.reverse()];

    return getDiagSum(resultMatrix) === getDiagSum(reversedMatrix)
        ? print(mapToSum(resultMatrix, getDiagSum(resultMatrix)))
        : print(resultMatrix);
}

console.log(solve(['5 3 12 3 1',
                    '11 4 23 2 5',
                    '101 12 3 21 10',
                    '1 4 5 2 2',
                    '5 22 33 11 1']
));

console.log(solve(['1 1 1',
                    '1 1 1',
                    '1 1 0']
));