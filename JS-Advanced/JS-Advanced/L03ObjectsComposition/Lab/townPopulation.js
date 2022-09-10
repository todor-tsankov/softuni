function towns(townsInput){
    let towns = {};

    townsInput.forEach(x => {
        let [name, population] = x.split(' <-> ');
        population = Number(population);

        if(towns[name] == undefined){
            towns[name]= 0;
        }

        towns[name] += population;
    });

    for(let name in towns){
        console.log(`${name} : ${towns[name]}`);
    }
}

towns(['Sofia <-> 1200000',
'Montana <-> 20000',
'New York <-> 10000000',
'Washington <-> 2345000',
'Las Vegas <-> 1000000']
);

towns(['Istanbul <-> 100000',
'Honk Kong <-> 2100004',
'Jerusalem <-> 2352344',
'Mexico City <-> 23401925',
'Istanbul <-> 1000']
);