function createSortedList() {
    let obj = {
        numbers: [],
        add(element) {
            this.numbers.push(element);
            this.numbers.sort((a, b) => a - b);
        },

        remove(index) {
            if (index >= 0 && index < this.numbers.length) {
                this.numbers.splice(index, 1);
            }
        },

        get(index) {
            if (index >= 0 && index < this.numbers.length) {
                return this.numbers[index];
            }
        },

        get size() {
            return this.numbers.length;
        },
    };

    return obj;
}

let list = createSortedList();
list.add(5);
list.add(6);
list.add(7);
console.log(list.get(1)); 
list.remove(1);
console.log(list.get(1));
