function play(moves) {
    let field =
        [[false, false, false],
        [false, false, false],
        [false, false, false]];

    let winner;
    let counter = 0;
    let firstTurn = true;

    for (let move of moves) {
        if(++counter > 9){
            break;
        }

        let row = Number(move[0]);
        let col = Number(move[2]);

        if (field[row][col] !== false) {
            counter--;
            console.log('This place is already taken. Please choose another!');

            continue;
        } else if (firstTurn) {
            field[row][col] = 'X';
        } else if (!firstTurn) {
            field[row][col] = 'O';
        }

        firstTurn = !firstTurn;
        winner = checkForWinner(field);

        if (winner != null) {
            break;
        }
    }

    if (winner == 'X' || winner == 'O') {
        console.log(`Player ${winner} wins!`);
    }
    else {
        console.log('The game ended! Nobody wins :(')
    }

    field.forEach(x => console.log(x.join('\t')));

    function checkForWinner(field) {
        let strings = [];

        strings.push(field[0][0] + field[0][1] + field[0][2]);
        strings.push(field[1][0] + field[1][1] + field[1][2]);
        strings.push(field[2][0] + field[2][1] + field[2][2]);

        strings.push(field[0][0] + field[1][0] + field[2][0]);
        strings.push(field[1][0] + field[1][1] + field[1][2]);
        strings.push(field[2][0] + field[2][1] + field[2][2]);

        strings.push(field[0][0] + field[1][1] + field[2][2]);
        strings.push(field[0][2] + field[1][1] + field[2][0]);

        if (strings.includes('XXX')) {
            return 'X';
        } else if (strings.includes('OOO')) {
            return 'O';
        }

        return null;
    }
}

play(["0 1", "0 0", "0 2", "2 0", "1 0", "1 1", "1 2", "2 2", "2 1", "0 0"]);
play(["0 0", "0 0", "1 1", "0 1", "1 2", "0 2", "2 2", "1 2", "2 2", "2 1"]);
play(["0 1", "0 0", "0 2", "2 0", "1 0", "1 2", "1 1", "2 1", "2 2", "0 0"]);