function sumTable() {
    const rows = Array.from(document.querySelectorAll('table tbody tr td:nth-child(2)')).map(x => Number(x.textContent));
    document.getElementById('sum').textContent = rows.reduce((acc, c) => acc + c).toString();
}