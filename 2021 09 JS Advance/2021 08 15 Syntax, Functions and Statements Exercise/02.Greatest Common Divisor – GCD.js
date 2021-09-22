function greatestCommonDivisior(num1, num2) {
    let greatestDivisor = 0;
    let minNum = Math.min(num1, num2);
    for (let i = 1; i <= minNum; i++) {
        if (num1 % i == 0 && num2 % i == 0) {
            greatestDivisor = i;
        }
    }
    console.log(greatestDivisor);
}

greatestCommonDivisior(2154, 458);

function gcd(a, b) {
    while (b != 0) {
        const temp = b;
        b = a % b;
        a = temp;
    }

    return a;
}

console.log(gcd(2154, 458));