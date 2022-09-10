class Bank {
    constructor(bankName) {
        this._bankName = bankName;
        this.allCustomers = [];
        this.logs = {};
    }

    newCustomer(customer) {
        if (this.allCustomers.some(x => x.personalId === customer.personalId)) {
            throw new Error(`${customer.firstName} ${customer.lastName} is already our customer!`);
        }

        this.logs[customer.personalId] = [];
        this.allCustomers.push(customer);

        return customer;
    }

    depositMoney(personalId, amount) {
        const customer = this.allCustomers.find(x => x.personalId === personalId);
        if (!customer) {
            throw new Error(`We have no customer with this ID!`);
        }

        if (!customer.totalMoney) {
            customer.totalMoney = 0;
        }

        customer.totalMoney += amount;
        this.logs[personalId].push(`${customer.firstName} ${customer.lastName} made deposit of ${amount}$!`);
        return customer.totalMoney + '$';
    }

    withdrawMoney (personalId, amount){
        const customer = this.allCustomers.find(x => x.personalId === personalId);
        if (!customer) {
            throw new Error(`We have no customer with this ID!`);
        }

        if(amount > customer.totalMoney){
            throw new Error(`${customer.firstName} ${customer.lastName} does not have enough money to withdraw that amount!`);
        }

        customer.totalMoney -= amount;
        this.logs[personalId].push(`${customer.firstName} ${customer.lastName} withdrew ${amount}$!`);

        return customer.totalMoney + '$';
    }

    customerInfo (personalId){
        const customer = this.allCustomers.find(x => x.personalId === personalId);
        if (!customer) {
            throw new Error(`We have no customer with this ID!`);
        }

        const lines = [];

        lines.push(`Bank name: ${this._bankName}`);
        lines.push(`Customer name: ${customer.firstName} ${customer.lastName}`);
        lines.push(`Customer ID: ${personalId}`);
        lines.push(`Total Money: ${customer.totalMoney}$`);
        lines.push('Transactions:');

        let logs = this.logs[personalId];

        for(let x = logs.length - 1; x >= 0; x--){
            lines.push(`${x + 1}. ${logs[x]}`);
        }

        return lines.join('\n');
    }
}

let bank = new Bank('SoftUni Bank');

console.log(bank.newCustomer({firstName: 'Svetlin', lastName: 'Nakov', personalId: 6233267}));
console.log(bank.newCustomer({firstName: 'Mihaela', lastName: 'Mileva', personalId: 4151596}));

bank.depositMoney(6233267, 250);
console.log(bank.depositMoney(6233267, 250));
bank.depositMoney(4151596,555);

console.log(bank.withdrawMoney(6233267, 125));

console.log(bank.customerInfo(6233267));
