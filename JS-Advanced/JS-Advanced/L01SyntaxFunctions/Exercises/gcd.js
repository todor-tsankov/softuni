function gcd(num1, num2){
    let max = Math.min(num1, num2);
    let gcd = 1;

    for(let x = 2; x <= max; x++){
        let success = num1 % x ==0 && num2 % x ==0;

        if(success){
            gcd = x;
        }
    }
    
    console.log(gcd);
}

gcd(15, 5);