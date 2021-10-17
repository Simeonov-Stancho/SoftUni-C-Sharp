function solve(inputArray) {
    let collection = [];

    let obj = {
        add: string => collection.push(string),
        remove: string => (collection = collection.filter(x => x !== string)),
        print: () => console.log(collection.join(',')),
    }

    inputArray.forEach(element => {
        const command = element.split(' ')[0];
        const string = element.split(' ')[1];

        obj[command](string);
    });

    // for (let i = 0; i < inputArray.length; i++) {
    //     const command = inputArray[i].split(' ')[0];
    //     const string = inputArray[i].split(' ')[1];

    //     obj[command](string);
    // }
}

solve(['add hello', 'add again', 'remove hello', 'add again', 'print']);

solve(['add pesho', 'add george', 'add peter', 'remove peter', 'print']);