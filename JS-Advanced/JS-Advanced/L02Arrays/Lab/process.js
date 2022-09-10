function process(arr){
    let resultArr = [];

    for(let x = 0; x < arr.length; x++){
        if(x % 2 != 0){
            resultArr.push(arr[x]);
        }
    }

    return resultArr.map(x => x * 2).reverse().join(' ');
}

console.log(process([10, 15, 20, 25]));
console.log(process([3, 0, 10, 4, 7, 3]));