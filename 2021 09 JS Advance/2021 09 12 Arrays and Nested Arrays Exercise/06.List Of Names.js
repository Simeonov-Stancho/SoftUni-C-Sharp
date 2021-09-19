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

function solve1(inputArr) {
    let outputArr = inputArr
            .slice()
            .sort((a, b) => a.localeCompare(b))
            .map((name, index) => {
        let result = `${index + 1}.${name}`;
        return result;
    });
    
    return outputArr.join("\n");
}

console.log(solve1(["John", "Bob", "Christina", "Ema"]));