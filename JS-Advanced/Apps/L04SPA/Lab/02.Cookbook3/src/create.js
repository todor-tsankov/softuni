import {redirect} from './app.js';

let main;
let article;

function setupCreate(mainTarget, articleTarget) {
    main = mainTarget;
    article = articleTarget;

    article.querySelector('form').addEventListener('submit', (ev) => {
        ev.preventDefault();
        const formData = new FormData(ev.target);
        onSubmit([...formData.entries()].reduce((p, [k, v]) => Object.assign(p, {[k]: v}), {}));
    });
}

function showCreate() {
    main.innerHTML = '';
    main.appendChild(article);
}

export {
    setupCreate,
    showCreate,
}

async function onSubmit(data) {
    const body = JSON.stringify({
        name: data.name,
        img: data.img,
        ingredients: data.ingredients.split('\n').map(l => l.trim()).filter(l => l != ''),
        steps: data.steps.split('\n').map(l => l.trim()).filter(l => l != '')
    });

    const token = sessionStorage.getItem('authToken');
    if (token == null) {
        redirect('index');
    }

    try {
        const response = await fetch('http://localhost:3030/data/recipes', {
            method: 'post',
            headers: {
                'Content-Type': 'application/json',
                'X-Authorization': token
            },
            body
        });

        if (response.status === 200) {
            redirect('index');
        } else {
            throw new Error(await response.json());
        }
    } catch (err) {
        console.error(err.message);
    }
}