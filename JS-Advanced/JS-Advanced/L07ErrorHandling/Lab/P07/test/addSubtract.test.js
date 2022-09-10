const createCalculator = require('../addSubtract');
const {expect} = require('chai');

describe('add subtract tests', () => {
    it('returned object contains add', () => {
       expect( typeof createCalculator().add).to.equal('function');
    });

    it('returned object contains subtract', () => {
        expect( typeof createCalculator().subtract).to.equal('function');
    });

    it('returned object contains get', () => {
        expect( typeof createCalculator().get).to.equal('function');
    });

    it('returned object add works single time', () => {
        let obj = createCalculator();
        obj.add(1);

        expect(obj.get()).to.equal(1);
    });

    it('returned object subtract works single time', () => {
        let obj = createCalculator();
        obj.subtract(-1);

        expect(obj.get()).to.equal(1);
    });

    it('returned object get works single time', () => {
        let obj = createCalculator();

        expect(obj.get()).to.equal(0);
    });


    it('returned object add works multiple times', () => {
        let obj = createCalculator();
        obj.add(1);
        obj.add(1);

        expect(obj.get()).to.equal(2);
    });

    it('returned object subtract works single multiple times', () => {
        let obj = createCalculator();
        obj.subtract(-1);
        obj.subtract(-1);

        expect(obj.get()).to.equal(2);
    });

    it('returned object get works single multiple times', () => {
        let obj = createCalculator();
        obj.get();

        expect(obj.get()).to.equal(0);
    });

    it('returned object add works single time with string', () => {
        let obj = createCalculator();
        obj.add('1');

        expect(obj.get()).to.equal(1);
    });

    it('returned object subtract works single time with string', () => {
        let obj = createCalculator();
        obj.subtract('-1');

        expect(obj.get()).to.equal(1);
    });
});