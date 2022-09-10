function makeHeroes(strings) {
    let heroes = [];

    strings.forEach(x => {
        let splitted = x.split(' / ');

        heroes.push({
            name: splitted[0],
            level: Number(splitted[1]),
            items: splitted.length > 2 ? splitted[2].split(', ') : [],
        });
    });

    return JSON.stringify(heroes);
}

console.log(makeHeroes(
    ['Isacc / 25 / Apple, GravityGun',
        'Derek / 12 / BarrelVest, DestructionSword',
        'Hes / 1 / Desolator, Sentinel, Antara']
));

console.log(makeHeroes(['Jake / 1000 / Gauss, HolidayGrenade']));