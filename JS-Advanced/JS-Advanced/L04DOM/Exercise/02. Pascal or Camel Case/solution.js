function solve() {
    let words = document.getElementById('text').value.split(' ').filter(x => x.length > 0).map(x => x.toLowerCase());
    let convention = document.getElementById('naming-convention').value;

    if (convention == 'Camel Case') {
        words = words.reduce((acc, c) => acc + c[0].toUpperCase() + c.slice(1));
    } else if (convention == 'Pascal Case') {
        words[0] = words[0][0].toUpperCase() + words[0].slice(1);
        words = words.reduce((acc, c) => acc + c[0].toUpperCase() + c.slice(1));
    } else {
        words = 'Error!';
    }

    document.getElementById('result').textContent = words;
}