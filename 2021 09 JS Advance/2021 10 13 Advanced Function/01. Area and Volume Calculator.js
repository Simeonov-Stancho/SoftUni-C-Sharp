function solve(area, vol, input) {
    const inputData = JSON.parse(input);
    let objects = [];

    for (let i = 0; i < inputData.length; i++) {
        const current = inputData[i];

        let obj = {
            area: area.apply(current),
            volume: vol.apply(current),
        }

        objects.push(obj);
    }

    return objects;
}

const input = `[
    {"x":"1","y":"2","z":"10"},
    {"x":"7","y":"7","z":"10"},
    {"x":"5","y":"2","z":"10"}
    ]`;

console.log(solve(area, vol, input));

function area() {
    return Math.abs(this.x * this.y);
};

function vol() {
    return Math.abs(this.x * this.y * this.z);
};
