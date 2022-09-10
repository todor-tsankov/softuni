function biggest(matrix){
    let biggest = matrix[0][0];

    for(let arr of matrix){
        for(let num of arr){
            if(num > biggest){
                biggest = num;
            }
        }
    }

    return biggest;
}

console.log(biggest(
    [[20, 50, 10],
    [8, 33, 145]]));

console.log(biggest(
    [[3, 5, 7, 12],
    [-1, 4, 33, 2],
    [8, 3, 0, 4]]));