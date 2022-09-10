let dealership = {
    newCarCost: function (oldCarModel, newCarPrice) {

        let discountForOldCar = {
            'Audi A4 B8': 15000,
            'Audi A6 4K': 20000,
            'Audi A8 D5': 25000,
            'Audi TT 8J': 14000,
        }

        if (discountForOldCar.hasOwnProperty(oldCarModel)) {
            let discount = discountForOldCar[oldCarModel];
            let finalPrice = newCarPrice - discount;
            return finalPrice;
        } else {
            return newCarPrice;
        }
    },

    carEquipment: function (extrasArr, indexArr) {
        let selectedExtras = [];
        indexArr.forEach(i => {
            selectedExtras.push(extrasArr[i])
        });

        return selectedExtras;
    },

    euroCategory: function (category) {
        if (category >= 4) {
            let price = this.newCarCost('Audi A4 B8', 30000);
            let total = price - (price * 0.05)
            return `We have added 5% discount to the final price: ${total}.`;
        } else {
            return 'Your euro category is low, so there is no discount from the final price!';
        }
    }
}

let {expect} = require('chai');

describe('', () => {
    it('return old car without discount', () => {
        expect(dealership.newCarCost('not supported', 10000)).to.equal(10000);
    });

    it('return old car without discount', () => {
        expect(dealership.newCarCost('Audi', 1)).to.equal(1);
    });

    it('return old car with discount', () => {
        expect(dealership.newCarCost('Audi A4 B8', 15000)).to.equal(0);
    });

    it('return old car with discount', () => {
        expect(dealership.newCarCost('Audi A6 4K', 20000)).to.equal(0);
    });

    it('return old car with discount', () => {
        expect(dealership.newCarCost('Audi A8 D5', 25000)).to.equal(0);
    });

    it('return old car with discount', () => {
        expect(dealership.newCarCost('Audi TT 8J', 14000)).to.equal(0);
    });

    it('car equipment', () => {
       expect(dealership.carEquipment([], [])[0]).to.be.undefined;
    });

    it('car equipment', () => {
        expect(dealership.carEquipment(['1'], [1])[0]).to.be.undefined;
    });

    it('car equipment', () => {
        let result = dealership.carEquipment(['0', '1', '2', '3', '4'], [0, 2, 4]);

        expect(result[0]).to.equal('0');
        expect(result[1]).to.equal('2');
        expect(result[2]).to.equal('4');
    });

    it('euro category', () => {
        let result = dealership.euroCategory(3);
        expect(result).to.equal('Your euro category is low, so there is no discount from the final price!');
    });

    it('euro category', () => {
        let result = dealership.euroCategory(1);
        expect(result).to.equal('Your euro category is low, so there is no discount from the final price!');
    });

    it('euro category', () => {
        let result = dealership.euroCategory(4);
        expect(result).to.equal('We have added 5% discount to the final price: 14250.');
    });

    it('euro category', () => {
        let result = dealership.euroCategory(5);
        expect(result).to.equal('We have added 5% discount to the final price: 14250.');
    });
});