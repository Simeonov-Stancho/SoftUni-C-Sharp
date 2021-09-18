function solve(row, col) {
    let matrix = new Array(col).fill(new Array(row).fill([]));
    matrix = matrix.map(x => x.map(y => ""));
    let [startRow, endRow, startClmn, endClmn, counter] = [0, col - 1, 0, row - 1, 0];

    while (startClmn <= endClmn && startRow <= endRow) {
        for (let i = startClmn; i <= endClmn; i++) {
            matrix[startRow][i] = ++counter;
        }
        startRow++;

        for (let i = startRow; i <= endClmn; i++) {
            matrix[i][endClmn] = ++counter;
        }
        endClmn--;

        for (let i = endClmn; i >= startClmn; i--) {
            matrix[endRow][i] = ++counter;
        }
        endRow--;
        
        for (let i = endRow; i >= startRow; i--) {
            matrix[i][startClmn] = ++counter;
        }
        startClmn++
    };

    return matrix.map(x => x.join(" ")).join("\n")
}

console.log(solve(5, 5));
console.log(solve(3, 3));
