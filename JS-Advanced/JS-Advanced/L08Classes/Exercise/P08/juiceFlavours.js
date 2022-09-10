function juice(arr) {
    const juices = new Map();
    const bottles = new Map();

    arr.forEach(x => {
        const [name, quantity] = x.split(' => ');

        if (!juices.has(name)) {
            juices.set(name, 0);
        }

        const totalQuantity = juices.get(name) + Number(quantity);

        if (totalQuantity >= 1000) {
            if (!bottles.has(name)) {
                bottles.set(name, 0);
            }

            let bottlesQuantity = bottles.get(name);
            let newBottles = Math.floor(totalQuantity / 1000);

            bottles.set(name, bottlesQuantity + newBottles);
            juices.set(name, totalQuantity - newBottles * 1000);
        } else {
            juices.set(name, totalQuantity);
        }
    });

    bottles.forEach((quantity, name) => {
        console.log(`${name} => ${quantity}`);
    });
}

juice(['Orange => 2000',
    'Peach => 1432',
    'Banana => 450',
    'Peach => 600',
    'Strawberry => 549']
);

console.log('-------------');

juice(['Kiwi => 234',
    'Pear => 2345',
    'Watermelon => 3456',
    'Kiwi => 4567',
    'Pear => 5678',
    'Watermelon => 6789']
);