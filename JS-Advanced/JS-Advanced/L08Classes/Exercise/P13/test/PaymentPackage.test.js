const PaymentPackage = require('../PaymentPackage');
const {expect} = require('chai');

describe('constructor returns the correct object', () => {
    it('the pack has property name', () => {
        const pack = new PaymentPackage('name', 1);
        expect(pack).to.have.property('name', 'name');
    });

    it('the pack has property value', () => {
        const pack = new PaymentPackage('name', 1);
        expect(pack).to.have.property('value', 1);
    });

    it('the pack has property value', () => {
        const pack = new PaymentPackage('name', 1);
        expect(pack).to.have.property('VAT', 20);
    });

    it('the pack has property value', () => {
        const pack = new PaymentPackage('name', 1);
        expect(pack).to.have.property('active', true);
    });
});

describe('getters work correctly', () => {
    it('name getter returns the name', () => {
        const pack = new PaymentPackage('name123', 123);
        expect(pack.name).to.equal('name123');
    });

    it('name getter returns the value', () => {
        const pack = new PaymentPackage('name123', 123);
        expect(pack.value).to.equal(123);
    });

    it('VAT getter returns the VAT', () => {
        const pack = new PaymentPackage('name123', 123);
        expect(pack.VAT).to.equal(20);
    });

    it('active getter returns the active', () => {
        const pack = new PaymentPackage('name123', 123);
        expect(pack.active).to.be.true;
    });
});

describe('setters work correctly', () => {
    it('name setter works', () => {
        const pack = new PaymentPackage('name', 0);
        pack.name = 'changed';
        expect(pack.name).to.equal('changed');
    });

    it('value setter works', () => {
        const pack = new PaymentPackage('name', 0);
        pack.value = 69;
        expect(pack.value).to.equal(69);
    });

    it('VAT setter works', () => {
        const pack = new PaymentPackage('name', 0);
        pack.VAT = 60;
        expect(pack.VAT).to.equal(60);
    });

    it('active setter works', () => {
        const pack = new PaymentPackage('name', 0);
        pack.active = false;
        expect(pack.active).to.be.false;
    });

    it('active setter works 2', () => {
        const pack = new PaymentPackage('name', 0);
        pack.active = true;
        expect(pack.active).to.be.true;
    });
});

describe('toString works properly', () => {
    it('returns string when nothing is changed', () => {
        const pack = new PaymentPackage('test', 100);
        expect(pack.toString()).to.equal(`Package: test
- Value (excl. VAT): 100
- Value (VAT 20%): 120`);
    });

    it('returns string when name is changed', () => {
        const pack = new PaymentPackage('test', 100);
        pack.name = 'test1';

        expect(pack.toString()).to.equal(`Package: test1
- Value (excl. VAT): 100
- Value (VAT 20%): 120`);
    });

    it('returns string when value is changed', () => {
        const pack = new PaymentPackage('test', 100);
        pack.value = 1000;

        expect(pack.toString()).to.equal(`Package: test
- Value (excl. VAT): 1000
- Value (VAT 20%): 1200`);
    });

    it('returns string when VAT is changed', () => {
        const pack = new PaymentPackage('test', 1000);
        pack.VAT = 100;

        expect(pack.toString()).to.equal(`Package: test
- Value (excl. VAT): 1000
- Value (VAT 100%): 2000`);
    });

    it('returns string when active is changed', () => {
        const pack = new PaymentPackage('test3', 1000);
        pack.value = 10;
        pack.VAT = 1000;
        pack.active = false;

        expect(pack.toString()).to.equal(`Package: test3 (inactive)
- Value (excl. VAT): 10
- Value (VAT 1000%): 110`);
    });
});

describe('set name with invalid data', () => {
    it('empty name on constructor', () => {
        expect(() => new PaymentPackage('', 1)).to.throw('Name must be a non-empty string');
    });

    it('not string name on constructor', () => {
        expect(() => new PaymentPackage([], 1)).to.throw('Name must be a non-empty string');
    });

    it('empty name on set', () => {
        const pack = new PaymentPackage('name', 1);
        expect(() => pack.name = '').to.throw('Name must be a non-empty string');
    });

    it('not string name on set', () => {
        const pack = new PaymentPackage('name', 1);
        expect(() => pack.name = {}).to.throw('Name must be a non-empty string');
    });
});

describe('set value with invalid data', () => {
    it('negative value on constructor', () => {
        expect(() => new PaymentPackage('name', -1)).to.throw('Value must be a non-negative number');
    });

    it('not number value on constructor', () => {
        expect(() => new PaymentPackage('name')).to.throw('Value must be a non-negative number');
    });

    it('negative value on set', () => {
        const pack = new PaymentPackage('name', 0);
        expect(() => pack.value = -1).to.throw('Value must be a non-negative number');
    });

    it('not number value on set', () => {
        const pack = new PaymentPackage('name', 0);
        expect(() => pack.value = {}).to.throw('Value must be a non-negative number');
    });
});

describe('set VAT with invalid data', () => {
   it('negative VAT on set', () => {
       const pack = new PaymentPackage('name1234', 123);
       expect(() => pack.VAT = -1).to.throw('VAT must be a non-negative number');
   });

    it('not number VAT on set', () => {
        const pack = new PaymentPackage('name1234', 123);
        expect(() => pack.VAT = []).to.throw('VAT must be a non-negative number');
    });
});

describe('set active with invalid data', () => {
   it('not bool active on set', () => {
       const pack = new PaymentPackage('name', 0);
      expect(() => pack.active = []).to.throw('Active status must be a boolean');
   });

    it('not bool active on set', () => {
        const pack = new PaymentPackage('name', 0);
        expect(() => pack.active = undefined).to.throw('Active status must be a boolean');
    });
});