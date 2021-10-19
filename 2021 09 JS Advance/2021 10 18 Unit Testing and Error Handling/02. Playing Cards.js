function solve(face, suit) {
    const suits = {
        'S': '\u2660',
        'H': '\u2665',
        'D': '\u2666',
        'C': '\u2663',
    }

    if (!Object.keys(suits).includes(suit)) {
        throw new Error();
    }

    const faces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];

    if (!faces.includes(face)) {
        throw new Error();
    }
    return {
        face,
        suit: suits[suit],
        toString() {
            return this.face + this.suit
        }
    };
}

const input1 = solve('A', 'S');
console.log(input1.toString());

const input2 = solve('10', 'H');
console.log(input2.toString());

const input3 = solve('1', 'C');
console.log(input3.toString());

const input4 = solve('2', 'I');
console.log(input4.toString());

const input5 = solve('1', 's');
console.log(input5.toString());