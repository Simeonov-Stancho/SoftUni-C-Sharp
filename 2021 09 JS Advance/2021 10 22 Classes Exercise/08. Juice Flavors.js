function solve(input) {
    const juices = {};
    const botlesOfJuice = {};

    for (let i = 0; i < input.length; i++) {
        const currentJuice = input[i].split(' => ')[0];
        const currentJuiceQty = Number(input[i].split(' => ')[1]);

        if (!juices[currentJuice]) {
            juices[currentJuice] = [];
            juices[currentJuice].push(currentJuiceQty);
        } else {
            juices[currentJuice].push(currentJuiceQty);
        }

        let sum = 0;

        for (let i = 0; i < juices[currentJuice].length; i++) {
            sum += juices[currentJuice][i];
        }

        if (sum >= 1000) {
            botlesOfJuice[currentJuice] = Math.trunc(sum / 1000);
        }
    }

    console.log(Object.entries(botlesOfJuice)
        .map(([name, quantity]) => `${name} => ${quantity}`)
        .join('\n'));
}

solve(['Orange => 2000',
    'Peach => 1432',
    'Banana => 450',
    'Peach => 600',
    'Strawberry => 549']
);

solve(['Kiwi => 234',
    'Pear => 2345',
    'Watermelon => 3456',
    'Kiwi => 4567',
    'Pear => 5678',
    'Watermelon => 6789']
);
