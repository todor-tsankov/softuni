class Parking {
    constructor(capacity) {
        this.capacity = capacity;
        this.vehicles = [];
    }

    addCar(carModel, carNumber) {
        if (this.capacity <= this.vehicles.length) {
            throw new Error('Not enough parking space.');
        }

        this.vehicles.push({carModel, carNumber, payed: false});
        return `The ${carModel}, with a registration number ${carNumber}, parked.`;
    }

    removeCar(carNumber) {
        let carIndex = this.vehicles.findIndex(x => x.carNumber === carNumber);

        if (carIndex === -1) {
            throw new Error('The car, you\'re looking for, is not found.');
        }

        if (!this.vehicles[carIndex].payed) {
            throw new Error(`${carNumber} needs to pay before leaving the parking lot.`);
        }

        this.vehicles.splice(carIndex, 1);
        return `${carNumber} left the parking lot.`;
    }

    pay(carNumber) {
        let carIndex = this.vehicles.findIndex(x => x.carNumber === carNumber);

        if (carIndex === -1) {
            throw new Error(`${carNumber} is not in the parking lot.`);
        }

        if (this.vehicles[carIndex].payed) {
            throw new Error(`${carNumber}'s driver has already payed his ticket.`);
        }

        this.vehicles[carIndex].payed = true;
        return `${carNumber}'s driver successfully payed for his stay.`;
    }

    getStatistics(carNumber) {
        if (!carNumber) {
            let lines = [];
            let sorted = this.vehicles.sort((a, b) => a.carModel.localeCompare(b.carModel));
            lines.push(`The Parking Lot has ${this.capacity - this.vehicles.length} empty spots left.`);

            sorted.forEach(x => lines.push(`${x.carModel} == ${x.carNumber} - ${x.payed ? 'Has payed' : 'Not payed'}`));
            return lines.join('\n');

        } else {
            let carIndex = this.vehicles.findIndex(x => x.carNumber === carNumber);
            let car = this.vehicles[carIndex];

            return `${car.carModel} == ${carNumber} - ${car.payed ? 'Has payed' : 'Not payed'}`;
        }
    }
}

const parking = new Parking(12);

console.log(parking.addCar("Volvo t600", "TX3691CA"));
console.log(parking.getStatistics());

console.log(parking.pay("TX3691CA"));
console.log(parking.removeCar("TX3691CA"));
