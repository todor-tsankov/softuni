import redirect from "./app.js";

const moviesUrl = 'http://localhost:3030/data/movies';
const likesUrl = 'http://localhost:3030/data/likes';

let parent;
let movieExample;

export function setupMovie(parentTarget, movieExampleTaget) {
    parent = parentTarget;
    movieExample = movieExampleTaget;
}

export async function showMovie(id) {
    parent.innerHTML = '';

    const response = await fetch(moviesUrl + '/' + id);
    const info = await response.json();

    const likesResponse = await fetch(likesUrl);
    const likes = await likesResponse.json();
    const count = likes.filter(x => x.movieId === id).length;

    movieExample.querySelector('input').value = id;
    movieExample.querySelector('h1').textContent = '--- Movie title: ' + info.title + ' ---';
    movieExample.querySelector('img').src = info.img;
    movieExample.querySelector('p').textContent = info.description;
    movieExample.querySelector('span').textContent = count + ' Likes';

    const [del, edit, like] = [...movieExample.querySelectorAll('a')];

    if (sessionStorage.getItem('email') === info.creatorEmail) {
        del.style.display = 'inline';
        edit.style.display = 'inline';
        like.style.display = 'none';
    } else {
        del.style.display = 'none';
        edit.style.display = 'none';
        like.style.display = 'inline';
    }

    parent.appendChild(movieExample);
}

export async function del(id) {
    const response = await fetch(moviesUrl + '/' + id, {
        method: 'delete',
        headers: {'X-Authorization': sessionStorage.getItem('accessToken')},
    });

    if (response.ok) {
        redirect('home');
    }
}

export async function like(id) {
    const response = await fetch('http://localhost:3030/data/likes', {
        method: 'post',
        headers: {'Content-Type': 'application/json', 'X-Authorization': sessionStorage.getItem('accessToken')},
        body: JSON.stringify({movieId: id, ownerEmail: sessionStorage.getItem('email')}),
    });

    redirect('home');
}