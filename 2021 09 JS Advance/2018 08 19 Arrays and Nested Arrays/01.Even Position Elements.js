function evenPossitionElement(inputArr){
    let output = '';

    for(let i=0; i < inputArr.length; i+=2 ){
    output += inputArr[i] + " ";
    }

    return output;
}

console.log(evenPossitionElement(['20', '30', '40']));
console.log(evenPossitionElement(['5', '10']));