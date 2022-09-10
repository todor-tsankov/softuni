import {html, render} from 'https://unpkg.com/lit-html?module';

const url = 'http://localhost:3030/jsonstore/advanced/dropdown';

const textInput = document.getElementById('itemText');
const form = document.querySelector('form');
const select = document.getElementById('menu');

await loadSelect();

form.addEventListener('submit', async (e) => {
    e.preventDefault();

    textInput.value = textInput.value.trim();

    if(textInput.value === ''){
        return;
    }

    await fetch(url, {
        method: 'post',
        headers: {'Content-Type': 'application/json'},
        body: JSON.stringify({text: textInput.value}),
    });

    textInput.value = '';
    await loadSelect();
});

async function loadSelect(){
    const response = await fetch(url);
    const items = await response.json();

    const itemTemplates = Object.values(items).map(x => html`<option value=${x._id}>${x.text}</option>`);
    render(itemTemplates,  select);
}
