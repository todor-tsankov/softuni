function solve(inputArr, sortingParam) {
    class Ticket {
        constructor(arr) {
            this.destination = arr[0];
            this.price = Number(arr[1]);
            this.status = arr[2];
        }
    }

    const sorter = {
        destination: (a, b) => a.destination.localeCompare(b.destination),
        price: (a, b) => a.price - b.price,
        status: (a, b) => a.status.localeCompare(b.status),
    };

    const tickets = [];
    inputArr.forEach(x => tickets.push(new Ticket(x.split('|'))));

    return tickets.sort(sorter[sortingParam]);
}

console.log(solve(['Philadelphia|94.20|available',
        'New York City|95.99|available',
        'New York City|95.99|sold',
        'Boston|126.20|departed'],
    'destination'
));

console.log(solve(['Philadelphia|94.20|available',
        'New York City|95.99|available',
        'New York City|95.99|sold',
        'Boston|126.20|departed'],
    'status'
));
