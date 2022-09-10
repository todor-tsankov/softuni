function makeCar(requirements) {
    let engines = [makeEngine(90, 1800), makeEngine(120, 2400), makeEngine(200, 3500)];
    let carriages = [makeCarriage('hatchback', requirements.color), makeCarriage('coupe', requirements.color)];

    if (requirements.wheelsize % 2 == 0){
        requirements.wheelsize--;
    }

    return {
        model: requirements.model,
        engine: engines.find(x => x.power >= requirements.power),
        carriage: carriages.find(x => x.type == requirements.carriage),
        wheels: [0, 0, 0, 0].fill(requirements.wheelsize, 0, 4),
    };

    function makeEngine(power, volume) {
        return {power, volume,};
    }

    function makeCarriage(type, color) {
        return {type, color,};
    }
}

console.log(makeCar({
        model: 'VW Golf II',
        power: 90,
        color: 'blue',
        carriage: 'hatchback',
        wheelsize: 14
    }
));

console.log(makeCar({
        model: 'Opel Vectra',
        power: 110,
        color: 'grey',
        carriage: 'coupe',
        wheelsize: 17
    }
));