class SummerCamp {

    constructor(organizer, location) {
        this.organizer = organizer;
        this.location = location;
        this.priceForTheCamp = {
            "child": 150,
            "student": 300,
            "collegian": 500
        };
        this.listOfParticipants = [];
    }

    registerParticipant(name, condition, money) {
        const checkCondition = Object.entries(this.priceForTheCamp).some(c => c[0] == condition);
        const isPresent = this.listOfParticipants.some(p => p.name == name);

        if (!checkCondition) {
            throw new Error("Unsuccessful registration at the camp.");
        }

        if (isPresent) {
            return `The ${name} is already registered at the camp.`;
        }

        const currentPrice = Number((Object.entries(this.priceForTheCamp).find(p => p[0] == condition)[1]));
        if (Number(money) < currentPrice) {
            return `The money is not enough to pay the stay at the camp.`
        }

        this.listOfParticipants.push({
            name: name,
            condition: condition,
            power: 100,
            wins: 0
        });

        return `The ${name} was successfully registered.`
    }

    unregisterParticipant(name) {
        const isPresentParticipant = this.listOfParticipants.find(p => p.name == name);

        if (!isPresentParticipant) {
            throw new Error(`The ${name} is not registered in the camp.`);
        }

        const index = this.listOfParticipants.indexOf(isPresentParticipant);
        this.listOfParticipants.splice(index, 1);
        return `The ${name} removed successfully.`
    }

    timeToPlay(typeOfGame, participant1, participant2) {
        let player1 = this.listOfParticipants.find(p => p.name == participant1);
        let player2 = this.listOfParticipants.find(p => p.name == participant2);

        if (!participant2 && typeOfGame == "Battleship") {

            if (!player1) {
                throw new Error(`Invalid entered name/s.`);
            }

            this.listOfParticipants.find(p => p.name == participant1).power += 20;
            return `The ${participant1} successfully completed the game ${typeOfGame}.`;
        }

        else if (typeOfGame == 'WaterBalloonFights') {
            if (!player1 || !player2) {
                throw new Error(`Invalid entered name/s.`);
            }

            if (player1.condition != player2.condition) {
                throw new Error(`Choose players with equal condition.`);
            }

            if (player1.power > player2.power) {
                player1.wins += 1;
                return `The ${player1.name} is winner in the game ${typeOfGame}.`
            }
            else if (player1.power < player2.power) {
                player2.wins += 1;
                return `The ${player2.name} is winner in the game ${typeOfGame}.`
            }
        }

        else if (typeOfGame == 'Battleship') {
            this.listOfParticipants.find(p => p.name == participant1).power += 20;
            return `The ${participant1} successfully completed the game ${typeOfGame}.`
        }

        return `There is no winner.`
    }

    toString() {
        const result = [];

        result.push(`${this.organizer} will take ${this.listOfParticipants.length} participants on camping to ${this.location}`);
        this.listOfParticipants.sort((a, b) => b.wins - a.wins);
        this.listOfParticipants.forEach(p => result.push(`${p.name} - ${p.condition} - ${p.power} - ${p.wins}`));
        return result.join('\n').trim();
    }
}

//My input
let camp1 = new SummerCamp("Stancho", 'Bulgaria');
console.log(camp1.registerParticipant('Stancho', 'student', 510));
console.log(camp1.registerParticipant('Stancho1', 'student', 1200));
console.log(camp1.registerParticipant('Stancho2', 'child', 12200));
console.log(camp1.unregisterParticipant('Stancho2'));
console.log(camp1.timeToPlay('Battleship', 'Stancho'));
console.log(camp1.timeToPlay('WaterBalloonFights', 'Stancho', 'Stancho1'));
console.log(camp1.toString());

//input1
// const summerCamp = new SummerCamp("Jane Austen", "Pancharevo Sofia 1137, Bulgaria");
// console.log(summerCamp.registerParticipant("Petar Petarson", "student", 200));
// console.log(summerCamp.registerParticipant("Petar Petarson", "student", 300));
// console.log(summerCamp.registerParticipant("Petar Petarson", "student", 300));
// console.log(summerCamp.registerParticipant("Leila Wolfe", "childd", 200));

//input2
// const summerCamp = new SummerCamp("Jane Austen", "Pancharevo Sofia 1137, Bulgaria");
// console.log(summerCamp.registerParticipant("Petar Petarson", "student", 300));
// console.log(summerCamp.unregisterParticipant("Petar"));
// console.log(summerCamp.unregisterParticipant("Petar Petarson"));

// //input3
// const summerCamp = new SummerCamp("Jane Austen", "Pancharevo Sofia 1137, Bulgaria");
// console.log(summerCamp.registerParticipant("Petar Petarson", "student", 300));
// console.log(summerCamp.timeToPlay("Battleship", "Petar Petarson"));
// console.log(summerCamp.registerParticipant("Sara Dickinson", "child", 200));
// console.log(summerCamp.timeToPlay("WaterBalloonFights", "Petar Petarson", "Sara Dickinson"));
// console.log(summerCamp.registerParticipant("Dimitur Kostov", "student", 300));
// console.log(summerCamp.timeToPlay("WaterBalloonFights", "Petar Petarson", "Dimitur Kostov"));
// console.log(summerCamp.toString());





