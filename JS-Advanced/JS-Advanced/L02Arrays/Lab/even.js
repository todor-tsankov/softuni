function even(arr){
    let result = [];

    for (let x = 0; x < arr.length; x += 2) {
        result.push(arr[x]);
    }

    return result.join(' ');
}

console.log(even(['20', '30', '40', '50', '60']));
console.log(even(['5', '10']));