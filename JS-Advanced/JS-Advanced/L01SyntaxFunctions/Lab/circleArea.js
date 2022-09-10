function area(radius) {
    let isNumber = typeof (radius) == 'number' && !Number.isNaN(radius);

    if (isNumber) {
        let area = (radius ** 2 * Math.PI).toFixed(2);
        console.log(area);
    } else {
        console.log(`We can not calculate the circle area, because we receive a ${typeof(radius)}.`);
    }
}

area(5);
area('name');