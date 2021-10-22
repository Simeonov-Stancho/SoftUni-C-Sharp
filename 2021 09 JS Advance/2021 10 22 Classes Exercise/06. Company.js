class Company {
    constructor() {
        this.departments = [];
    }

    addEmployee(name, salary, position, department) {
        if (!name ||
            !position ||
            !department ||
            !salary ||
            Number(salary) < 0) {

            throw new Error("Invalid input!");
        }

        let employee = {
            name: name,
            salary: Number(salary),
            position: position
        };

        if (!this.departments[department]) {
            this.departments[department] = []
        }

        this.departments[department].push(employee);
        return `New employee is hired. Name: ${name}. Position: ${position}`;
    }

    bestDepartment() {
        let bestDepartment = '';
        let maxAverageSalary = 0;

        Object.entries(this.departments).forEach(d => {
            let currentDepSalarySum = 0;
            let currentAverageSalary = 0;

            d[1].forEach(e => {
                currentDepSalarySum += e.salary;

            });

            currentAverageSalary = (currentDepSalarySum / d[1].length) || 0;

            if (maxAverageSalary < currentAverageSalary) {
                maxAverageSalary = currentAverageSalary;
                bestDepartment = d[0];
            }
        });

        if (bestDepartment != '') {
            let bestDepartInfo = `Best Department is: ${bestDepartment}\nAverage salary: ${maxAverageSalary.toFixed(2)}\n`;
            Object.values(this.departments[bestDepartment]).sort((a, b) => b.salary - a.salary || a.name.localeCompare(b.name)).forEach(e => {
                let currentEmployy = `${e.name} ${e.salary} ${e.position}\n`;
                bestDepartInfo += currentEmployy;
            })
            return bestDepartInfo.trim();
        }
    }
}

let c = new Company();
c.addEmployee("Stanimir", 2000, "engineer", "Construction");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.bestDepartment());