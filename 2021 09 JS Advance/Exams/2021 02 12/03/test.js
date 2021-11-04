const { pizzUni } = require('./pizza');
const { expect } = require('chai');

describe('Pizza Tests', () => {
    describe('makeAnOrder', () => {
        it('throw error with empty obj', () => {
            expect(() => pizzUni.makeAnOrder({ orderedPizza: '', orderedDrink: '' })).to.throw(`You must order at least 1 Pizza to finish the order.`);
        });

        it('throw error with empty obj', () => {
            expect(() => pizzUni.makeAnOrder({})).to.throw(`You must order at least 1 Pizza to finish the order.`);
        });

        it('work with pizza only', () => {
            expect(pizzUni.makeAnOrder({ orderedPizza: 'Piperoni', orderedDrink: '' })).to.be.equal(`You just ordered Piperoni`);
        });

        it('work with both pizza and drink', () => {
            expect(pizzUni.makeAnOrder({ orderedPizza: 'Piperoni', orderedDrink: 'Becks' })).to.be.equal(`You just ordered Piperoni and Becks.`);
        });
    });

    describe('getRemainingWork', () => {
        it('work is done', () => {
            expect(pizzUni.getRemainingWork([{ pizzaName: 'Piperoni', status: 'ready' }])).to.be.equal(`All orders are complete!`);
        });

        it('work for prepraing', () => {
            expect(pizzUni.getRemainingWork([{ pizzaName: 'Piperoni', status: 'preparing' }])).to.be.equal(`The following pizzas are still preparing: Piperoni.`);
        });

        it('work for ready', () => {
            expect(pizzUni.getRemainingWork([{ pizzaName: 'Piperoni', status: 'ready' }, { pizzaName: 'Piperoni', status: 'ready' }, { pizzaName: 'Piperoni', status: 'ready' }])).to.be.equal(`All orders are complete!`);
        });

        it('work for prepraing', () => {
            expect(pizzUni.getRemainingWork([{ pizzaName: 'Piperoni', status: 'ready' }, { pizzaName: 'Piperoni', status: 'ready' }, { pizzaName: 'Piperoni', status: 'preparing' }])).to.be.equal(`The following pizzas are still preparing: Piperoni.`);
        });

    });

    describe('orderType', () => {
        it('work with discount', () => {
            expect(pizzUni.orderType(10, 'Carry Out')).to.be.equal(9);
        });

        it('work without disc', () => {
            expect(pizzUni.orderType(10, 'Delivery')).to.be.equal(10);
        });
    });
});
