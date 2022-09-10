function solve(carInfo){
    const brands = {};

    carInfo.forEach(x => {
        const [brandName, model, quantity] = x.split(' | ');

        if(brands[brandName] === undefined){
            brands[brandName] = {};
        }

        const brand = brands[brandName];

        if (brand[model] === undefined){
            brand[model] = 0;
        }

        brand[model] += Number(quantity);
    });

    for(let brandName in brands){
        console.log(brandName);
        const brand = brands[brandName];

        for(let modelName in brand){
            console.log(`###${modelName} -> ${brand[modelName]}`);
        }
    }
}

solve(['Audi | Q7 | 1000',
    'Audi | Q6 | 100',
    'BMW | X5 | 1000',
    'BMW | X6 | 100',
    'Citroen | C4 | 123',
    'Volga | GAZ-24 | 1000000',
    'Lada | Niva | 1000000',
    'Lada | Jigula | 1000000',
    'Citroen | C4 | 22',
    'Citroen | C5 | 10']
);
