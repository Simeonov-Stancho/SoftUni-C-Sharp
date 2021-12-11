const { expect } = require('chai');

const { companyAdministration } = require('./companyAdministration');

describe('Tests CompanyAdministration', () => {
    describe('hiringEmployee', () => {
        it('invalid possition', () => {
            expect(() => companyAdministration.hiringEmployee('Dimi', 'Prog', 7)).to.throw(`We are not looking for workers for this position.`);
        });

        it('vaid input yearsЕxperience = 3', () => {
            expect(companyAdministration.hiringEmployee('Dimi', 'Programmer', 3)).to.be.equal(`Dimi was successfully hired for the position Programmer.`);
        });

        it('vaid input yearsЕxperience > 15', () => {
            expect(companyAdministration.hiringEmployee('Dimi', 'Programmer', 15)).to.be.equal(`Dimi was successfully hired for the position Programmer.`);
        });
        
        it('vaid input yearsЕxperience < 3', () => {
            expect(companyAdministration.hiringEmployee('Dimi', 'Programmer', 2)).to.be.equal(`Dimi is not approved for this position.`);
        });
    });

    describe('calculateSalary ', () => {
        it('hours are char', () => {
            expect(() => companyAdministration.calculateSalary('1')).to.throw("Invalid hours");
        }); 

        it('hours are string', () => {
            expect(() => companyAdministration.calculateSalary('abc1hours')).to.throw("Invalid hours");
        }); 

        it('hours are undefined', () => {
            expect(() => companyAdministration.calculateSalary(undefined)).to.throw("Invalid hours");
        });

        it('hours are negative num', () => {
            expect(() => companyAdministration.calculateSalary(-1)).to.throw("Invalid hours");
        });    
        
        it('vaid input hours int', () => {
            expect(companyAdministration.calculateSalary(1)).to.be.equal(15);
        });

        it('vaid input hours double', () => {
            expect(companyAdministration.calculateSalary(1.5)).to.be.equal(22.50);
        });

        it('vaid input hours equal of 160', () => {
            expect(companyAdministration.calculateSalary(160)).to.be.equal(2400);
        });

        it('vaid input hours more than 160', () => {
            expect(companyAdministration.calculateSalary(161)).to.be.equal(3415);
        });
    });

    describe('firedEmployee', () => {
        it('invalid index negative num', () => {
            expect(() => companyAdministration.firedEmployee(['Petar', 'Ivan'], -1)).to.throw("Invalid input");
        });

        it('invalid index out', () => {
            expect(() => companyAdministration.firedEmployee(['Petar', 'Ivan'], 2)).to.throw("Invalid input");
        });

        it('invalid index undefined', () => {
            expect(() => companyAdministration.firedEmployee(['Petar', 'Ivan'], undefined)).to.throw("Invalid input");
        });

        it('invalid index string', () => {
            expect(() => companyAdministration.firedEmployee(['Petar', 'Ivan'], '1')).to.throw("Invalid input");
        });

        it('invalid array', () => {
            expect(() => companyAdministration.firedEmployee('Petar', 0)).to.throw("Invalid input");
        });

        it('invalid empty array', () => {
            expect(() => companyAdministration.firedEmployee([], 0)).to.throw("Invalid input");
        });
        
        it('valid input', () => {
            expect(companyAdministration.firedEmployee(['Petar', 'Ivan', 'Dimi'], 0)).to.equal("Ivan, Dimi");
        });

        it('valid input', () => {
            expect(companyAdministration.firedEmployee(['Petar', 'Ivan', 'Dimi'], 2)).to.equal("Petar, Ivan");
        });
    });
});