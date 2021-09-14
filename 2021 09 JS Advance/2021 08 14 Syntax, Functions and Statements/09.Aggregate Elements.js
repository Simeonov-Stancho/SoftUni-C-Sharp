function aggregateElements(array){
    let sum = 0;
    for(let i = 0; i<array.length; i++){
        sum += array[i];
    }
    console.log(sum);
    
    let inverseSum = 0
    for (let z = 0; z < array.length; z++) {
       inverseSum += 1 / array[z];
    }

    console.log(inverseSum);

    let concat = '';

    for (let x = 0; x < array.length; x++) {
        concat += array[x];    
    }
    console.log(concat);
}

aggregateElements([1, 2, 3]);