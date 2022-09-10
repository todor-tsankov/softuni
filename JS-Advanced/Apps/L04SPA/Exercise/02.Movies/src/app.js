import {setupHome, showHome} from './home.js';
import {setupMovie, showMovie, del, like} from './movie.js';
import {setupAddMovie, showAddMovie} from './addMovie.js';
import {setupEditMovie, showEditMovie} from './editMovie.js';
import {setupLogin, showLogin} from './login.js';
import {setupRegister, showRegister} from './register.js';
import {logout} from "./logout.js";

const navigation = document.getElementById('navigation');
const [homeBtn, welcomeBtn, logoutBtn, loginBtn, registerBtn] = [...navigation.querySelectorAll('a')];

const content = document.getElementById('variableContent');
const [home, title, addMovieBtn, movies, addMovie, movieDetails, editMovie, login, register] = [...content.children];

const [delBtn, editBtn, likeBtn] = [...movieDetails.querySelectorAll('a')];

content.innerHTML = '';

setupHome(content, home, addMovieBtn, movies, title);
setupMovie(content, movieDetails);
setupAddMovie(content, addMovie);
setupEditMovie(content, editMovie);

setupLogin(content, login);
setupRegister(content, register);

updateNavLinks();
showHome();

homeBtn.addEventListener('click', async (ev) => {
    ev.preventDefault();
    await showHome();
    updateNavLinks();
});

addMovieBtn.addEventListener('click', (ev) => {
    ev.preventDefault();
    showAddMovie();
});

loginBtn.addEventListener('click', (ev) => {
    ev.preventDefault();
    showLogin();
});

registerBtn.addEventListener('click', (ev) => {
    ev.preventDefault();
    showRegister();
});

logoutBtn.addEventListener('click', async (ev) => {
    ev.preventDefault();
    await logout();
});

movies.addEventListener('click', async (ev) => {
    ev.preventDefault();

    let target = ev.target;

    if (target.nodeName === 'BUTTON') {
        target = target.parentElement;
    }

    if (target.nodeName !== 'A' || !target.id) {
        return;
    }

    if(!sessionStorage.getItem('accessToken')){
        redirect('login');
    } else{
        await showMovie(target.id);
    }
});

delBtn.addEventListener('click', async(ev) => {
    ev.preventDefault();
    await del(ev.target.parentElement.children[0].value);
});

editBtn.addEventListener('click', async(ev) => {
    ev.preventDefault();
    await showEditMovie(ev.target.parentElement.children[0].value);
});

likeBtn.addEventListener('click', async(ev) => {
    ev.preventDefault();
    await like(ev.target.parentElement.children[0].value);
})

function updateNavLinks() {
    const token = sessionStorage.getItem('accessToken');
    const email = sessionStorage.getItem('email');

    if (token || email) {
        loginBtn.style.display = 'none';
        registerBtn.style.display = 'none';

        welcomeBtn.textContent = 'Welcome, ' + email;

        welcomeBtn.style.display = 'inline';
        logoutBtn.style.display = 'inline';
    } else {
        welcomeBtn.style.display = 'none';
        logoutBtn.style.display = 'none';

        loginBtn.style.display = 'inline';
        registerBtn.style.display = 'inline';
    }
}

const redirectObj = {
    'home': () => homeBtn.click(),
    'login': () => loginBtn.click(),
    'register': () => registerBtn.click(),
    'addMovie': () => addMovieBtn.click(),
};

export default function redirect(page) {
    redirectObj[page]();
}
