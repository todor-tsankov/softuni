function calorieObject(strings){
    let obj = {};

    for (let i = 0; i < strings.length - 1; i += 2){
        let property = strings[i];
        let value = strings[i + 1];

        obj[property] = Number(value);
    }

    console.log(obj);
}

calorieObject(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']);
