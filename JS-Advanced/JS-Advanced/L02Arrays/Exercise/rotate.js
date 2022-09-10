function rotate(arr, n){
    for(let x = 0; x < n; x++){
        arr.unshift(arr.pop());
    }

    return arr.join(' ');
}

console.log(rotate(['1', '2', '3', '4'], 2));
console.log(rotate(['Banana', 'Orange', 'Coconut', 'Apple'], 15));