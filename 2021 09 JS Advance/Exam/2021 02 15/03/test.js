const {dealership} = require('./dealership');
const {expect} = require('chai');

describe('Dealership Tests', () => {
    describe('newCarCost', () => {
        it('work with oldCar without Discount', () => {
            expect(dealership.newCarCost('Nqma takava', 49000)).to.be.equal(49000);
        });

        it('work with oldCar with Discount', () => {
            expect(dealership.newCarCost('Audi A4 B8', 45000)).to.be.equal(30000);
        });

        it('work with oldCar without Discount', () => {
            expect(dealership.newCarCost('Audi A4', 45000)).to.be.equal(45000);
        });
    });

    describe('carEquipment', () => {
        it('work', () => {
            expect(dealership.carEquipment(['first', 'second', 'third'], [0, 2])).deep.to.equal(['first', 'third']);
        });
    });

    describe('euroCategory', () => {
        it('work with 0 category', () => {
            expect(dealership.euroCategory(0)).to.be.equal('Your euro category is low, so there is no discount from the final price!');
        });

        it('work with 4 category', () => {
            expect(dealership.euroCategory(4)).to.be.equal(`We have added 5% discount to the final price: 14250.`);
        });
    });
});