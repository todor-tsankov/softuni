function tally(...params){
    const tally = {};

    params.forEach(x => {
        const type = typeof x;
        console.log(`${type}: ${x}`)

        if (tally[type] === undefined){
            tally[type] = 0;
        }

        tally[type]++;
    });

    const result = Object.entries(tally).sort((a, b) => b[1] - a[1]);
    result.forEach(x => console.log(`${x[0]} = ${x[1]}`));
}

console.log(tally('cat', 42, 'ab', function () { console.log('Hello world!'); }, {name: 2}, {name: 2}));