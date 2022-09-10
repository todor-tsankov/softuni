function printProducts(strings) {
    let products = [];

    strings.forEach(x => {
        let [name, price] = x.split(' : ');

        products.push({name, price});
    });

    products.sort((a, b) => a.name.localeCompare(b.name));

    let letter;
    products.forEach(x => {
        let currentLetter = x.name[0];

        if (currentLetter != letter) {
            letter = currentLetter;
            console.log(currentLetter);
        }
        console.log(`${x.name}: ${x.price}`);
    });
}

printProducts(['Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10']
);

printProducts(['Banana : 2',
    'Rubics Cube : 5',
    'Raspberry P : 4999',
    'Rolex : 100000',
    'Rollon : 10',
    'Rali Car : 2000000',
    'Pesho : 0.000001',
    'Barrel : 10']
);