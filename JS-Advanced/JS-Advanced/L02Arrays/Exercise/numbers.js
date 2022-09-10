function sort(arr){
    arr.sort((a, b) => a - b);
    let result = [];

    for(let x = 0; x < arr.length / 2; x++){
        result.push(arr[x]);

        if(x != arr.length - 1 - x){
            result.push(arr[arr.length - 1 - x]);
        }
    }

    return result;
}

console.log(sort([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));