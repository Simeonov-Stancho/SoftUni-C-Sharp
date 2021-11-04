const { expect } = require('chai');

const { library } = require('./library');

describe('Tests Library', () => {
    describe('calcPriceOfBook', () => {
        it('vaid input', () => {
            expect(library.calcPriceOfBook('Book1', 2021)).to.be.equal(`Price of Book1 is 20.00`);
        });

        it('vaid input and year = 1980', () => {
            expect(library.calcPriceOfBook('Book1', 1980)).to.be.equal(`Price of Book1 is 10.00`);
        });

        it('vaid input and year < 1980', () => {
            expect(library.calcPriceOfBook('Book1', 1500)).to.be.equal(`Price of Book1 is 10.00`);
        });

        it('invalid bookName input', () => {
            expect(() => library.calcPriceOfBook(1, 2021)).to.throw("Invalid input");
        });

        it('bookName undefined input', () => {
            expect(() => library.calcPriceOfBook(undefined, 2021)).to.throw("Invalid input");
        });

        it('year invalid input - string', () => {
            expect(() => library.calcPriceOfBook('Book1', '2021')).to.throw("Invalid input");
        });

        it('year invalid input - double', () => {
            expect(() => library.calcPriceOfBook('Book1', 2.55)).to.throw("Invalid input");
        });

        it('year invalid input - undefined', () => {
            expect(() => library.calcPriceOfBook('Book1', undefined)).to.throw("Invalid input");
        });
    });

    describe('findBook', () => {
        it('booksArr is zero', () => {
            expect(() => library.findBook([], 'Book1')).to.throw("No books currently available");
        }); // array with something else?

        it('book present in booksArr ', () => {
            expect(library.findBook(["Troy", "Life Style", "Torronto"], 'Torronto')).to.equal("We found the book you want.");
        });

        it('book present in booksArr ', () => {
            expect(library.findBook(["Troy", "Life Style", "Torronto"], 'Torronto1')).to.equal("The book you are looking for is not here!");
        });
    });

    describe('arrangeTheBooks', () => {
        it('countBooks invalid input - string', () => {
            expect(() => library.arrangeTheBooks('Book1')).to.throw("Invalid input");
        });

        it('countBooks invalid input - double', () => {
            expect(() => library.arrangeTheBooks(2.55)).to.throw("Invalid input");
        });

        it('countBooks invalid input - undefined', () => {
            expect(() => library.arrangeTheBooks(undefined)).to.throw("Invalid input");
        }); //NaN

        it('countBooks invalid input negative count', () => {
            expect(() => library.arrangeTheBooks(-3)).to.throw("Invalid input");
        });

        it('countBooks more than 40', () => {
            expect(library.arrangeTheBooks(41)).to.equal("Insufficient space, more shelves need to be purchased.");
        });

        it('countBooks less or equal on 40', () => {
            expect(library.arrangeTheBooks(40)).to.equal("Great job, the books are arranged.");
        });
    });
});