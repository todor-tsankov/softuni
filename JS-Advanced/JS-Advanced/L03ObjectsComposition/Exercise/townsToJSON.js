function json(strings) {
    let towns = [];
    let [prop1, prop2, prop3] = getArr(strings[0]);

    strings.shift();

    strings.forEach(x => {
        let [town, longitude, latitude] = getArr(x);
        let object = {
            [prop1]: town,
            [prop2]: Number(Number(longitude).toFixed(2)),
            [prop3]: Number(Number(latitude).toFixed(2)),
        };
        towns.push(object);
    });

    return JSON.stringify(towns);

    function getArr(string) {
        return string.split('|').map(x => x.trim()).filter(x => x.length > 1)
    }
}

console.log(json(['| Town | Latitude | Longitude |',
    '| Sofia | 42.696552 | 23.32601 |',
    '| Beijing | 39.913818 | 116.363625 |']
));
console.log(json(['| Town | Latitude | Longitude |',
    '| Veliko Turnovo | 43.0757 | 25.6172 |',
    '| Monatevideo | 34.50 | 56.11 |']
));