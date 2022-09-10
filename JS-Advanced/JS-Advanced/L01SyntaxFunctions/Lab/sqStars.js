function square(x){
    let sideSize = 5;

    if(typeof(x) == 'number'){
        sideSize = x;
    }

    for(let y = 0; y < sideSize; y++){
        console.log('* '.repeat(sideSize).trim());
    }
}

square('');