function solve(inputArr) {
    let outputArr = [];
    let count = 0;
    while (inputArr.length > 0) {
        if (count % 2 == 0) {
            outputArr.push(Math.min(...inputArr));
            let index = inputArr.indexOf(Math.min(...inputArr));
            inputArr.splice(index, 1);
        } else {
            outputArr.push(Math.max(...inputArr));
            let index = inputArr.indexOf(Math.max(...inputArr));
            inputArr.splice(index, 1);
        }
        count++;
    }

    return outputArr;
}

console.log(solve([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));
