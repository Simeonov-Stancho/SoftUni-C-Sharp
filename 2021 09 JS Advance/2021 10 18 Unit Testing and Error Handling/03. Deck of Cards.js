function createDeck(cards) {
    let deck = [];
    for (let i = 0; i < cards.length; i++) {
        let currentCard = cards[i];
        let face = currentCard.substring(0, currentCard.length -1);
        let suit = currentCard[currentCard.length-1];

        try {
            deck.push(solve(face, suit))
        } catch (error) {
            console.log(`Invalid card: ${currentCard}`);
            return;
        }

        console.log(deck.join(' '));
    }

    function solve(face, suit) {
        const suits = {
            'S': '\u2660',
            'H': '\u2665',
            'D': '\u2666',
            'C': '\u2663',
        }
    
        if (!Object.keys(suits).includes(suit)) {
            throw new Error();
        }
    
        const faces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
    
        if (!faces.includes(face)) {
            throw new Error();
        }
        return {
            face,
            suit: suits[suit],
            toString() {
                return this.face + this.suit
            }
        };
    }
}

createDeck(['AS', '10D', 'KH', '2C']);
createDeck(['5S', '3D', 'QD', '1C']);
