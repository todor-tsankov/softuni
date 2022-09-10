const isSymmetric = require('../checkForSymmetry');
const {expect} = require('chai');

describe('checkForSymmetry tests', () => {
    it('empty array is symmetric', () => {
        expect(isSymmetric([])).to.be.true;
    });

    it('single element array is symmetric', () => {
        expect(isSymmetric([1])).to.be.true;
    });

    it('singles string element array is symmetric', () => {
        expect(isSymmetric(['1'])).to.be.true;
    });

    it('odd array is symmetric', () => {
        expect(isSymmetric([1, 2, 1])).to.be.true;
    });

    it('even array is symmetric', () => {
        expect(isSymmetric(['1', '1'])).to.be.true;
    });

    it('array with different el types is symmetric', () => {
        expect(isSymmetric(['1', 2, '1'])).to.be.true;
    });

    it('array with different el types is not symmetric', () => {
        expect(isSymmetric(['1', 1])).to.be.false;
    });

    it('even array is not symmetric', () => {
        expect(isSymmetric([1, 2])).to.be.false;
    });

    it('odd array is not symmetric', () => {
        expect(isSymmetric(['1', '2', '3'])).to.be.false;
    });

    it('not array is not symmetric', () => {
        expect(isSymmetric('a')).to.be.false;
    });

    it('not array is not symmetric', () => {
        expect(isSymmetric(1)).to.be.false;
    });
})