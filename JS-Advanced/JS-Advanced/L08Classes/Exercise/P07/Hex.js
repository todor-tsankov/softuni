class Hex {
    constructor(value) {
        this.value = value;
    }

    valueOf() {
       return this.value;
    }

    toString() {
        return '0x' + this.value.toString(16).toUpperCase();
    }

    plus(obj) {
        let newValue = this.value;

        if(obj instanceof Hex){
            newValue += obj.valueOf();
        }
        else {
            newValue += obj;
        }

        return new Hex(newValue);
    }

    minus(obj) {
        let newValue = this.value;

        if(obj instanceof Hex){
            newValue -= obj.valueOf();
        }
        else {
            newValue -= obj;
        }

        return new Hex(newValue);
    }

    parse(value){
        return parseInt(value, 10);
    }
}

let FF = new Hex(255);
console.log(FF.toString());
FF.valueOf() + 1 == 256;
let a = new Hex(10);
let b = new Hex(5);

console.log(a.plus(b).toString());

let string = a.plus(b).toString();

console.log(string ==='0xF');


