function dia(matrix){
    let mainSum = 0;
    let secondSum = 0;

    let length = matrix.length;

    for(let x = 0; x < length; x++){
        mainSum += matrix[x][x];
        secondSum += matrix[x][length - 1 -x];
    }

    return mainSum + ' ' + secondSum;
}

console.log(dia(
    [[20, 40],
    [10, 60]]));

console.log(dia(
    [[3, 5, 17],
    [-1, 7, 14],
    [1, -8, 89]]));