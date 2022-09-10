import redirect from './app.js';

const moviesUrl = 'http://localhost:3030/data/movies';

let parent;
let form;
let id;

export function setupEditMovie(parentTarget, formTarget) {
    parent = parentTarget;
    form = formTarget;

    form.addEventListener('submit', onSubmit);
}

export async function showEditMovie(idTarget) {
    id = idTarget;

    parent.innerHTML = '';
    parent.appendChild(form);

    const response = await fetch(moviesUrl + '/' + id);
    const info = await response.json();

    const [title, description, url] = form.querySelectorAll('.form-control');

    title.value = info.title;
    description.value = info.description;
    url.value = info.img;
}

export async function onSubmit(ev) {
    ev.preventDefault();

    const [title, description, url] = form.querySelectorAll('.form-control');

    if (title.value === '' || description.value === '' || url.value === '') {
        return;
    }

    const putResponse = await fetch(moviesUrl + '/' + id, {
        method: 'put',
        headers: {'Content-Type': 'application/json', 'X-Authorization': sessionStorage.getItem('accessToken')},
        body: JSON.stringify({
            title: title.value,
            description: description.value,
            img: url.value,
            creatorEmail: sessionStorage.getItem('email')
        }),
    });

    if (putResponse.ok) {
        title.value = '';
        description.value = '';
        url.value = '';

        redirect('home');
    }

    id = undefined;
}