function Person(firstName, lastName){
    this.firstName = firstName;
    this.lastName = lastName;

    Object.defineProperty(this, 'fullName', {
        get: () => this.firstName + ' ' + this.lastName,
        set: v => {
            const [firstName, lastName] = v.split(' ');

            if(typeof firstName !== 'string' || typeof lastName !== 'string'){
               return;
            }

            this.firstName = firstName;
            this.lastName = lastName;
        }
    });
}

let person = new Person("Albert", "Simpson");
console.log(person.fullName); //Albert Simpson
person.firstName = "Simon";
console.log(person.fullName); //Simon Simpson
person.fullName = "Peter";
console.log(person.firstName);  // Simon
console.log(person.lastName);  // Simpson

