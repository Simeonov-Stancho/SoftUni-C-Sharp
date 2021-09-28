function solve(inputArr) {
    let towns = [];
    
    for (let i = 1; i < inputArr.length; i++) {
        let town = { };

        let [x, townName, latitude, longitude] = inputArr[i].split(/\s*\|\s*/gim);
        town.Town = townName;
        town.Latitude = Number(Number(latitude).toFixed(2));
        town.Longitude = Number(Number(longitude).toFixed(2));

        towns.push(town);
    }

    return JSON.stringify(towns);
}

console.log(solve(
    ['| Town | Latitude | Longitude |',
'| Sofia | 42.696552 | 23.32601 |',
'| Beijing | 39.913818 | 116.363625 |']));

console.log(solve(
    ['| Town | Latitude | Longitude |',
    '| Veliko Turnovo | 43.0757 | 25.6172 |',
    '| Monatevideo | 34.50 | 56.11 |'    ]));