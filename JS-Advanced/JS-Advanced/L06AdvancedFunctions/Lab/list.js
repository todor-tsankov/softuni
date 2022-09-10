function solve(array) {
    let processor = createProcessor();

    array.forEach(x => {
       let [command, value] = x.split(' ');
       processor[command](value);
    });

    function createProcessor() {
        let collection = [];

        return {
            add: (string) => collection.push(string),
            remove: (string) => collection = collection.filter(x => x !== string),
            print: () => console.log(collection.join(','))
        };
    }
}

solve(['add hello', 'add again', 'remove hello', 'add again', 'print']);
solve(['add pesho', 'add george', 'add peter', 'remove peter','print']);