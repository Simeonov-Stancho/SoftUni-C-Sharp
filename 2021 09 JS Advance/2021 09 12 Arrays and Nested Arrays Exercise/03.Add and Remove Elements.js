function solve(inputArr) {
    let outputArr = [];
    let number = 1;

    for (let i = 0; i < inputArr.length; i++) {
        let currentComand = inputArr[i];

        if (currentComand == 'add') {
            outputArr.push(number);
        } else {
            outputArr.pop();
        }
        number++;
    }

    if (outputArr.length == 0) {
        return 'Empty';
    }
    return outputArr.join('\n');
}

console.log(solve(['add', 'add', 'add', 'add']));
console.log(solve(['add', 'add', 'remove', 'add', 'add']));
console.log(solve(['remove', 'remove', 'remove']));