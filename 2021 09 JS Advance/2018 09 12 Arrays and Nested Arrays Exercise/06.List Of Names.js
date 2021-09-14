function solve(inputArr) {
    inputArr.sort((a, b) => a.localeCompare(b));
    let count = 1;
    let output = [];
    for (let name of inputArr) {
        output.push(`${count}.${name}`);
        count ++;
    }
    return output.join("\n");
}

console.log(solve(["John", "Bob", "Christina", "Ema"]));