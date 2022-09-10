function addItem() {
    let inputElement = document.getElementById('newText');

    if (!inputElement.value) {
        return;
    }

    let ul = document.getElementById('items');
    let li = document.createElement('li');
    li.textContent = inputElement.value;

    let a = document.createElement('a');
    a.addEventListener('click', remove);
    a.textContent = '[Delete]';
    a.href = '#';

    li.appendChild(a);
    ul.appendChild(li);
    inputElement.value = '';

    function remove(event){
        event.target.parentElement.remove();
    }
}