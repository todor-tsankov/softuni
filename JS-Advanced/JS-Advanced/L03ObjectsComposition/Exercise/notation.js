function notation(operations) {
    let operand = {
        ['+']: function (num1, num2) {
            return num1 + num2;
        },
        ['-']: function (num1, num2) {
            return num1 - num2;
        },
        ['*']: function (num1, num2) {
            return num1 * num2;
        },
        ['/']: function (num1, num2) {
            return num1 / num2;
        },
    };

    let numbers = [];

    for (let op of operations) {
        if (operand[op] === undefined) {
            numbers.push(Number(op));
        } else {
            if (numbers.length < 2) {
                console.log("Error: not enough operands!");
                return;
            }

            let secondNum = numbers.pop();
            let firstNum = numbers.pop();

            let result = operand[op](firstNum, secondNum);
            numbers.push(result);
        }
    }

    let result = numbers[0];

    if (numbers.length > 1) {
        result = 'Error: too many operands!';
    }

    console.log(result);
}

notation([3, 4, '+']);
notation([5, 3, 4, '*', '-']);