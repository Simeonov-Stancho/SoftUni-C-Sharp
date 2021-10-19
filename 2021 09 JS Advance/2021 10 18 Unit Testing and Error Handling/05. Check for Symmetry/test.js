const { expect } = require('chai');

const isSymmetric = require('./05. Check for Symmetry');

describe('isSymmetric Tests', () => {
    it('return false for not array', () => {
        expect(isSymmetric(13)).to.be.false;
    });

    it('return true for symmetric', () => {
        expect(isSymmetric([1, 2, 2, 1])).to.true;
    });

    it('return true for symmetric with 3 el', () => {
        expect(isSymmetric([1, 2, 1])).to.true;
    });

    it('return true for symmetric of char', () => {
        expect(isSymmetric(['a', 'b', 'b', 'a'])).to.true;
    });

    it('return false for not symmetric', () => {
        expect(isSymmetric([1, 2, 3, 1])).to.false;
    });

    it('return false for not symmetric', () => {
        expect(isSymmetric([1, 2, '2', '1'])).to.false;
    });
});