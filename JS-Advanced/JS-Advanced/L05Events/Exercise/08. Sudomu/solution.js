function solve() {
    let table = document.querySelector('table');
    let check = document.querySelector('#check p');
    let buttons = document.querySelectorAll('button');

    buttons[0].addEventListener('click', checkSudomu);
    buttons[1].addEventListener('click', clear);

    let inputs = document.getElementsByTagName('input');

    function clear() {
        Array.from(inputs).forEach(x => x.value = '');
        check.style.color = 'none';
        table.style.border = 'none';
        check.textContent = '';
    }

    function checkSudomu() {
        let numbers = Array.from(inputs).map(x => Number(x.value));

        if (isValid(numbers)) {
            check.style.color = 'green';
            check.textContent = 'You solve it! Congratulations!';

            table.style.border = '2px solid green';

        } else {
            check.style.color = 'red';
            check.textContent = 'NOP! You are not done yet...';

            table.style.border = '2px solid red';
        }

        function isValid(numbers) {
            if (numbers.some(x => x < 1 || x > 3)){
                return false;
            }

            let matrix = [];

            matrix.push(numbers.slice(0, 3));
            matrix.push(numbers.slice(3, 6));
            matrix.push(numbers.slice(6, 9));

            for (let row = 0; row < 3; row++) {
                let rowNumbers = [];
                let colNumbers = [];

                for (let col = 0; col < 3; col++) {
                    let currentOnRow = matrix[row][col];
                    let currentOnCol = matrix[col][row];

                    if (rowNumbers.includes(currentOnRow) || colNumbers.includes(currentOnCol)) {
                        return false;
                    }

                    rowNumbers.push(currentOnRow);
                    colNumbers.push(currentOnCol);
                }
            }

            return true;
        }
    }
}
