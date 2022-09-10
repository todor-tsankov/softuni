function colorize() {
    const rows = document.querySelectorAll('table tr');

    for (let x = 1; x < rows.length; x += 2){
        rows[x].style.backgroundColor = 'Teal';
    }
}