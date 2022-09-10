class Vacationer {
    constructor(fullName, creditCard) {
        if (creditCard === undefined) {
            this.addCreditCardInfo([1111, '', 111]);
        } else {
            this.addCreditCardInfo(creditCard);
        }

        this.fullName = fullName;
        this.wishList = [];
        this.idNumber = this.generateIDNumber();
    }

    get fullName() {
        return this._fullName;
    }

    set fullName(fullName) {
        let nameRegex = /^[A-Z][a-z]+$/;

        if (fullName.length !== 3) {
            throw new Error('Name must include first name, middle name and last name');
        }

        fullName.forEach(x => {
            if (!x.match(nameRegex)) {
                throw  new Error('Invalid full name');
            }
        });

        const [firstName, middleName, lastName] = fullName;
        this._fullName = {firstName, middleName, lastName};
    }

    generateIDNumber() {
        const {firstName, middleName, lastName} = this.fullName;
        let result = 231 * firstName.charCodeAt(0) + 139 * middleName.length;

        const vowels = ["a", "e", "o", "i", "u"];
        if (vowels.includes(lastName.slice(-1))) {
            result += '8';
        } else {
            result += '7';
        }

        return result;
    }

    addCreditCardInfo([cardNumber, expirationDate, securityNumber]) {
        if (cardNumber === undefined || expirationDate === undefined || securityNumber === undefined) {
            throw  new Error('Missing credit card information');
        }

        if (typeof cardNumber !== 'number' || typeof securityNumber !== 'number') {
            throw new Error('Invalid credit card details');
        }

        this.creditCard = {cardNumber, expirationDate, securityNumber};
    }

    addDestinationToWishList(destination) {
        if (this.wishList.includes(destination)) {
            throw new Error('Destination already exists in wishlist');
        }

        this.wishList.push(destination);
        this.wishList = this.wishList.sort((a, b) => a.length - b.length);
    }

    getVacationerInfo() {
        const {firstName, middleName, lastName} = this.fullName;
        const {cardNumber, expirationDate, securityNumber} = this.creditCard;

        const lines = [];

        lines.push(`Name: ${firstName} ${middleName} ${lastName}`);
        lines.push(`ID Number: ${this.idNumber}`);
        lines.push(`Wishlist:`);
        lines.push(this.wishList.join(', ') === '' ? 'empty' : this.wishList.join(', '));
        lines.push(`Credit Card:`);
        lines.push(`Card Number: ${cardNumber}`);
        lines.push(`Expiration Date: ${expirationDate}`);
        lines.push(`Security Number: ${securityNumber}`);

        return lines.join('\n');
    }
}

// Initialize vacationers with 2 and 3 parameters
let vacationer1 = new Vacationer(["Vania", "Ivanova", "Zhivkova"]);
let vacationer2 = new Vacationer(["Tania", "Ivanova", "Zhivkova"],
    [123456789, "10/01/2018", 777]);

// Should throw an error (Invalid full name)
try {
    let vacationer3 = new Vacationer(["Vania", "Ivanova", "ZhiVkova"]);
} catch (err) {
    console.log("Error: " + err.message);
}

// Should throw an error (Missing credit card information)
try {
    let vacationer3 = new Vacationer(["Zdravko", "Georgiev", "Petrov"]);
    vacationer3.addCreditCardInfo([123456789, "20/10/2018"]);
} catch (err) {
    console.log("Error: " + err.message);
}

vacationer1.addDestinationToWishList('Spain');
vacationer1.addDestinationToWishList('Germany');
vacationer1.addDestinationToWishList('Bali');

// Return information about the vacationers
console.log(vacationer1.getVacationerInfo());
console.log(vacationer2.getVacationerInfo());

