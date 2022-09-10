function extract(arr) {
    let result = [arr[0]];

    arr.forEach(x => {
        if (x >= result[result.length - 1]) {
            result.push(x)
        }
    });

    if(result.length > 1){
        result.shift();
    }

    return result;
}

console.log(extract([20, 3, 2, 15,6, 1]));