function toggle() {
    let hiddenText = document.getElementById('extra');
    let button = document.getElementsByClassName('button')[0];

    if (button.textContent == 'More') {
        hiddenText.style.display = 'block';
        button.textContent = 'Less';
    } else {
        hiddenText.style.display = 'none'
        button.textContent = 'More';
    }
}