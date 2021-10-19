const { expect } = require('chai');

const rgbToHexColor = require('./06. RGB to Hex');

describe('rgbToHexColor Tests', () => {
    it('return undefined for Red value is invalid', () => {
        expect(rgbToHexColor('13', 2, 99)).to.be.undefined;
    });

    it('return undefined for Red value is double', () => {
        expect(rgbToHexColor(13.5, 2, 99)).to.be.undefined;
    });

    it('return undefined for Red value is minus number', () => {
        expect(rgbToHexColor(-10, 2, 99)).to.be.undefined;
    });

    it('return undefined for Red value is out of range', () => {
        expect(rgbToHexColor(2550, 2, 99)).to.be.undefined;
    });

    it('return undefined for Green value is invalid', () => {
        expect(rgbToHexColor(2, '13', 99)).to.be.undefined;
    });

    it('return undefined for Green value is double', () => {
        expect(rgbToHexColor(2, 13.5, 99)).to.be.undefined;
    });

    it('return undefined for Green value is minus number', () => {
        expect(rgbToHexColor(2, -10, 99)).to.be.undefined;
    });

    it('return undefined for Green value is  out of range', () => {
        expect(rgbToHexColor(2, 2550, 99)).to.be.undefined;
    });

    it('return undefined for Blue value is invalid', () => {
        expect(rgbToHexColor(2, 99, '13')).to.be.undefined;
    });

    it('return undefined for Blue value is double', () => {
        expect(rgbToHexColor(2, 99, 13.5)).to.be.undefined;
    });

    it('return undefined for Blue value is minus', () => {
        expect(rgbToHexColor(2, 99, -10)).to.be.undefined;
    });

    it('return undefined for Blue value is  out of range', () => {
        expect(rgbToHexColor(2, 99, 2500)).to.be.undefined;
    });

    it('return undefined for ivalid type Array', () => {
        expect(rgbToHexColor([12, 14, 55])).to.be.undefined;
    });

    it('return undefined for invalid input', () => {
        expect(rgbToHexColor(1, 256)).to.be.undefined;
    });

    it('return correct string', () => {
        expect(rgbToHexColor(15, 17, 25)).to.be.equal('#0F1119');
    });
    it('return correct string', () => {
        expect(rgbToHexColor(0, 0, 0)).to.be.equal('#000000');
    });

    it(`test saturation from specs -> (255, 158, 170) -> #FF9EAA`, () => {
        expect(rgbToHexColor(255, 158, 170)).to.equals('#FF9EAA')
    })
});