const { cinema } = require('./cinema');
const { expect } = require('chai');

describe('Cinema Tests', () => {
    describe('Test shoeMovies method', () => {
        it('empy array', () => {
            expect(cinema.showMovies([])).to.be.equal('There are currently no movies to show.');
        });

        it('should work', () => {
            expect(cinema.showMovies(['King Kong', 'Terminator', 'Rambo'])).to.be.equal('King Kong, Terminator, Rambo');
        });

        it('should work', () => {
            expect(cinema.showMovies(['King Kong'])).to.be.equal('King Kong');
        });
    });

    describe('Test ticketPrice method', () => {
        it('should return 12 with Premiere type', () => {
            expect(cinema.ticketPrice('Premiere')).to.equal(12.00);
        });

        it('should return 7.50 with Normal type', () => {
            expect(cinema.ticketPrice('Normal')).to.equal(7.50);
        });

        it('should return 5.50 with Discount type', () => {
            expect(cinema.ticketPrice('Discount')).to.equal(5.50);
        });

        it('should throw error with invalid type', () => {
            expect(() => cinema.ticketPrice('Invalid type')).to.throw('Invalid projection type.');
        });
    });

    describe('Test swapSeatsInHall method', () => {
        it('with only one place', () => {
            expect(cinema.swapSeatsInHall(3)).to.equal('Unsuccessful change of seats in the hall.');
        });        
        it('with only one place', () => {
            expect(cinema.swapSeatsInHall(3, 'i')).to.be.equal('Unsuccessful change of seats in the hall.');
        });
        it('with only one place', () => {
            expect(cinema.swapSeatsInHall('i', 4)).to.be.equal('Unsuccessful change of seats in the hall.');
        });

        it('with double', () => {
            expect(cinema.swapSeatsInHall(3.5, 6)).to.be.equal('Unsuccessful change of seats in the hall.');
        });
        it('with double', () => {
            expect(cinema.swapSeatsInHall(3, 6.22)).to.be.equal('Unsuccessful change of seats in the hall.');
        });

        it('with number greater of 20', () => {
            expect(cinema.swapSeatsInHall(21, 6)).to.be.equal('Unsuccessful change of seats in the hall.');
        });
        it('with number greater of 20', () => {
            expect(cinema.swapSeatsInHall(3, 21)).to.be.equal('Unsuccessful change of seats in the hall.');
        });

        it('with negative firstPlace and valid secondPlace', () => {
            expect(cinema.swapSeatsInHall(-1, 3)).to.be.equal('Unsuccessful change of seats in the hall.');
        });
        it('with negative secondPlace', () => {
            expect(cinema.swapSeatsInHall(1, -3)).to.be.equal('Unsuccessful change of seats in the hall.');
        });

        it('with zero for firstPlace and valid secondPlace', () => {
            expect(cinema.swapSeatsInHall(0, 3)).to.be.equal('Unsuccessful change of seats in the hall.');
        });
        it('with zero for secondPlace', () => {
            expect(cinema.swapSeatsInHall(2, 0)).to.be.equal('Unsuccessful change of seats in the hall.');
        });

        it('with equal firstPlace secondPlace', () => {
            expect(cinema.swapSeatsInHall(1, 1)).to.be.equal('Unsuccessful change of seats in the hall.');
        });

        it('should work', () => {
            expect(cinema.swapSeatsInHall(2, 20)).to.be.equal('Successful change of seats in the hall.');
        });
    });
});