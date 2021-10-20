const lookupChar = require('./function');
const {expect} = require('chai');

describe('Char Lookup Tests', () => {
    it('should return undefined with not a string', () => {
        expect(lookupChar(13, 3)).to.be.undefined;
    });

    it('should return undefined with not a string', () => {
        expect(lookupChar("string", 'not a number')).to.be.undefined;
    });

    it('should return undefined no args', () => {
        expect(lookupChar()).to.be.undefined;
    });

    it('should return undefined with double for index', () => {
        expect(lookupChar('string', 5.5)).to.be.undefined;
    });

    it('should return Incorrect index negativ index', () => {
        expect(lookupChar("string", -1)).to.equal('Incorrect index');
    });

    it('should return Incorrect index out of range index', () => {
        expect(lookupChar("string", 6)).to.equal('Incorrect index');
    });

    it('should return s in 0 index', () => {
        expect(lookupChar("string", 0)).to.equal('s');
    });

    it('should return s in g index', () => {
        expect(lookupChar("string", 5)).to.equal('g');
    });
});