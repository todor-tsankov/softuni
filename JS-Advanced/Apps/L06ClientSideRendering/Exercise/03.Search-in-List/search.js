import {html, render} from 'https://unpkg.com/lit-html?module';
import {towns} from './towns.js';

const townsDiv = document.getElementById('towns');
const searchInput = document.getElementById('searchText');
const searchBtn = document.getElementById('searchBtn');
const resultDiv = document.getElementById('result');

let matchesFound = 0;

const makeTowns = (towns, search) => towns.map(x => {
    let className = '';

    if (x.toLowerCase().includes(search) && search !== '') {
        className = 'active';
        matchesFound++;
    }

    return html` <li class=${className}>${x}</li>`;
});

const ul = html`<ul>${makeTowns(towns)}</ul>`;
render(ul, townsDiv);

searchBtn.addEventListener('click', () => {
    const ul = html`<ul>${makeTowns(towns, searchInput.value.toLowerCase())}</ul>`;
    render(ul, townsDiv);

    searchInput.value = '';
    resultDiv.textContent = `${matchesFound} matches found`;
    matchesFound = 0;
});


