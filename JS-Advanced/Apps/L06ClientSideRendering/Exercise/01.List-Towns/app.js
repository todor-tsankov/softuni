import {html, render} from 'https://unpkg.com/lit-html?module'; //To save space when sending to softuni

const townsInput = document.getElementById('towns');
const loadBtn = document.getElementById('btnLoadTowns');

const rootDiv = document.getElementById('root');

loadBtn.addEventListener('click', (e) => {
    e.preventDefault();

    if(townsInput.value.trim() === ''){
        return;
    }

    const towns = townsInput.value
        .split(', ')
        .map(x => x.trim())
        .filter(x => x.length > 0)
        .map(x => html`<li>${x}</li>`);

    const ul = html`<ul>${towns}</ul>`;
    render(ul, rootDiv);

    townsInput.value = '';
});