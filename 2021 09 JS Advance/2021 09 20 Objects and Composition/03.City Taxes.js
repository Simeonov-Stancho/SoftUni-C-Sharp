function solve(name, population, treasury) {
    return {
        name: name,
        population: Number(population),
        treasury: Number(treasury),
        taxRate: 10,
        collectTaxes() { this.treasury += this.population * this.taxRate },
        applyGrowth(percentage) { this.population += Math.floor(this.population * percentage / 100) },
        applyRecession(percentage) { this.treasury -= Math.floor(this.treasury * percentage / 100) },
    };
}

solve("Tortuga", 7000, 15000);

