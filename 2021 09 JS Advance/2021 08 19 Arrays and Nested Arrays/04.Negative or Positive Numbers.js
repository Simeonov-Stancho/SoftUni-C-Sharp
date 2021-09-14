function solve(input) {

    const outputArr = [];

    while(input.length != 0) {
         if(input[0] < 0) {
             outputArr.unshift(input.shift());
         }else {
             outputArr.push(input.shift());
         }
    }
    return outputArr;
}

console.log(solve([3, -2, 0, -1]).join('\r\n'));


function solveVictor(numbers) {
    const result = [];
    
    for (let num of numbers) {
        if (num < 0) {
            result.unshift(num);
        }else () => {
            result.push(num)}
           
    }

    for (let num of result) {
        console.log(num);
    }
}
solveVictor([3, -2, 0, -1]);