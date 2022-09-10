class ChristmasDinner {
    constructor(budget) {
        this.budget = budget;
        this.dishes = [];
        this.products = [];
        this.guests = [];
    }

    get budget() {
        return this._budget;
    }

    set budget(value) {
        if (typeof value != 'number' || value < 0) {
            throw new Error('The budget cannot be a negative number.');
        }

        this._budget = value;
    }

    shopping([type, price]) {
        if (this.budget < price) {
            throw new Error('Not enough money to buy this product.');
        }

        this.products.push(type);
        this.budget -= price;

        return `You have successfully bought ${type}!`;
    }

    recipes({recipeName, productsList}) {
        productsList.forEach(x => {
            if (!this.products.includes(x)) {
                throw new Error('We do not have this product.');
            }
        });

        this.dishes.push({recipeName, productsList});
        return `${recipeName} has been successfully cooked!`;
    }

    inviteGuests(guestName, dish) {
        if(!this.dishes.some(x => x.recipeName === dish)){
            throw new Error('We do not have this dish.');
        }

        if(this.guests.some(x => x[guestName] === dish)){
            throw new Error('This guest has already been invited.');
        }

        const newGuest = {};
        newGuest[guestName] = dish;

        this.guests.push(newGuest);
        return `You have successfully invited ${guestName}!`;
    }

    showAttendance(){
        let lines = [];

        this.guests.forEach(x => {
            let name = Object.keys(x)[0];
            let dish = this.dishes.find(y => y.recipeName === x[name]);

            lines.push(`${name} will eat ${dish.recipeName}, which consists of ${dish.productsList.join(', ')}`);
        });

        return lines.join('\n');
    }
}

let dinner = new ChristmasDinner(100);

console.log(dinner.shopping(['Salt', 1]));
console.log(dinner.shopping(['Beans', 3]));
console.log(dinner.shopping(['Cabbage', 4]));
console.log(dinner.shopping(['Rice', 2]));
console.log(dinner.shopping(['Savory', 1]));
console.log(dinner.shopping(['Peppers', 1]));
console.log(dinner.shopping(['Fruits', 40]));
console.log(dinner.shopping(['Honey', 10]));

console.log(dinner.recipes({
    recipeName: 'Oshav',
    productsList: ['Fruits', 'Honey']
}));
console.log(dinner.recipes({
    recipeName: 'Oshav1',
    productsList: ['Fruits', 'Honey']
}));
console.log(dinner.recipes({
    recipeName: 'Folded cabbage leaves filled with rice',
    productsList: ['Cabbage', 'Rice', 'Salt', 'Savory']
}));
console.log(dinner.recipes({
    recipeName: 'Peppers filled with beans',
    productsList: ['Beans', 'Peppers', 'Salt']
}));

console.log(dinner.inviteGuests('Ivan', 'Oshav'));
console.log(dinner.inviteGuests('Ivan', 'Oshav1'));
console.log(dinner.inviteGuests('Petar', 'Folded cabbage leaves filled with rice'));
console.log(dinner.inviteGuests('Georgi', 'Peppers filled with beans'));

console.log(dinner.showAttendance());

