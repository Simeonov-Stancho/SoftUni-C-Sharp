function solve(order) {
    let car = {};
    
    const smallEngine = { power: 90, volume: 1800, };
    const normalEngine = { power: 120, volume: 2400, };
    const monsterEngine = { power: 200, volume: 3500, };

    let hatchback = { type: 'hatchback', color: order.color, };
    let coupe = { type: 'coupe', color: order.color, };
    
    car.model = order.model;
    
    if (order.power >= 200) {
        car.engine = monsterEngine;
    } else if(order.power > 90 && order.power < 200) {
        car.engine = normalEngine;
    } else {
        car.engine = smallEngine;
    }
    
    if (order.carriage == 'hatchback') {
        car.carriage = hatchback;
    } else{
        car.carriage = coupe;
    }
    
    if (order.wheelsize % 2 == 0) {
        car.wheels = [order.wheelsize - 1, order.wheelsize - 1, order.wheelsize - 1, order.wheelsize - 1]
    } else {
        car.wheels = [order.wheelsize, order.wheelsize, order.wheelsize, order.wheelsize];
    }

    return car;
}

console.log(solve({
    model: 'VW Golf II',
    power: 90,
    color: 'blue',
    carriage: 'hatchback',
    wheelsize: 14
}
));
console.log(solve({
    model: 'Opel Vectra',
    power: 110,
    color: 'grey',
    carriage: 'coupe',
    wheelsize: 17
}
));