function solve(...args) {
    let data = {};

    const result = args.map(x => {
        data[typeof x] = (data[typeof x] || 0) + 1
        return `${typeof x}: ${x}`
    });

    result.forEach(x => console.log(x))
    Object.entries(data)
        .sort((a, b) => b[1] - a[1])
        .map(([type, counts]) => console.log(`${type} = ${counts}`));
}

solve('cat', 42, function () { console.log('Hello world!'); });