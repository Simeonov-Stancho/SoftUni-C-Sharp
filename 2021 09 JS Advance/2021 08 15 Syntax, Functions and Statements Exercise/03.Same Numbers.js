function checkNumber(number){
    let stringNumber = "";
    let isSameNumber = true;
    stringNumber +=number;
    let sum = Number(stringNumber[0]); 
    for(let digit = 1; digit < stringNumber.length; digit++){
        if(stringNumber[digit-1]!=stringNumber[digit]){
            isSameNumber = false;
        }
        sum += Number(stringNumber[digit]);
    }

    console.log(isSameNumber);
    console.log(sum)
}


checkNumber(2222222);