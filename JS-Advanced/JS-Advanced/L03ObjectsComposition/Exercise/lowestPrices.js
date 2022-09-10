function findLowestPrice(strings) {
    let products = {};

    strings.forEach(x => {
        let [city, product, price] = x.split(' | ');
        let productObj = products[product];
        price = Number(price);

        if (productObj == undefined) {
            products[product] = {city, product, price};
        } else if (productObj.price > price) {
            productObj.city = city;
            productObj.price = price;
        }
    });

    for(let p of Object.values(products)){
        console.log(`${p.product} -> ${p.price} (${p.city})`);
    }
}

findLowestPrice(['Sample Town | Sample Product | 1000',
    'Sample Town | Orange | 2',
    'Sample Town | Peach | 1',
    'Sofia | Orange | 3',
    'Sofia | Peach | 2',
    'New York | Sample Product | 1000.1',
    'New York | Burger | 10']
);
