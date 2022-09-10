function solve() {
    class Employee {
        constructor(name, age) {
            if (new.target === Employee) {
                throw new Error('Cannot instantiate directly.');
            }

            this.name = name;
            this.age = age;
            this.salary = 0;

            this.tasks = [];
        }

        getSalary() {
            return this.salary;
        }

        work() {
            let task = this.tasks.shift();
            this.tasks.push(task);
            console.log(task.replace('{name}', this.name));
        }

        collectSalary() {
            console.log(`${this.name} received ${this.getSalary()} this month.`);
        }
    }

    class Junior extends Employee {
        constructor(name, age) {
            super(name, age);

            this.tasks.push('{name} is working on a simple task.');
        }
    }

    class Senior extends Employee {
        constructor(name, age) {
            super(name, age);

            this.tasks.push('{name} is working on a complicated task.');
            this.tasks.push('{name} is taking time off work.');
            this.tasks.push('{name} is supervising junior workers.');
        }
    }

    class Manager extends Employee {
        constructor(name, age) {
            super(name, age);

            this.divident = 0;
            this.tasks.push('{name} scheduled a meeting.');
            this.tasks.push('{name} is preparing a quarterly report.');
        }

        getSalary() {
            return this.salary + this.divident;
        }
    }

    return {Employee, Junior, Senior, Manager};
}

let {Employee, Junior, Senior, Manager} = solve();

var guy1 = new Junior('pesho', 20);
var guy2 = new Senior('gosho', 21);
var guy3 = new Manager('ivan', 22);

let a;