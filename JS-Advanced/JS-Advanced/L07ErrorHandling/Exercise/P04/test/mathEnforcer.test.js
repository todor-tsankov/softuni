const mathEnforcer = require('../mathEnforcer');
const {expect} = require('chai');

describe('math enforcer tests', () => {
    it('add five test 1', () => {
        expect(mathEnforcer.addFive(0)).to.equal(5);
    });

    it('add five test 2', () => {
        expect(mathEnforcer.addFive(5.5)).to.equal(10.5);
    });

    it('add five test 3', () => {
        expect(mathEnforcer.addFive(-5)).to.equal(0);
    });

    it('add five invalid arg 1', () => {
        expect(mathEnforcer.addFive('0')).to.be.undefined;
    });

    it('add five invalid arg 1', () => {
        expect(mathEnforcer.addFive([1])).to.be.undefined;
    });

    it('subtract ten test 1', () => {
        expect(mathEnforcer.subtractTen(10)).to.equal(0);
    });

    it('subtract ten test 2', () => {
        expect(mathEnforcer.subtractTen(0.5)).to.equal(-9.5);
    });

    it('subtract ten test 3', () => {
        expect(mathEnforcer.subtractTen(-5)).to.equal(-15);
    });

    it('subtract ten invalid arg 1', () => {
        expect(mathEnforcer.subtractTen('1')).to.be.undefined;
    });

    it('subtract ten invalid arg 2', () => {
        expect(mathEnforcer.subtractTen([1])).to.be.undefined;
    });

    it('sum test 1', () => {
        expect(mathEnforcer.sum(1, 2)).to.equal(3);
    });

    it('sum test 2', () => {
        expect(mathEnforcer.sum(1.5, 2.2)).to.equal(3.7);
    });

    it('sum test 3', () => {
        expect(mathEnforcer.sum(-1, -2)).to.equal(-3);
    });

    it('sum invalid 1st arg 1', () => {
        expect(mathEnforcer.sum('1', 1)).to.be.undefined;
    });

    it('sum invalid 1st arg 2', () => {
        expect(mathEnforcer.sum([1], 1)).to.be.undefined;
    });

    it('sum invalid 2st arg 1', () => {
        expect(mathEnforcer.sum(1, '1')).to.be.undefined;
    });

    it('sum invalid 2st arg 2', () => {
        expect(mathEnforcer.sum(1, [1])).to.be.undefined;
    });
})