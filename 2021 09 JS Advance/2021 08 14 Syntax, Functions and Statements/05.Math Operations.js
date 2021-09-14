function mathOperation(num1, num2, input){
let result;
    if(input=="+"){
        result = num1 + num2;
    }
    if(input=="-"){
        result = num1 - num2;
    }
        if(input=="*"){
            result = num1 * num2;
    }
    if(input=="/"){
        result = num1 / num2;
    }
    if(input=="%"){
        result = num1 % num2;
    }
    if(input=="**"){
        result = num1 ** num2;
    }
    console.log(result);
}

mathOperation(3, 5.5, '*')