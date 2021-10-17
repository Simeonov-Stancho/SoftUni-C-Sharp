function solution() {
    let output = '';

    return {
        append: string => output += string,
        removeStart: n => output = output.slice(n),
        removeEnd: n => output = output.slice(0, -n),
        print: () => console.log(output),
    }
}

function solution() {
    let output = '';

    return {
        append,
        removeStart,
        removeEnd,
        print,
    }

    function append(string) {
        output += string
    }

    function removeStart(n) {
        output = output.slice(n)
    }

    function removeEnd(n) {
        output = output.slice(0, -n)
    }

    function print() {
        console.log(output)
    }
}

let firstZeroTest = solution();

firstZeroTest.append('hello');
firstZeroTest.append('again');
firstZeroTest.removeStart(3); 
firstZeroTest.removeEnd(4);
firstZeroTest.print();

let secondZeroTest = solution();

secondZeroTest.append('123');
secondZeroTest.append('45');
secondZeroTest.removeStart(2);
secondZeroTest.removeEnd(1);
secondZeroTest.print();