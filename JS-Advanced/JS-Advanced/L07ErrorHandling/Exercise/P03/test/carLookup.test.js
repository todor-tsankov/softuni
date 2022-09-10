const lookupChar = require('../carLookup');
const {expect} = require('chai');

describe('char lookup tests', () => {
    it('the first char is a', () => {
       expect(lookupChar('abc', 0)).to.equal('a');
    });

    it('the second char is b', () => {
        expect(lookupChar('ab', 1)).to.equal('b');
    });

    it('the middle char is b', () => {
        expect(lookupChar('abc', 1)).to.equal('b');
    });

    it('the first parameter is not a string so return undefined', () => {
        expect(lookupChar(1, 1)).to.be.undefined;
    });

    it('the second parameter is not a number so return undefined', () => {
        expect(lookupChar('a', 'a')).to.be.undefined;
    });

    it('the second parameter is not an integer so return undefined', () => {
        expect(lookupChar('a', 1.1)).to.be.undefined;
    });

    it('negative index returns message', () => {
       expect(lookupChar('a', -1)).to.equal('Incorrect index');
    });

    it('bigger index returns message', () => {
        expect(lookupChar('a', 1)).to.equal('Incorrect index');
    });
})