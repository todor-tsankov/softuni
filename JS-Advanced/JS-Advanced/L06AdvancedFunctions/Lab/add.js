function solution(number){
    return function add(plus){
        return number + plus;
    }
}

let add5 = solution(5);
console.log(add5(2));
console.log(add5(3));
