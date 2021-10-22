class List {
    constructor() {
        this.array = [];
        this.size = 0;
    }

    add(element) {
        this.array.push(Number(element));
        this.size++;
        this.array.sort((a, b) => a - b);

        return this.array;
    }

    remove(index) {
        if (index >= 0 && index < this.array.length) {
            this.array.splice(Number(index), 1);
            this.size--;

            this.array.sort((a, b) => a - b);
        }
        return this.array;
    }

    get(index) {
        if (index >= 0 && index < this.array.length) {
            return this.array[index];
        }
    }
}

let list = new List();
list.add(5);
list.add(6);
list.add(7);
console.log(list.get(1)); 
list.remove(1);
console.log(list.get(1));

