function calculator() {
    let numberOne;
    let numberTwo;
    let result;

    return{
        init: (selector1, selector2, resultSelector) => {
            numberOne = document.querySelector(selector1);
            numberTwo = document.querySelector(selector2);
            result = document.querySelector(resultSelector);
        },

        add: () => {
            result.value = Number(numberOne.value) + Number(numberTwo.value);
        },

        subtract: () => {
            result.value = Number(numberOne.value) - Number(numberTwo.value);
        }
    }
}

const calculate = calculator (); 
calculate.init ('#num1', '#num2', '#result'); 


