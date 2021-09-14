function sum(input){
    let output = 0;
    output = Number(input.pop()) + Number(input.shift());

    return output
}

console.log(sum(['20', '30', '40']));
console.log(sum(['5', '10']));