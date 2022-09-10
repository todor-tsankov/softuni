const StringBuilder = require('../StringBuilder');
const {expect} = require('chai');

describe('constructor tests', () => {
    it('returns instance of StringBuilder', () => {
        const builder = new StringBuilder();
        const isInstance = builder instanceof StringBuilder;
        expect(isInstance).to.be.true;
    });

    it('creates object with a given string', () => {
        const builder = new StringBuilder('str');
        expect(builder.toString()).to.equal('str');
    });

    it('creates object without anything', () => {
        const builder = new StringBuilder();
        expect(builder.toString()).to.equal('');
    });

    it('throws if the input is not string 1', () => {
        expect(() => new StringBuilder([])).to.throw('Argument must be a string');
    });

    it('throws if the input is not string 2', () => {
        expect(() => new StringBuilder({})).to.throw('Argument must be a string');
    });
});

describe('append tests', () => {
    it('appends the message on empty builder', () => {
        const stringBuilder = new StringBuilder();
        stringBuilder.append('toshko');

        expect(stringBuilder.toString()).to.equal('toshko');
    });

    it('appends the message non empty builder', () => {
        const stringBuilder = new StringBuilder('123');
        stringBuilder.append('toshko123');

        expect(stringBuilder.toString()).to.equal('123toshko123');
    });

    it('throws if the input is not string', () => {
        const stringBuilder = new StringBuilder();
        expect(() => stringBuilder.append(undefined)).to.throw('Argument must be a string');
    });

    it('throws if the input is not string 2', () => {
        const stringBuilder = new StringBuilder();
        expect(() => stringBuilder.append(1)).to.throw('Argument must be a string');
    });
});

describe('prepend tests', () => {
    it('prepends the message on empty builder', () => {
        const stringBuilder = new StringBuilder();
        stringBuilder.prepend('123');

        expect(stringBuilder.toString()).to.equal('123');
    });

    it('prepends the message on non empty builder', () => {
        const stringBuilder = new StringBuilder('toshko1');
        stringBuilder.prepend('123');

        expect(stringBuilder.toString()).to.equal('123toshko1');
    });

    it('throws if input is not a string', () => {
        const stringBuilder = new StringBuilder();

        expect(() => stringBuilder.prepend()).to.throw('Argument must be a string');
    });

    it('throws if input is not a string 2', () => {
        const stringBuilder = new StringBuilder('name');

        expect(() => stringBuilder.prepend([])).to.throw('Argument must be a string');
    });
});

describe('insert at tests', () => {
   it('inserts at the index on empty builder', () => {
       const stringBuilder = new StringBuilder();
       stringBuilder.insertAt('tosh', 0);

       expect(stringBuilder.toString()).to.equal('tosh');
   });

    it('inserts at the index on non empty builder', () => {
        const stringBuilder = new StringBuilder('1236');
        stringBuilder.insertAt('45', 3);

        expect(stringBuilder.toString()).to.equal('123456');
    });

    it('inserts at the negative index on non empty builder', () => {
        const stringBuilder = new StringBuilder('1236');
        stringBuilder.insertAt('45', -1);

        expect(stringBuilder.toString()).to.equal('123456');
    });

    it('throws if input is not a string', () => {
        const stringBuilder = new StringBuilder();
        expect(() => stringBuilder.insertAt(undefined, 0)).to.throw('Argument must be a string');
    });

    it('throws if input is not a string 2', () => {
        const stringBuilder = new StringBuilder();
        expect(() => stringBuilder.insertAt(1, 0)).to.throw('Argument must be a string');
    });
});

describe('remove tests', () => {
   it('removes on empty builder', () => {
       const stringBuilder = new StringBuilder();
       stringBuilder.remove(1, 5);

       expect(stringBuilder.toString()).to.equal('');
   });

    it('removes on non empty builder', () => {
        const stringBuilder = new StringBuilder('0123456789');
        stringBuilder.remove(1, 5);

        expect(stringBuilder.toString()).to.equal('06789');
    });

    it('removes everything on indexes outside', () => {
        const stringBuilder = new StringBuilder('0123456789');
        stringBuilder.remove(0, 15);

        expect(stringBuilder.toString()).to.equal('');
    });

    it('remove with negative index', () => {
        const stringBuilder = new StringBuilder('0123456789');
        stringBuilder.remove(-1, 2);

        expect(stringBuilder.toString()).to.equal('012345678');
    });
});

describe('complete tests', () => {
   it('', () => {
       const builder = new StringBuilder();
       builder.append('toshko');
       builder.prepend('123');
       builder.append('1234');
       builder.remove(1, 5);
       builder.insertAt('5', -1);

       expect(builder.toString()).to.equal('1hko12354');
   }) ;
});