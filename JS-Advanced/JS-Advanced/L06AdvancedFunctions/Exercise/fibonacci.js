function getFibonator() {
    let currentNumber = 0;
    let lastNumber = 0;

    return () => {
        if (currentNumber === 0){
            currentNumber++;
            return currentNumber;
        }
        else if(lastNumber === 0){
            lastNumber++;
            return lastNumber;
        }

        let result = lastNumber + currentNumber;

        lastNumber = currentNumber;
        currentNumber = result;

        return currentNumber;
    };
}

let fib = getFibonator();
console.log(fib()); // 1
console.log(fib()); // 1
console.log(fib()); // 2
console.log(fib()); // 3
console.log(fib()); // 5
console.log(fib()); // 8
console.log(fib());
