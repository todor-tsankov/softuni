function count(matrix) {
    let pairs = 0;

    for (let x = 0; x < matrix.length; x++) {
        let arr = matrix[x];

        for (let y = 0; y < arr.length; y++) {
            let current = matrix[x][y];

            if (x - 1 >= 0) {
                if (current == matrix[x - 1][y]) {
                    pairs++;
                }
            }

            if (x + 1 < matrix.length) {
                if (current == matrix[x + 1][y]) {
                    pairs++;
                }
            }

            if (y - 1 >= 0) {
                if (current == matrix[x][y - 1]) {
                    pairs++;
                }
            }

            if (y + 1 < arr.length) {
                if (current == matrix[x][y + 1]) {
                    pairs++;
                }
            }
        }
    }

    return pairs / 2;
}

console.log(count(
    [['2', '3', '4', '7', '0'],
    ['4', '0', '5', '3', '4'],
    ['2', '3', '5', '4', '2'],
    ['9', '8', '7', '5', '4']]
));

console.log(count(
    [['test', 'yes', 'yo', 'ho'],
    ['well', 'done', 'yo', '6'],
    ['not', 'done', 'yet', '5']]
));