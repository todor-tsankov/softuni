function sort(arr){
    arr.sort((a, b) => a.localeCompare(b));
    let result = '';

    for(let x = 0; x < arr.length; x++){
        result += `${x + 1}.${arr[x]}\n`;
    }

    return result;
}

console.log(sort(["John", "Bob", "Christina", "Ema"]));