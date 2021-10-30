const { numberOperations } = require('./03. Number Operations_Resources');
const { expext, expect } = require('chai');

describe('Number Operations', () => {
    describe('powNumber', () => {
        it('work', () => {
            expect(numberOperations.powNumber(5)).to.be.equal(25);
        });

        it('work with 0', () => {
            expect(numberOperations.powNumber(0)).to.be.equal(0);
        });

        it('work with -5', () => {
            expect(numberOperations.powNumber('-5')).to.be.equal(25);
        });
    });

    describe('numberChecker', () => {
        it('work with number >= 100', () => {
            expect(numberOperations.numberChecker(100)).to.be.equal("The number is greater or equal to 100!");
        });

        it('work with number < 100', () => {
            expect(numberOperations.numberChecker(99)).to.be.equal("The number is lower than 100!");
        });

        it('work with number < 100', () => {
            expect(numberOperations.numberChecker('99')).to.be.equal("The number is lower than 100!");
        });

        it('work with number < 100', () => {
            expect(numberOperations.numberChecker('-99')).to.be.equal("The number is lower than 100!");
        });

        it('throw err with NaN', () => {
            expect(() => numberOperations.numberChecker('dsaasd')).to.throw('The input is not a number!');
        });
    });

    describe('sumArrays', () => {
        it('work ', () => {
            expect(numberOperations.sumArrays([1, 2, 3], [1, 2, 3])).deep.to.equal([2, 4, 6]);
        });

        it('work ', () => {
            expect(numberOperations.sumArrays([1], [1, 2, 3])).deep.to.equal([2, 2, 3]);
        });

        it('work ', () => {
            expect(numberOperations.sumArrays([1, 2, 3, 4, 6], [1, 2])).deep.to.equal([2, 4, 3, 4, 6]);
        });
    });
});