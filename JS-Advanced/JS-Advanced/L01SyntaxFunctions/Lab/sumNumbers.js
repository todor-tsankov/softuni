function sum(n, m){
    let start = Number(n);
    let end = Number(m);

    let sum = 0;

    for(let x = start; x <= end; x++){
        sum += x;
    }

    console.log(sum);
}

sum('1', '5');
sum('-8', '20');