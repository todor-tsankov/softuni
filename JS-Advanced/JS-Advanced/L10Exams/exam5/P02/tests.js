class HolidayPackage {
    constructor(destination, season) {
        this.vacationers = [];
        this.destination = destination;
        this.season = season;
        this.insuranceIncluded = false; // Default value
    }

    showVacationers() {
        if (this.vacationers.length > 0)
            return "Vacationers:\n" + this.vacationers.join("\n");
        else
            return "No vacationers are added yet";
    }

    addVacationer(vacationerName) {
        if (typeof vacationerName !== "string" || vacationerName === ' ') {
            throw new Error("Vacationer name must be a non-empty string");
        }
        if (vacationerName.split(" ").length !== 2) {
            throw new Error("Name must consist of first name and last name");
        }
        this.vacationers.push(vacationerName);
    }

    get insuranceIncluded() {
        return this._insuranceIncluded;
    }

    set insuranceIncluded(insurance) {
        if (typeof insurance !== 'boolean') {
            throw new Error("Insurance status must be a boolean");
        }
        this._insuranceIncluded = insurance;
    }

    generateHolidayPackage() {
        if (this.vacationers.length < 1) {
            throw new Error("There must be at least 1 vacationer added");
        }
        let totalPrice = this.vacationers.length * 400;

        if (this.season === "Summer" || this.season === "Winter") {
            totalPrice += 200;
        }

        totalPrice += this.insuranceIncluded === true ? 100 : 0;

        return "Holiday Package Generated\n" +
            "Destination: " + this.destination + "\n" +
            this.showVacationers() + "\n" +
            "Price: " + totalPrice;
    }
}

const {expect} = require('chai');

describe('', () => {
    it('contructor 1', () => {
        let holidayPackage = new HolidayPackage('1', '1');

        expect(holidayPackage.destination).to.equal('1');
        expect(holidayPackage.season).to.equal('1');
        expect(holidayPackage.insuranceIncluded).to.equal(false);
        expect(typeof holidayPackage.vacationers).to.equal('object');
    });

    it('insurance get set 1', () => {
        let holidayPackage = new HolidayPackage('1', '1');
        expect(holidayPackage.insuranceIncluded).to.be.false;
        holidayPackage.insuranceIncluded = true;
        expect(holidayPackage.insuranceIncluded).to.be.true;
    });

    it('insurance throws on set', () => {
        let holidayPackage = new HolidayPackage('1', '1');
        expect(() => holidayPackage.insuranceIncluded = 1).to.throw(Error, 'Insurance status must be a boolean');
        expect(() => holidayPackage.insuranceIncluded = '1').to.throw(Error, 'Insurance status must be a boolean');
        expect(() => holidayPackage.insuranceIncluded = undefined).to.throw(Error, 'Insurance status must be a boolean');
        expect(() => holidayPackage.insuranceIncluded = {}).to.throw(Error, 'Insurance status must be a boolean');
    });

    it('add vacationer throws', () => {
        let holidayPackage = new HolidayPackage();

        expect(() => holidayPackage.addVacationer()).to.throw(Error, 'Vacationer name must be a non-empty string');
        expect(() => holidayPackage.addVacationer(1)).to.throw(Error, 'Vacationer name must be a non-empty string');
        expect(() => holidayPackage.addVacationer(' ')).to.throw(Error, 'Vacationer name must be a non-empty string');
        expect(() => holidayPackage.addVacationer('asd')).to.throw(Error, 'Name must consist of first name and last name');
        expect(() => holidayPackage.addVacationer('')).to.throw(Error, 'Name must consist of first name and last name');
    });

    it('adds the vacationer', () => {
        let holidayPackage = new HolidayPackage();

        holidayPackage.addVacationer('1 1');
        holidayPackage.addVacationer('2 1');
        holidayPackage.addVacationer('1 3');

        expect(holidayPackage.vacationers[0]).to.equal('1 1');
        expect(holidayPackage.vacationers[1]).to.equal('2 1');
        expect(holidayPackage.vacationers[2]).to.equal('1 3');
    });

    it('show vacationers', () => {
        let holidayPackage = new HolidayPackage();

        expect(holidayPackage.showVacationers()).to.equal('No vacationers are added yet');

        holidayPackage.addVacationer('1 2');
        holidayPackage.addVacationer('2 1');
        holidayPackage.addVacationer('1 3');

        expect(holidayPackage.showVacationers()).to.equal('Vacationers:\n1 2\n2 1\n1 3');
    });

    it('generate holiday package throws', () => {
        let holidayPackage = new HolidayPackage('Winter', 'Dest');
        expect(() => holidayPackage.generateHolidayPackage()).to.throw(Error, 'There must be at least 1 vacationer added');
    });

    it('generate holiday package winter with insurance', () => {
        let holidayPackage = new HolidayPackage('Dest', 'Winter');
        holidayPackage.addVacationer('1 1');
        holidayPackage.addVacationer('2 1');

        holidayPackage.insuranceIncluded = true;

        expect(holidayPackage.generateHolidayPackage()).to.equal('Holiday Package Generated\nDestination: Dest\nVacationers:\n1 1\n2 1\nPrice: 1100');
        holidayPackage.insuranceIncluded = false;
        expect(holidayPackage.generateHolidayPackage()).to.equal('Holiday Package Generated\nDestination: Dest\nVacationers:\n1 1\n2 1\nPrice: 1000');
    });

    it('generate holiday package summer with insurance', () => {
        let holidayPackage = new HolidayPackage('Dest1', 'Summer');
        holidayPackage.addVacationer('1 1');
        holidayPackage.addVacationer('2 2');

        holidayPackage.insuranceIncluded = true;

        expect(holidayPackage.generateHolidayPackage()).to.equal('Holiday Package Generated\nDestination: Dest1\nVacationers:\n1 1\n2 2\nPrice: 1100');
        holidayPackage.insuranceIncluded = false;
        expect(holidayPackage.generateHolidayPackage()).to.equal('Holiday Package Generated\nDestination: Dest1\nVacationers:\n1 1\n2 2\nPrice: 1000');
    });

    it('generate holiday package winter with insurance', () => {
        let holidayPackage = new HolidayPackage('Dest', 'Winter');
        holidayPackage.addVacationer('1 1');
        holidayPackage.addVacationer('2 1');

        holidayPackage.insuranceIncluded = true;

        expect(holidayPackage.generateHolidayPackage()).to.equal('Holiday Package Generated\nDestination: Dest\nVacationers:\n1 1\n2 1\nPrice: 1100');
    });

    it('generate holiday package autumn with insurance', () => {
        let holidayPackage = new HolidayPackage('Dest1', 'Autumn');
        holidayPackage.addVacationer('1 1');
        holidayPackage.addVacationer('2 2');

        holidayPackage.insuranceIncluded = true;

        expect(holidayPackage.generateHolidayPackage()).to.equal('Holiday Package Generated\nDestination: Dest1\nVacationers:\n1 1\n2 2\nPrice: 900');
        holidayPackage.insuranceIncluded = false;
        expect(holidayPackage.generateHolidayPackage()).to.equal('Holiday Package Generated\nDestination: Dest1\nVacationers:\n1 1\n2 2\nPrice: 800');
    });

    it('generate holiday package spring with insurance', () => {
        let holidayPackage = new HolidayPackage('Dest1', 'Spring');
        holidayPackage.addVacationer('2 2');

        holidayPackage.insuranceIncluded = true;

        expect(holidayPackage.generateHolidayPackage()).to.equal('Holiday Package Generated\nDestination: Dest1\nVacationers:\n2 2\nPrice: 500');
        holidayPackage.insuranceIncluded = false;
        expect(holidayPackage.generateHolidayPackage()).to.equal('Holiday Package Generated\nDestination: Dest1\nVacationers:\n2 2\nPrice: 400');
    });
});