import {render} from 'https://unpkg.com/lit-html?module';
import {makeTable, makeAddForm, makeEditForm} from './template.js';

const url = 'http://localhost:3030/jsonstore/collections/books/';
const body = document.querySelector('body');

let table = makeTable(onClick);
const addForm = makeAddForm(onAdd);

await refresh();

async function refresh(load) {
    let data;

    if (load) {
        data = await getData();
    }

    table = makeTable(onClick, data);
    render([table, addForm], body);
}

async function getData(id) {
    let localUrl = url;

    if (id) {
        localUrl += id;
    }

    const response = await fetch(localUrl);
    return (await response.json());
}

async function onClick(e) {
    e.preventDefault();

    const target = e.target;

    if (target.tagName !== 'BUTTON') {
        return;
    }

    if (target.textContent === 'Edit') {
        const id = target.parentElement.parentElement.id;
        const bookInfo = await getData(id);

        render([table, makeEditForm(onEdit, id, bookInfo.title, bookInfo.author)], body);
    } else if (target.textContent === 'Delete') {
        const id = target.parentElement.parentElement.id;

        await fetch(url + id, {
            method: 'delete',
        });

        await refresh(true);
    } else if (target.id === 'loadBooks') {
        await refresh(true);
    }
}

async function onAdd(e) {
    e.preventDefault();

    const [title, author] = [...document.querySelectorAll('input')];

    title.value = title.value.trim();
    author.value = author.value.trim();

    if (title.value === '' || author.value === '') {
        return;
    }

    await fetch(url, {
        method: 'post',
        headers: {'Content-Type': 'application/json'},
        body: JSON.stringify({title: title.value, author: author.value}),
    });

    title.value = '';
    author.value = '';

    await refresh(true);
}

async function onEdit(e) {
    e.preventDefault();

    const [id, title, author] = [...document.querySelectorAll('input')];

    title.value = title.value.trim();
    author.value = author.value.trim();

    if (title.value === '' || author.value === '') {
        return;
    }

    await fetch(url + id.value, {
        method: 'put',
        headers: {'Content-Type': 'application/json'},
        body: JSON.stringify({title: title.value, author: author.value}),
    });

    title.value = '';
    author.value = '';

    await refresh(true);
}
