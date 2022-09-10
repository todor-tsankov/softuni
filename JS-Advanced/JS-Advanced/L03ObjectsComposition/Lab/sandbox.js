function demo() {
    const person = {
        name: 'Toshko',
        age: 2,
        mama: {
            name: `cveta`,
            age: 43,
            dog: {
                lum: 'pam pam',
                as: 4,
            }
        }
    }

    const {mama: {dog: {as}}} = person;

    console.log(as);
}

demo();