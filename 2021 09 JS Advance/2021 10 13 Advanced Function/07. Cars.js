function solve(input) {
    let cars = {};

    let car = {
        create: (childName, inherits, parentName) => 
            cars[childName] = inherits ? Object.create(cars[parentName]): {},
        set: (name, key, value) => cars[name][key] = value,
        print: (name) => {
            let arr = [];

            for (const key in cars[name]) {
                arr.push(`${key}:${cars[name][key]}`)
            }

            console.log(arr.join(','))
        }
    }

    input.forEach(e => {
        let [command, childName, inherits, parentName] = e.split(' ')
        
        car[command](childName, inherits, parentName);
    });
}


solve(['create c1',
       'create c2 inherit c1',
       'set c1 color red',
       'set c2 model new',
       'print c1',
       'print c2']
);