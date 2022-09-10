function smallest(arr){
    arr.sort((a, b) => a - b);
    return arr[0] + ' ' + arr[1];
}

console.log(smallest([30, 15, 50, 5]));
console.log(smallest([3, 0, 10, 4, 7, 3]));