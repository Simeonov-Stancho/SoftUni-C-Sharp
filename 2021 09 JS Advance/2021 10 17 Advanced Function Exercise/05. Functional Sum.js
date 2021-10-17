function add(num) {
    let sum = 0;

    function calc(num2) {
        sum += num2;
        return calc;
    }

    calc.toString = function () {
        return sum
    };
    
    return calc(num);
}

let a = add(1);
console.log(a.toString());


let b = add(1)(6)(-3);
console.log(b.toString());