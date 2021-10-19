const { expect } = require('chai');

const createCalculator = require('./07. Add or Subtract');

describe('Calculator Tests', () => {
    it('return undefined for Red value is invalid', () => {
        expect(createCalculator()).to.be.undefined;
    });

});