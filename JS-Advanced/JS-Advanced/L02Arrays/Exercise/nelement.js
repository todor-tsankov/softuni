function nelement(arr, n){
    let result = [];

    for(let x = 0; x < arr.length; x += n){
        result.push(arr[x]);
    }

    return result;
}

console.log(nelement(['5', 
'20', 
'31', 
'4', 
'20'], 
2
));
console.log(nelement(['dsa',
'asd', 
'test', 
'tset'], 
2
));