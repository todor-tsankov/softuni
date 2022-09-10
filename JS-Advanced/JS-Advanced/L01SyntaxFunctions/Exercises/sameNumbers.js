function same(number){
    let numberStr = number.toString();
    let result = true;
    let symbol = numberStr[0];
    let sum = Number(symbol);

    for(let x = 1; x < numberStr.length; x++){
        sum += Number(numberStr[x]);

        if(numberStr[x] != symbol){
            result = false;
        }
    }

    console.log(result);
    console.log(sum);
}

same('111111');
same('121111');
same('12222');