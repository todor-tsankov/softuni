function aggregate(numbers){
    let sum = 0;
    let inverseSum = 0;
    let concat = '';

    for(let x = 0; x < numbers.length; x++){
        let current = numbers[x];

        sum += current;
        inverseSum += 1 / current;
        concat += current;
    }

    console.log(sum);
    console.log(inverseSum);
    console.log(concat);
}

aggregate([1, 2, 3]);
aggregate([2, 4, 8, 16]);