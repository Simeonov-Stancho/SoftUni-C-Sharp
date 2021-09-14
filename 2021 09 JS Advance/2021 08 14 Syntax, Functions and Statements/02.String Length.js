function stringLength(input1, input2, input3){
    let lengthSum = input1.length + input2.length + input3.length;
    let lengthAverage = Math.floor(lengthSum/3);

    console.log(lengthSum);
    console.log(lengthAverage);
}

stringLength('aaa', 'bbb', 'ccc');