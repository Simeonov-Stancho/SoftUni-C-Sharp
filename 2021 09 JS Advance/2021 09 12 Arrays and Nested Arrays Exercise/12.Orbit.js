function solve(arr) {
    let matrix = new Array(arr[0]).fill(new Array(arr[1]).fill(''));

    return matrix
        .map((x, i) => x.map((y, j) => Math.max(Math.abs(j - arr[3]), Math.abs(i - arr[2])) + 1))
        .map(x => x.join(" "))
        .join("\n");
}

console.log(solve([4, 4, 0, 0]));
console.log(solve([5, 5, 2, 2]));
console.log(solve([3, 3, 2, 2]));