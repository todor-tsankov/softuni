function orbit(arr) {
    let cols = Number(arr[0]);
    let rows = Number(arr[1]);
    let x = Number(arr[2]);
    let y = Number(arr[3]);

    let matrix = [];

    for (let row = 0; row < rows; row++) {
        let currentRow = [];

        for (let col = 0; col < cols; col++) {
            let num = Math.max(Math.abs(x - row), Math.abs(y - col)) + 1;
            currentRow.push(num);
        }

        matrix.push(currentRow);
    }

    matrix.forEach(x => console.log(x.join(' ')));
}

orbit([4, 4, 0, 0]);
orbit([5, 5, 2, 2]);
orbit([3, 3, 2, 2]);