function spiral(x, y) {
    let counter = 0;
    let matrix = [];

    let startRow = 0;
    let endRow = x - 1;
    let startCol = 0;
    let endCol = y - 1;

    for (let row = 0; row < x; row++) {
        matrix.push([]);
    }

    while (true) {
        if (counter == x * y) {
            break;
        }

        for (let col = startCol; col <= endCol; col++) {
            matrix[startRow][col] = ++counter;
        }
        for (let row = ++startRow; row <= endRow; row++) {
            matrix[row][endCol] = ++counter;
        }
        for (let col = --endCol; col >= startCol; col--) {
            matrix[endRow][col] = ++counter;
        }
        for (let row = --endRow; row >= startRow; row--) {
            matrix[row][startCol] = ++counter;
        }

        startCol++;
    }

    matrix.forEach(x => console.log(x.join(' ')));
}

spiral(5, 5);