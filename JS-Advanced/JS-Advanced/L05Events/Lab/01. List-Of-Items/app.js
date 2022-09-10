function addItem() {
    let inputElement = document.getElementById('newItemText');

    if(!inputElement.value){
        return;
    }

    let ul = document.getElementById('items');
    let li = document.createElement('li');
    li.textContent = inputElement.value;

    ul.appendChild(li);
    inputElement.value = '';
}