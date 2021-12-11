const { expect } = require('chai');

const { library } = require('./library');

describe('Tests Library', () => {
    describe('calcPriceOfBook', () => {
        it('vaid input', () => {
            expect(library.calcPriceOfBook('Book1', 2021)).to.be.equal(`Price of Book1 is 20.00`);
        });
        
        it('invalid bookName input', () => {
            expect(() => library.calcPriceOfBook(1, 2021)).to.throw("Invalid input");
        });
    });

    describe('findBook', () => {
        it('booksArr is zero', () => {
            expect(() => library.findBook([], 'Book1')).to.throw("No books currently available");
        }); // array with something else?

        it('book present in booksArr ', () => {
            expect(library.findBook(["Troy", "Life Style", "Torronto"], 'Torronto')).to.equal("We found the book you want.");
        });        
    });

    describe('arrangeTheBooks', () => {
        it('countBooks invalid input - string', () => {
            expect(() => library.arrangeTheBooks('Book1')).to.throw("Invalid input");
        });
        
        it('countBooks less or equal on 40', () => {
            expect(library.arrangeTheBooks(40)).to.equal("Great job, the books are arranged.");
        });
    });
});


module.exports = {library}; // za klasa