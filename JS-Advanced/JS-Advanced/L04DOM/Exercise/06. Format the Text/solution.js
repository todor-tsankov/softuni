function solve() {
    let outputEl = document.getElementById('output');
    let sentences = document.getElementById('input').value.split('.').filter(x => x.length >= 1);

    outputEl.innerHTML = ``;

    for (let x = 0; x < sentences.length; x += 3){
        let currentSentences = sentences.slice(x, x + 3);
        outputEl.innerHTML += `<p>${currentSentences.join('.')}.</p>`;
    }
}