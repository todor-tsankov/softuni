const sum = require('../sumOfNumbers');
const {expect} = require('chai');

describe('sum tests', () => {
   it('sums single element array', () => {
         expect(sum([1])).to.equal(1);
   });

   it('sums multiple element array', () => {
      expect(sum([1, 2])).to.equal(3);
   });

   it('sums empty array', () => {
      expect(sum([])).to.equal(0);
   });
});