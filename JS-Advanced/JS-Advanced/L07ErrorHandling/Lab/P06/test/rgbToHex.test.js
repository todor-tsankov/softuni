const rgbToHexColor = require('../rgbToHex');
const {expect} = require('chai');

describe('rgb to hex tests', () => {
    it('converts to red', () => {
        expect(rgbToHexColor(255, 0, 0)).to.equal('#FF0000');
    });

    it('converts to green', () => {
        expect(rgbToHexColor(0, 255, 0)).to.equal('#00FF00');
    });

    it('converts to blue', () => {
        expect(rgbToHexColor(0, 0, 255)).to.equal('#0000FF');
    });

    it('converts to lila', () => {
        expect(rgbToHexColor(169, 55, 12)).to.equal('#A9370C');
    });

    it('', () => {
        expect(rgbToHexColor(245, 56, 250)).to.equal('#F538FA');
    });

    it('r out of range up', () => {
        expect(rgbToHexColor(256, 0, 0)).to.be.undefined;
    });

    it('r out of range down', () => {
        expect(rgbToHexColor(-1, 0, 0)).to.be.undefined;
    });

    it('r not a number', () => {
        expect(rgbToHexColor('1', 0, 0)).to.be.undefined;
    });

    it('g out of range up', () => {
        expect(rgbToHexColor(0, 256, 0)).to.be.undefined;
    });

    it('g out of range down', () => {
        expect(rgbToHexColor(0, -1, 0)).to.be.undefined;
    });

    it('g not a number', () => {
        expect(rgbToHexColor(0, undefined, 0)).to.be.undefined;
    });

    it('blue out of range up', () => {
        it('b out of range', () => {
            expect(rgbToHexColor(0, 0, 256)).to.be.undefined;
        });
    });

    it('blue out of range down', () => {
        it('b out of range', () => {
            expect(rgbToHexColor(0, 0, -1)).to.be.undefined;
        });
    });

    it('blue not a number', () => {
        it('b out of range', () => {
            expect(rgbToHexColor(0, 0, undefined)).to.be.undefined;
        });
    });

    it('no parameters', () => {
        expect(rgbToHexColor()).to.be.undefined;
    });

    it('invalid parameter type', () => {
        expect(rgbToHexColor(1, 2, '1')).to.be.undefined;
    });

    it('invalid parameter type', () => {
        expect(rgbToHexColor(2, undefined, '1')).to.be.undefined;
    });
})