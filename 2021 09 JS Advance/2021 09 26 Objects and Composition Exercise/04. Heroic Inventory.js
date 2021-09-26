function solve(input) {
    let heroes = [];
    let heroItems = [];

    for (let i = 0; i < input.length; i++) {
        let inputArr = input[i].split(" / ");
        const heroName = inputArr[0];
        const heroLevel = Number(inputArr[1]);

        if (inputArr.length == 3) {
            heroItems = inputArr[2].split(", ");
        } 

        let hero = {
            name: heroName,
            level: heroLevel,
            items: heroItems,
        };
        heroes.push(hero);
    }

    return JSON.stringify(heroes);
}

console.log(solve(['Jake / 1000 ']));

console.log(solve(
    ['Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara']));
    
console.log(solve(['Jake / 1000 / Gauss, HolidayGrenade']));

