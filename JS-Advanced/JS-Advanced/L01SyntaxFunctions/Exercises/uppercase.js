function solve(text) {
    let regex = /\w+/g;
    let results = [];

    while (true) {
        let result = regex.exec(text);

        if (result == null) {
            break;
        }

        results.push(result[0].toUpperCase());
    }

    console.log(results.join(', '));
}

solve('Hi, how are you?');