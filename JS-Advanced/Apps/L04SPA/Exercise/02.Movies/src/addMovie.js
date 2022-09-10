import redirect from './app.js';

const moviesUrl = 'http://localhost:3030/data/movies ';

let parent;
let form;

export function setupAddMovie(parentTarget, formTarget){
    parent = parentTarget;
    form = formTarget;

    form.addEventListener('submit', onSubmit);
}

export function showAddMovie(){
    parent.innerHTML = '';
    parent.appendChild(form);
}

export async function onSubmit(ev){
    ev.preventDefault();

    const [title, description, url] = form.querySelectorAll('.form-control');

    if(title.value === '' || description.value === '' || url.value === ''){
        return;
    }

    const response = await fetch(moviesUrl,{
        method: 'post',
        headers: {'Content-Type': 'application/json', 'X-Authorization': sessionStorage.getItem('accessToken')},
        body: JSON.stringify({title: title.value, description: description.value, img: url.value, creatorEmail: sessionStorage.getItem('email')}),
    });

    if(response.ok){
        title.value = '';
        description.value = '';
        url.value = '';

        redirect('home');
    }

    lock = true;
}