let {Repository} = require("./solution.js");
let {expect} = require('chai');

describe('', () => {
    it('constructor test 1', () => {
        let properties = {
            name: "string",
            age: "number",
            birthday: "1234"
        };

        let repo = new Repository(properties);
        let dataIsMap = repo.data instanceof Map;

        expect(repo.props).to.be.equal(properties);
        expect(repo.props.name).to.be.equal('string');
        expect(repo.props.age).to.be.equal('number');
        expect(repo.props.birthday).to.be.equal('1234');
        expect(dataIsMap).to.be.true;
        expect(repo.nextId()).to.equal(0);
        expect(repo.nextId()).to.equal(1);
    });

    it('get count test 1', () => {
        let repo = new Repository({});
        repo.add({});
        repo.add({});
        repo.add({});

        expect(repo.count).to.equal(3);
    });

    it('get count test 2', () => {
        let repo = new Repository({});
        expect(repo.count).to.equal(0);
    });

    it('add with valid entity 1', () => {
        let repo = new Repository({});
        let entity1 = {};
        let entity2 = {};

        repo.add(entity1);
        repo.add(entity2);

        expect(repo.getId(0)).to.equal(entity1);
        expect(repo.getId(1)).to.equal(entity2);
        expect(repo.data.get(0)).to.equal(entity1);
        expect(repo.data.get(1)).to.equal(entity2);
    });

    it('add with valid entity 2', () => {
        let repo = new Repository({name: 'number'});
        let entity1 = {name: 1};
        let entity2 = {name: 2};

        expect(repo.add(entity1)).to.equal(0);
        expect(repo.add(entity2)).to.equal(1);

        expect(repo.getId(0).name).to.equal(1);
        expect(repo.getId(1).name).to.equal(2);
    });

    it('add with invalid entity 1', () => {
        let repo = new Repository({name: 'string'});
        expect(() => repo.add({})).to.throw(Error,'Property name is missing from the entity!');
    });

    it('add with invalid entity 2', () => {
        let repo = new Repository({name: 'string'});
        expect(() => repo.add({name: 1})).to.throw(TypeError, 'Property name is not of correct type!');  // DIFFERENT
    });

    it('get id works', () => {
        let repo = new Repository({name: 'string'});
        let entity1 = {name: '1'};
        let entity2 = {name: '2'};
        repo.add(entity1);
        repo.add(entity2);

        expect(repo.getId(0)).to.equal(entity1);
        expect(repo.getId(1)).to.equal(entity2);
        expect(repo.getId(0).name).to.equal('1');
        expect(repo.getId(1).name).to.equal('2');
    });

    it('get with invalid id', () => {
        let repo = new Repository({});
        expect(() => repo.getId(0)).to.throw(Error,'Entity with id: 0 does not exist!');
    });

    it('update entity 1', () => {
        let repo = new Repository({name: 'string'});
        let newEntity = {name: '1'};
        repo.add({name: '2'});
        repo.add({name: '3'});
        repo.update(0, newEntity);

        expect(repo.count).to.equal(2);
        expect(repo.getId(0)).to.equal(newEntity);
        expect(repo.getId(0).name).to.equal(newEntity.name);
        expect(repo.getId(1).name).to.equal('3');
    });

    it('update entity with invalid id', () => {
        let repo = new Repository({});
        expect(() => repo.update(0)).to.throw(Error,'Entity with id: 0 does not exist!');
    });

    it('update with invalid new', () => {
        let repo = new Repository({name: 'number'});
        repo.add({name: 1});
        expect(() => repo.update(0, {})).to.throw(Error, 'Property name is missing from the entity!');
    });

    it('update with invalid new 2', () => {
        let repo = new Repository({name: 'number'});
        repo.add({name: 1});

        expect(() => repo.update(0, {name: ''})).to.throw(TypeError, 'Property name is not of correct type!');
    });

    it('del with valid id', () => {
       let repo = new Repository({age: 'number'});
       repo.add({age: 1});
       repo.add({age: 2});
       repo.del(1);
       expect(repo.count).to.equal(1);
       expect(() => repo.getId(0)).to.throw;
       expect(repo.getId(0).age).to.equal(1);
    });

    it('del with invalid id', () => {
        let repo = new Repository({});
        expect(() => repo.del(1)).to.throw(Error,'Entity with id: 1 does not exist!');
    });
});
