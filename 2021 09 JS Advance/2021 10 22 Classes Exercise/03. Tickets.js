function solve(array, criterion) {
    let tickets = [];
    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    for (let i = 0; i < array.length; i++) {
        const currentDestination = array[i].split('|')[0];
        const currentPRice = Number(array[i].split('|')[1]);
        const currentStatus = array[i].split('|')[2];

        let currentTicket = new Ticket(currentDestination, currentPRice, currentStatus);
        tickets.push(currentTicket);
    }

    tickets.sort((a, b) => {
        if (typeof a[criterion] == 'string' && typeof b[criterion] == 'string') {
            return a[criterion].localeCompare(b[criterion]);
        } else {
            return a[criterion] - b[criterion]
        }
    });

    return tickets;
}

let test1 = solve(
    ['Philadelphia|94.20|available',
        'New York City|95.99|available',
        'New York City|95.99|sold',
        'Boston|126.20|departed'],
    'destination'
);

console.log(test1)

