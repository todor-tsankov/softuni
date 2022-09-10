let pizzUni = {
    makeAnOrder: function (obj) {

        if (!obj.orderedPizza) {
            throw new Error('You must order at least 1 Pizza to finish the order.');
        } else {
            let result = `You just ordered ${obj.orderedPizza}`
            if (obj.orderedDrink) {
                result += ` and ${obj.orderedDrink}.`
            }
            return result;
        }
    },

    getRemainingWork: function (statusArr) {

        const remainingArr = statusArr.filter(s => s.status != 'ready');

        if (remainingArr.length > 0) {

            let pizzaNames = remainingArr.map(p => p.pizzaName).join(', ')
            let pizzasLeft = `The following pizzas are still preparing: ${pizzaNames}.`

            return pizzasLeft;
        } else {
            return 'All orders are complete!'
        }

    },

    orderType: function (totalSum, typeOfOrder) {
        if (typeOfOrder === 'Carry Out') {
            totalSum -= totalSum * 0.1;

            return totalSum;
        } else if (typeOfOrder === 'Delivery') {

            return totalSum;
        }
    }
}

const {expect} = require('chai');

describe('', () => {
    it('make an order throws 1', () => {
        expect(() => pizzUni.makeAnOrder({
            orderedPizza: undefined,
            orderedDrink: 'the name of the drink'
        })).to.throw('You must order at least 1 Pizza to finish the order.');
    });

    it('make an order throws 2', () => {
        expect(() => pizzUni.makeAnOrder({orderedDrink: 'the name of the drink'})).to.throw('You must order at least 1 Pizza to finish the order.');
    });

    it('make an  without drink 1', () => {
        expect(pizzUni.makeAnOrder({
            orderedPizza: 'pizza',
            orderedDrink: undefined
        })).to.equal('You just ordered pizza');
    });

    it('make an  without drink 2', () => {
        expect(pizzUni.makeAnOrder({orderedPizza: 'pizza1'})).to.equal('You just ordered pizza1');
    });

    it('make an  with drink 1', () => {
        expect(pizzUni.makeAnOrder({
            orderedPizza: 'pizza',
            orderedDrink: 'drink'
        })).to.equal('You just ordered pizza and drink.');
    });

    it('make an  with drink 2', () => {
        expect(pizzUni.makeAnOrder({
            orderedPizza: 'pizza',
            orderedDrink: 'drink1'
        })).to.equal('You just ordered pizza and drink1.');
    });

    it('get remaining work with only finished pizzas 1', () => {
        let arr = [{pizzaName: 'pizza1', status: 'ready'}, {pizzaName: 'pizza2', status: 'ready'}];
        expect(pizzUni.getRemainingWork([])).to.equal('All orders are complete!');
    });

    it('get remaining work with only finished pizzas 2', () => {
        let arr = [];
        expect(pizzUni.getRemainingWork([])).to.equal('All orders are complete!');
    });

    it('get remaining work 1', () => {
        let arr = [{pizzaName: 'pizza1', status: 'preparing'}];
        expect(pizzUni.getRemainingWork(arr)).to.equal('The following pizzas are still preparing: pizza1.');
    });

    it('get remaining 2', () => {
        let arr = [{pizzaName: 'pizza1', status: 'ready'},{pizzaName: 'pizza2', status: 'preparing’ '},{pizzaName: 'pizza3', status: 'preparing’ '}];
        expect(pizzUni.getRemainingWork(arr)).to.equal('The following pizzas are still preparing: pizza2, pizza3.');
    });

    it('order carry out 1', () => {
        expect(pizzUni.orderType(10, 'Carry Out')).to.equal(9);
    });

    it('order carry out 2', () => {
        expect(pizzUni.orderType(1, 'Carry Out')).to.equal(0.9);
    });

    it('order delivery 1', () => {
        expect(pizzUni.orderType(10, 'Delivery')).to.equal(10);
    });

    it('order delivery 2', () => {
        expect(pizzUni.orderType(1, 'Delivery')).to.equal(1);
    });

});
