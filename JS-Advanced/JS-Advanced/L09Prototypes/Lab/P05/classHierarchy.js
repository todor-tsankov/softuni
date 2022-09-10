function solve() {
    class Figure {
        constructor(units) {
            this.units = 'cm';

            if (units !== undefined) {
                this.units = units;
            }
        }

        get area() {
            return 0;
        }

        changeUnits(value) {
            this.units = value;
        }

        toUnits(value){
            if(this.units === 'mm'){
                return value * 10;
            }
            else if(this.units === 'm'){
                return value / 100;
            }

            return value;
        }

        toString() {
            return `Figures units: ${this.units}`;
        }
    }

    class Circle extends Figure {
        constructor(radius, units) {
            super(units);
            this.radius = radius;
        }

        get area() {
            return super.toUnits(this.radius) ** 2 * Math.PI;
        }

        toString() {
            return `${super.toString()} Area: ${this.area} - radius: ${super.toUnits(this.radius)}`;
        }
    }

    class Rectangle extends Figure {
        constructor(width, height, units) {
            super(units);

            this.width = width;
            this.height = height;
        }

        get area() {
            return this.toUnits(this.height) * this.toUnits(this.width);
        }

        toString() {
            return `${super.toString()} Area: ${this.area} - width: ${super.toUnits(this.width)}, height: ${super.toUnits(this.height)}`;
        }
    }

    let c = new Circle(5);
    console.log(c.area); // 78.53981633974483
    console.log(c.toString()); // Figures units: cm Area: 78.53981633974483 - radius: 5

    let r = new Rectangle(3, 4, 'mm');
    console.log(r.area); // 1200
    console.log(r.toString()); //Figures units: mm Area: 1200 - width: 30, height: 40

    r.changeUnits('cm');
    console.log(r.area); // 12
    console.log(r.toString()); // Figures units: cm Area: 12 - width: 3, height: 4

    c.changeUnits('mm');
    console.log(c.area); // 7853.981633974483
    console.log(c.toString()) // Figures units: mm Area: 7853.981633974483 - radius: 50


    return {Figure, Circle, Rectangle};
}

solve();