function addItem() {
    const textInput = document.getElementById('newItemText');
    const valueInput = document.getElementById('newItemValue');

    const select = document.getElementById('menu');

    const trimmedText = textInput.value.trim();
    const trimmedValue = valueInput.value.trim();

    if (trimmedText.length < 1 || trimmedValue.length < 1){
        return;
    }

    const option = document.createElement('option');
    option.textContent = trimmedText;
    option.value = trimmedValue;

    select.appendChild(option);

    textInput.value = '';
    valueInput.value = '';
}