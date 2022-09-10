import {html, render} from 'https://unpkg.com/lit-html?module';

const url = 'http://localhost:3030/jsonstore/advanced/table';

const tBody = document.querySelector('tbody');
const searchField = document.getElementById('searchField');
const searchBtn = document.getElementById('searchBtn');

let peopleInfo;

await loadData();

async function loadData() {
    const response = await fetch(url);
    peopleInfo = await response.json();

    renderRows(peopleInfo);
}

searchBtn.addEventListener('click', () => {
    let searchValue = searchField.value.trim().toLowerCase();

    if(searchValue === ''){
        searchValue = undefined;
    }

    renderRows(peopleInfo, searchValue);
    searchField.value = '';
});

function renderRows(peopleInfo, searchValue) {
    const tableRows = Object.values(peopleInfo).map(x => mapPerson(x, searchValue));
    render(tableRows, tBody);
}

function mapPerson(personInfo, searchValue) {
    let rowClass = '';
    const {firstName, lastName, email, course} = personInfo;

    if (firstName.toLowerCase().includes(searchValue)
        || lastName.toLocaleString().includes(searchValue)
        || email.toLowerCase().includes(searchValue)
        || course.toLowerCase().includes(searchValue)) {
        rowClass = 'select';
    }

    return html`
        <tr class=${rowClass}>
            <td>${firstName} ${lastName}</td>
            <td>${email}</td>
            <td>${course}</td>
        </tr>
    `;
}
