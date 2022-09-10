function attack(arr) {
    let matrix = [];

    for (let str of arr) {
        matrix.push(str.split(' ').map(x => Number(x)));
    }

    let firstDiagonalSum = 0;
    let secondDiagonalSum = 0;

    for (let x = 0; x < matrix.length; x++) {
        firstDiagonalSum += matrix[x][x];
        secondDiagonalSum += matrix[x][matrix.length - 1 - x];
    }

    if (firstDiagonalSum == secondDiagonalSum) {
        for (let row = 0; row < matrix.length; row++) {
            for (let col = 0; col < matrix.length; col++) {
                if (row != col && col != matrix.length - 1 - row) {
                    matrix[row][col] = firstDiagonalSum;
                }
            }
        }
    }

    matrix.forEach(x => console.log(x.join(' ')))
}

attack(['5 3 12 3 1',
    '11 4 23 2 5',
    '101 12 3 21 10',
    '1 4 5 2 2',
    '5 22 33 11 1']);

console.log('----------------------')

attack(['1 1 1',
    '1 1 1',
    '1 1 0']);