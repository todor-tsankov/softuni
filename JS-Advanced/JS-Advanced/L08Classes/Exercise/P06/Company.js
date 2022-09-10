class Company {
    constructor() {
        this.departments = [];
    }

    addEmployee(username, salary, position, department) {
        this.validate(username);
        this.validate(salary, true);
        this.validate(position);
        this.validate(department);

        const employee = {
            name: username,
            salary: salary,
            position: position,
        };

        const departmentIndex = this.departments.findIndex(x => x.name === department);

        if (departmentIndex === -1) {
            this.departments.push({
                name: department,
                employees: [employee],
            });
        } else {
            this.departments[departmentIndex].employees.push(employee);
        }

        return `New employee is hired. Name: ${employee.name}. Position: ${employee.position}`;
    }

    bestDepartment() {
        const best = this.departments.reduce((a, c) => {
            const previousAverage = a.employees.reduce((acc, cu) => acc + cu.salary / a.employees.length, 0);
            const currentAverage = c.employees.reduce((acc, cu) => acc + cu.salary / c.employees.length, 0);

            if (previousAverage > currentAverage) {
                return a;
            }

            return c;
        });

        const resultLines = [];
        const sortedEmployees = best.employees.sort((a, b) => a.name.localeCompare(b.name)).sort((a, b) => b.salary - a.salary);
        const averageSalary = best.employees.reduce((a, c) => a + c.salary / best.employees.length, 0).toFixed(2);

        resultLines.push(`Best Department is: ${best.name}`);
        resultLines.push(`Average salary: ${averageSalary}`);

        sortedEmployees.forEach(x => resultLines.push(`${x.name} ${x.salary} ${x.position}`));

        return resultLines.join('\n');
    }

    validate(value, isSalary) {
        if (value === undefined || value === null || value === '') {
            throw  new Error('Invalid input!');
        }

        if (isSalary) {
            if (typeof value !== 'number' || value < 0) {
                throw  new Error('Invalid input!');
            }
        }
    }
}

let c = new Company();
c.addEmployee("Stanimir", 2000, "engineer", "Construction");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.bestDepartment());
