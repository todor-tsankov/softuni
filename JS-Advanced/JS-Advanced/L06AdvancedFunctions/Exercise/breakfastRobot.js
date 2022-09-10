function solution() {
    const recipes = {
        apple: makeProduct(0, 1, 0, 2,),
        lemonade: makeProduct(0, 10, 0, 20,),
        burger: makeProduct(0, 5, 7, 3,),
        eggs: makeProduct(5, 0, 1, 1,),
        turkey: makeProduct(10, 10, 10, 10,),
        stock: makeProduct(0, 0, 0, 0),
    };

    function makeProduct(protein, carbohydrate, fat, flavour) {
        let obj = {
            protein,
            carbohydrate,
            fat,
            flavour,
        };

        obj.cook = (stock, quantity) => {
            for (let prop in stock) {
                if (stock[prop] < obj[prop] * quantity) {
                    return `Error: not enough ${prop} in stock`;
                }
            }

            for (let prop in stock) {
                stock[prop] -= obj[prop] * quantity;
            }

            return 'Success';
        };

        return obj;
    }

    return (string) => {
        let [command, type, quantity] = string.split(' ');

        if (command === 'prepare') {
            return recipes[type].cook(recipes['stock'], quantity);
        } else if (command === 'restock') {
            recipes['stock'][type] += Number(quantity);
            return 'Success';
        } else {
            let result = [];

            for (let prop in recipes['stock']) {
                if (prop === 'cook') {
                    continue;
                }

                result.push(`${prop}=${recipes['stock'][prop]}`);
            }

            return result.join(' ');
        }
    };
}

let manager = solution();
console.log(manager('restock protein 100'));
console.log(manager('restock carbohydrate 100'));
console.log(manager('restock fat 100'));
console.log(manager('restock flavour 100'));
console.log(manager('report'));
