function solve(name, population, treasury){
    const city = {
        name: name,
        population: Number(population),
        treasury: Number(treasury),
    };
    
    return city;
}

console.log(solve("Tortuga", 7000, 15000));
console.log(solve("Santo Domingo", 12000, 23500));