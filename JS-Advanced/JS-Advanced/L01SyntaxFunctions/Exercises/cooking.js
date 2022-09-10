function cook(...params) {
    let number = Number(params[0]);

    for (let x = 1; x <= 5; x++) {
        let op = params[x];

        if (op == 'chop') {
            number /= 2;
        } else if (op == 'dice') {
            number = Math.sqrt(number);
        } else if (op == 'spice') {
            number++;
        } else if (op == 'bake') {
            number *= 3;
        } else if (op == 'fillet') {
            number *= 0.8;
        }
        console.log(number);
    }
}

cook('32', 'chop', 'chop', 'chop', 'chop', 'chop');
cook('9', 'dice', 'spice', 'chop', 'bake', 'fillet');