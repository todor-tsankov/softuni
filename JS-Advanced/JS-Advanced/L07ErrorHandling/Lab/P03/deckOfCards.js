function printDeckOfCards(cards) {
    function createCard(face, suit) {
        const faces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
        const suits = {
            S: '\u2660',
            H: '\u2665',
            D: '\u2666',
            C: '\u2663',
        };

        if (!faces.includes(face) || !suits[suit]) {
            throw Error('Invalid face or suit!');
        }

        return {
            face,
            suit,
            toString: () => face + suits[suit],
        };
    }

    let invalidCard;
    const resultCards = [];

    for (const c of cards) {
        try {
            let face = c[0];
            let suit = c[1];

            if (c.length > 2){
                face += suit;
                suit = c[2];
            }

            resultCards.push(createCard(face, suit));
        } catch (e) {
            invalidCard = c;
            break;
        }
    }

    let result;

    if (!invalidCard) {
        result = resultCards.join(' ');
    } else {
        result = 'Invalid card: ' + invalidCard.toString();
    }

    console.log(result);
}

printDeckOfCards(['AS', '10D', 'KH', '2C']);
printDeckOfCards(['5S', '3D', 'QD', '1C']);