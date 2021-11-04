const { testNumbers } = require('./testNumbers');
const { expect } = require('chai');

describe('Test Numbers', () => {
    describe('sumNumbers', () => {
        it('with valid numbers', () => {
            expect(testNumbers.sumNumbers(5, 5)).to.be.equal('10.00');
        });

        it('with valid negativ numbers', () => {
            expect(testNumbers.sumNumbers(5, -5)).to.be.equal('0.00');
        });

        it('with valid negativ numbers', () => {
            expect(testNumbers.sumNumbers(-5, 5)).to.be.equal('0.00');
        });

        it('with valid two negativ numbers', () => {
            expect(testNumbers.sumNumbers(-5, -5)).to.be.equal('-10.00');
        });

        it('with valid numbers', () => {
            expect(testNumbers.sumNumbers(1, -5)).to.be.equal('-4.00');
        });

        it('with chars', () => {
            expect(testNumbers.sumNumbers('5', '5')).to.be.undefined;
        });

        it('with strings', () => {
            expect(testNumbers.sumNumbers('5aa', '5cs')).to.be.undefined;
        });
    });

    describe('numberChecker', () => {
        it('with zero', () => {
            expect(testNumbers.numberChecker(0)).to.be.equal('The number is even!');
        });

        it('with even number', () => {
            expect(testNumbers.numberChecker(2)).to.be.equal('The number is even!');
        });

        it('with odd num', () => {
            expect(testNumbers.numberChecker(3)).to.be.equal('The number is odd!');
        });

        it('with odd num', () => {
            expect(testNumbers.numberChecker('3')).to.be.equal('The number is odd!');
        });

        it('with not a number', () => {
            expect(() => testNumbers.numberChecker('abc')).to.throw("The input is not a number!");
        });
    });

    describe('averageSumArray', () => {
        it('with 3 numbers', () => {
            expect(testNumbers.averageSumArray([1, 2, 3])).to.be.equal(2);
        });

        it('with 4 numbers', () => {
            expect(testNumbers.averageSumArray([1, 2, 3, 4])).to.be.equal(2.5);
        });
    });
});