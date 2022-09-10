function createSortedList() {
    return {
        array: [],
        size: 0,
        add(elemenent) {
            this.size++;
            this.array.push(elemenent);
            this.array.sort((a, b) => a- b);
        },
        remove(index) {
            this.validate(index);
            this.size--;
            delete this.array.splice(index, 1);
        },
        get(index) {
            this.validate(index);
            return this.array[index];
        },
        validate(index){
            if(index < 0 || index >= this.size)
            {
               throw 'Index out of range';
            }
        }
    };
}

let list = createSortedList();
list.add(5);
list.add(6);
list.add(7);
console.log(list.get(1));
list.remove(1);
console.log(list.get(1));
