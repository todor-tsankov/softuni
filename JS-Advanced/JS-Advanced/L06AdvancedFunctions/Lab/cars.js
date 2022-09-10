function solve(commands) {
    let processor = createProcessor();

    commands.forEach(x => {
        let args = x.split(' ');

        if (args[0] === 'create') {
            if (args[2] === undefined) {
                processor.create(args[1]);
            } else {
                processor.createInherit(args[1], args[3]);
            }
        } else if (args[0] === 'set') {
            processor.set(args[1], args[2], args[3])
        } else if (args[0] === 'print') {
            processor.print(args[1]);
        }
    });

    function createProcessor() {
        function getProperties(obj) {
            let arr = [];

            for (let key in obj) {
                if (key === 'name') {
                    continue;
                }

                let value = obj[key];

                if (typeof value !== 'object') {
                    arr.push(`${key}:${value}`);
                }
            }

            if (obj.parent !== undefined){
                let newArr = getProperties(obj.parent);
                newArr.forEach(x => arr.push(x));
            }

            return arr;
        }

        let cars = [];

        return {
            create: (name) => cars.push({name}),
            createInherit: (name, parentName) => cars.push({name, parent: cars.find(x => x.name === parentName)}),
            set: (name, key, value) => cars.find(x => x.name === name)[key] = value,
            print: (name) => console.log(getProperties(cars.find(x => x.name == name)).join(', ')),
        };
    }
}

solve(['create c1', 'create c2 inherit c1', 'set c1 color red', 'set c2 model new', 'print c1', 'print c2']);
