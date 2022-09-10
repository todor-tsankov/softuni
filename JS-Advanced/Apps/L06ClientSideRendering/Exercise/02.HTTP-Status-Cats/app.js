import {html, render} from 'https://unpkg.com/lit-html?module';
import {cats} from './catSeeder.js';

const catsSection = document.getElementById('allCats');
catsSection.addEventListener('click', onClick);

const catElements = cats.map(catMap);
const ul = html`<ul>${catElements}</ul>`;

render(ul, catsSection);

function onClick(e){
    const target = e.target;

    if(target.nodeName !== 'BUTTON'){
        return;
    }

    const statusDiv = target.parentElement.querySelector('.status');

    if(statusDiv.style.display === 'none'){
        statusDiv.style.display = 'block';
        e.target.textContent = 'Hide status code';
    } else{
        statusDiv.style.display = 'none';
        e.target.textContent = 'Show status code';
    }
}

function catMap(cat){
    return html`
        <li>
            <img src=${`./images/${cat.imageLocation}.jpg`} width="250" height="250" alt="Card image cap">
            <div class="info">
                <button class="showBtn">Show status code</button>
                <div class="status" style="display: none" id="cat.id">
                    <h4>Status Code: ${cat.statusCode}</h4>
                    <p>${cat.statusMessage}</p>
                </div>
            </div>
        </li>
    `;
}