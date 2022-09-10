function add(num1) {
    let calc  = (num2) => add(num1 + num2);
    calc.toString = () => num1.toString();

    return calc;
}

console.log(add(1)(1)(1).toString());