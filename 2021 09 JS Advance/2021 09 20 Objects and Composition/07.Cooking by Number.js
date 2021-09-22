function cookingByNUmbers(startingPoint, operation1, operation2, operation3, operation4, operation5) {
    let points = Number(startingPoint);

    let command = {
        chop() { points /= 2 },
        dice() { points = Math.sqrt(points) },
        spice() { points += 1 },
        bake() { points *= 3 },
        fillet() { points *= 0.8 },
    }

    command[operation1]();
    console.log(points);
    command[operation2]();
    console.log(points);
    command[operation3]();
    console.log(points);
    command[operation4]();
    console.log(points);
    command[operation5]();
    console.log(points);
    
}

cookingByNUmbers('9', 'dice', 'spice', 'chop', 'bake', 'fillet');
