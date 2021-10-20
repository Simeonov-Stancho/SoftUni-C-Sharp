const isOddOrEven = require('./function');
const {expect} = require('chai');

describe('Even or Odd Test', () => {
    it('should return undefined with not a string', () => {
        expect(isOddOrEven([1, 3, 'dd'])).to.be.undefined;
    });

    it('should return undefined with number', () => {
        expect(isOddOrEven(13)).to.be.undefined;
    });

    it('should return undefined', () => {
        expect(isOddOrEven()).to.be.undefined;
    });

    it('should return even', () => {
        expect(isOddOrEven('lala')).to.equal('even');
    });

    it('should return odd', () => {
        expect(isOddOrEven('tralala')).to.equal('odd');
    });

    it('test with multiple different strings ', () => {
        expect(isOddOrEven('multiple different strings')).to.equal('even');
    });
});