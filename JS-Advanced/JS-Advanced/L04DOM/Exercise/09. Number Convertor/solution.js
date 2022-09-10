function solve() {
    document.querySelector('body div button').addEventListener('click', onClick);

    let toSelect = document.getElementById('selectMenuTo');
    toSelect.innerHTML += '<option value="binary">Binary</option>';
    toSelect.innerHTML += '<option value="hexadecimal">Hexadecimal</option>';

    function onClick(){
        let toSelected = document.getElementById('selectMenuFrom').value === 'decimal';
        let optionSelected = document.getElementById('selectMenuTo').value;
        let numberToConvert = Number(document.getElementById('input').value);

        if (optionSelected == '' || isNaN(numberToConvert)){
            return;
        }

        let resultStr;

        if (optionSelected == 'binary'){
            resultStr = numberToConvert.toString(2);
        }
        else if (optionSelected == 'hexadecimal'){
            resultStr = numberToConvert.toString(16).toUpperCase();
        }

        document.getElementById('result').value = resultStr;
    }
}