const { mathEnforcer } = require('./function');
const { expect } = require('chai');

describe('MathEnforcer Tests', () => {
    describe('addFive', () => {

        it('test method addFive with not a num', () => {
            expect(mathEnforcer.addFive('string')).to.be.undefined;
        });

        it('test method addFive with undefined', () => {
            expect(mathEnforcer.addFive(undefined)).to.be.undefined;
        });

        it('test method addFive with a num', () => {
            expect(mathEnforcer.addFive(5)).to.be.equal(10);
        });

        it('test method addFive with a num', () => {
            expect(mathEnforcer.addFive(0)).to.be.equal(5);
        });

        it('test method addFive with a negative num', () => {
            expect(mathEnforcer.addFive(-5)).to.be.equal(0);
        });

        it('test method addFive with a double', () => {
            expect(mathEnforcer.addFive(5.6333)).to.be.closeTo(10.63, 0.01);
        });
    })

    describe('subtractTen', () => {

        it('test method subtractTen with not a num', () => {
            expect(mathEnforcer.subtractTen('string')).to.be.undefined;
        });

        it('test method subtractTen with undefined', () => {
            expect(mathEnforcer.subtractTen(undefined)).to.be.undefined;
        });

        it('test method subtractTen with a num', () => {
            expect(mathEnforcer.subtractTen(5)).to.be.equal(-5);
        });

        it('test method subtractTen with a num 0', () => {
            expect(mathEnforcer.subtractTen(0)).to.be.equal(-10);
        });

        it('test method subtractTen with a negativ num', () => {
            expect(mathEnforcer.subtractTen(-15)).to.be.equal(-25);
        });

        it('test method subtractTen with a double', () => {
            expect(mathEnforcer.subtractTen(5.633)).to.be.closeTo(-4.37, 0.01);
        });
    })

    describe('sum', () => {

        it('test method sum with not a num for first param', () => {
            expect(mathEnforcer.sum('string', 10)).to.be.undefined;
        });

        it('test method sum with not a num for second param', () => {
            expect(mathEnforcer.sum(10, 'string')).to.be.undefined;
        });

        it('test method sum with not a num for first param', () => {
            expect(mathEnforcer.sum(undefined, undefined)).to.be.undefined;
        });

        it('test method sum with not a num for first param', () => {
            expect(mathEnforcer.sum(10)).to.be.undefined;
        });

        it('test method sum with a num', () => {
            expect(mathEnforcer.sum(10, 20)).to.be.equal(30);
        });

        it('test method sum with a num 0 and 0', () => {
            expect(mathEnforcer.sum(0, 0)).to.be.equal(0);
        });

        it('test method sum with a two negative num', () => {
            expect(mathEnforcer.sum(-57, -3)).to.be.equal(-60);
        });

        it('test method sum with a double', () => {
            expect(mathEnforcer.sum(5.633, 4.333)).to.be.closeTo(9.97, 0.01);
        });
    })
});