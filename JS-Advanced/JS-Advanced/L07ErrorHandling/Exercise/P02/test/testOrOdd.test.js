const isOddOrEven = require('../evenOrOdd');
const {expect} = require('chai');

describe('is even or odd tests', () => {
    it('empty string is even', () => {
        expect(isOddOrEven('')).to.equal('even');
    });

    it('string with two chars is even', () => {
        expect(isOddOrEven('ab')).to.equal('even');
    });

    it('string with one char is odd', () => {
        expect(isOddOrEven('a')).to.equal('odd');
    });

    it('string with three chars is ods', () => {
        expect(isOddOrEven('abc')).to.equal('odd');
    });

    it('returns undefined when the input is number', () => {
        expect(isOddOrEven(5)).to.be.undefined;
    });

    it('returns undefined when the input is undefined', () => {
        expect(isOddOrEven()).to.be.undefined;
    });

    it('returns undefined when the input is array', () => {
        expect(isOddOrEven([1, 2, 3])).to.be.undefined;
    });
})

