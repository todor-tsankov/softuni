function solve() {
    class Person {
        constructor(name, email) {
            this.name = name;
            this.email = email;
        }

        toString() {
            return `${this.constructor.name} (name: ${this.name}, email: ${this.email})`;
        }
    }

    class Teacher extends Person {
        constructor(name, email, subject) {
            super(name, email);
            this.subject = subject;
        }

        toString() {
            return super.toString().slice(0, -1) + `, subject:${this.subject})`;
        }
    }

    class Student extends Person {
        constructor(name, email, course) {
            super(name, email);
            this.course = course;
        }

        toString() {
            return super.toString().slice(0, -1) + `, course: ${this.course})`;
        }
    }

    let person = new Person('personToshko', 'personToshko@abv.bg');
    let teacher = new Teacher('teacherToshko', 'teacherToshko@abv.bg', 'math');
    let student = new Student('studentToshko', 'studentToshko@abv.bg', 'course');

    console.log(person);
    console.log(person.toString());
    console.log(teacher);
    console.log(teacher.toString());
    console.log(student);
    console.log(student.toString());

    return {
        Person,
        Student,
        Teacher,
    }
}

solve();

function inheritingAndReplacingToString() {
    class Person{
        constructor(name, email){
            this.name = name;
            this.email = email;
        }

        toString(){
            return `${this.constructor.name} (name: ${this.name}, email: ${this.email})`;
        }
    }

    class Teacher extends Person{
        constructor(name, email, subject){
            super(name, email);
            this.subject = subject;
        }

        toString(){
            return super.toString().substr(0, super.toString().length-1) + `, subject: ${this.subject})`;
        }
    }

    class Student extends Person{
        constructor(name, email, course){
            super(name, email);
            this.course = course;
        }

        toString(){
            return super.toString().substr(0, super.toString().length-1) + `, course: ${this.course})`;
        }
    }



    return {Person, Student, Teacher}
}

inheritingAndReplacingToString();

