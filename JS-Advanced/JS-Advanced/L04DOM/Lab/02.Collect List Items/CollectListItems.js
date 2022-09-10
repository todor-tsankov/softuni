function extractText() {
    const listItems = document.getElementById('items').children;
    document.getElementById('result').textContent = Array.from(listItems).map(x => x.textContent).join('\n');
}