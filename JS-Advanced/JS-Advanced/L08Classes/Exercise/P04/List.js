class List {
    constructor() {
        this.list = [];
        this.size = 0;
    }

    add(element) {
        this.list.push(element);
        this.sort();

        this.size++;
    }

    remove(index) {
        if (index < 0 || index >= this.size) {
            return;
        }

        this.size--;
        this.list.splice(index, 1);
    }

    get(index) {
        if (index < 0 || index >= this.size) {
            return;
        }

        return this.list[index];
    }

    sort() {
        this.list = this.list.sort((a, b) => a - b);
    }
}

let list = new List();
list.add(5);
list.add(6);
list.add(7);

let item0 = list.get(0);
let item1 = list.get(1);
let item2 = list.get(2);

let size = list.size;
console.log(list.get(1));
list.remove(1);
console.log(list.get(1));
