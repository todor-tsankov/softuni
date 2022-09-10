function validate(x1, y1, x2, y2){
    let validFirst = isValid(x1, y1, 0, 0) ? 'valid' : 'invalid';
    let validSecond = isValid(x2, y2, 0, 0) ? 'valid' : 'invalid';
    let validThird = isValid(x1, y1, x2, y2) ? 'valid' : 'invalid';

    console.log(`{${x1}, ${y1}} to {0, 0} is ${validFirst}`)
    console.log(`{${x2}, ${y2}} to {0, 0} is ${validSecond}`)
    console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is ${validThird}`)

    function isValid(x1, y1, x2, y2){
        let x = Math.max(x1, x2) - Math.min(x1, x2);
        let y = Math.max(y1, y2) -  Math.min(y1, y2);

        let distance = Math.sqrt(x ** 2 + y ** 2);

        return distance == Math.round(distance);
    }
}

validate(3, 0, 0, 4);
validate(2, 1, 1, 1);