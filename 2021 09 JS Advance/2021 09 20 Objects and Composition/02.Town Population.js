function solve(townsArray) {
    let towns = {};
    let townsOutput = [];

    for (const town of townsArray) {
        let townInfo = town.split(` <-> `);
        let townName = townInfo[0];
        let townPopulation = Number(townInfo[1]);

        if (towns[townName] != undefined) {
            townPopulation += towns[townName];
        }

        towns[townName] = townPopulation;
    }

    for (const town in towns) {
        townsOutput.push(`${town} : ${towns[town]}`);
    }
    return townsOutput.join(`\n`);
}

console.log(solve(
    ['Sofia <-> 1200000',
        'Montana <-> 20000',
        'New York <-> 10000000',
        'Washington <-> 2345000',
        'Las Vegas <-> 1000000']));

console.log(solve(
    ['Istanbul <-> 100000',
        'Honk Kong <-> 2100004',
        'Jerusalem <-> 2352344',
        'Mexico City <-> 23401925',
        'Istanbul <-> 1000']));