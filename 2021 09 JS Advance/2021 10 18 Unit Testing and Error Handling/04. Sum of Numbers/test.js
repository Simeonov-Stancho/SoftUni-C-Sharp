const { expect } = require('chai');

const sum = require('./04. Sum of Numbers');

describe('Testove', () => {
    it('return correct sum', () => {
        expect(sum([1, 2, 3])).to.equal(6);
    });

    it('return NaN', () => {
        expect(sum([ 1 , 'b', 'c'])).to.NaN;
    });

    it('sum one element', () => {
        expect(sum([5])).to.equal(5);
    });
});