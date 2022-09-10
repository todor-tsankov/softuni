function solve(n, k){
    let result = [1];

    for(let x = 1; x < n; x++){
        let current =  0;

        for(let y = x - k; y <= x; y++){
            let el = result[y];

            if(typeof el != "undefined"){
                current += el;
            }
        }

        result.push(current);
    }

    return result;
}

function solve1(n, k){
    let result = [1];

    for(let x = 1; x < n; x++){
        let current =  result.slice(k * -1).reduce((acc, c) => acc + c)

        result.push(current);
    }

    return result;
}

console.log(solve1(6, 3));
console.log(solve1(8, 2));