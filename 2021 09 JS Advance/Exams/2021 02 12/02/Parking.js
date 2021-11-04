class Parking {
    constructor(capacity) {
        this.capacity = capacity;
        this.vehicles = [];
    };

    addCar(carModel, carNumber) {
        if (this.capacity <= 0) {
            throw new Error("Not enough parking space.");
        };

        let car = {
            carModel: carModel,
            carNumber: carNumber,
            payed: false,
        };

        this.vehicles.push(car);
        this.capacity -= 1;

        return `The ${carModel}, with a registration number ${carNumber}, parked.`;
    }

    removeCar(carNumber) {
        let parkedCar = this.vehicles.find(c => c.carNumber == carNumber);

        if (!parkedCar) {
            throw new Error("The car, you're looking for, is not found.");
        }

        if (parkedCar.payed == false) {
            throw new Error(`${carNumber} needs to pay before leaving the parking lot.`);
        }

        this.vehicles = this.vehicles.filter(function (value, index, newArr) {
            return value != parkedCar;
        })

        // for (var i = 0; i < this.vehicles.length; i++) {

        //     if (this.vehicles[i] == parkedCar) {

        //         this.vehicles.splice(i, 1);
        //     }
        // }

        return `${carNumber} left the parking lot.`;
    }

    pay(carNumber) {
        let parkedCar = this.vehicles.find(c => c.carNumber == carNumber);

        if (!parkedCar) {
            throw new Error(`${carNumber} is not in the parking lot.`);
        }

        if (parkedCar.payed == true) {
            throw new Error(`${carNumber}'s driver has already payed his ticket.`);
        }

        parkedCar.payed = true;

        return `${carNumber}'s driver successfully payed for his stay.`
    }

    getStatistics(carNumber) {
        let result = [];
        if (carNumber == undefined) {
            result.push(`The Parking Lot has ${this.capacity} empty spots left.`);

            this.vehicles.sort((a, b) => a.carModel.localeCompare(b.carModel));
            this.vehicles.forEach(c => {
                result.push(`${c.carModel} == ${c.carNumber} - ${c.payed == true ? 'Has payed' : 'Not payed'}`);
            });

            return result.join('\n')
        }

        let parkedCar = this.vehicles.find(c => c.carNumber == carNumber);

        return `${parkedCar.carModel} == ${parkedCar.carNumber} - ${parkedCar.payed == true ? 'Has payed' : 'Not payed'}`
    }
}

const parking = new Parking(2);

console.log(parking.addCar("bmw", "B6666BB"));
console.log(parking.addCar("audi", "CA6666CA"));

//console.log(parking.removeCar("X6666CA"));
//console.log(parking.removeCar("CA6666CA"));

//console.log(parking.pay("CA6666CA"));
console.log(parking.pay("CA6666CA"));
//console.log(parking.removeCar("CA6666CA"));

console.log(parking.getStatistics('CA6666CA'));
console.log(parking.getStatistics("B6666BB"));


console.log(parking.getStatistics());


