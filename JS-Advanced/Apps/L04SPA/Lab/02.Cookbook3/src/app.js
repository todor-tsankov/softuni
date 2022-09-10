import {setupIndex, showIndex} from './index.js';
import {setupLogin, showLogin} from './login.js';
import {setupRegister, showRegister} from './register.js';
import {setupCreate, showCreate} from './create.js';

const userDiv = document.getElementById('user');
const guestDiv = document.getElementById('guest');

const loginBtn = document.getElementById('loginBtn');
const registerBtn = document.getElementById('registerBtn');
const catalogBtn = document.getElementById('catalogBtn');
const logoutBtn = document.getElementById('logoutBtn');
const createBtn = document.getElementById('createRecipeBtn');

const buttons = [loginBtn, registerBtn, catalogBtn, logoutBtn, createBtn];

const main = document.getElementById('main');
const [create, login, register] = [...document.getElementById('views').querySelectorAll('article')];

setupIndex(main);
setupLogin(main, login);
setupRegister(main, register);
setupCreate(main, create);

const redirectObj = {
    'index': () => {
        showIndex();
        resetButtons();

        catalogBtn.className = 'active';
    },
    'create': () => {
        showCreate();
        resetButtons();

        createBtn.className = 'active';
    },
    'register': () => {
        showRegister();
        resetButtons();

        registerBtn.className = 'active';
    },
    'login': () => {
        showLogin();
        resetButtons();

        loginBtn.className = 'active';
    },
}

export function redirect(page) {
    checkUser();
    redirectObj[page]();
}

loginBtn.addEventListener('click', (ev) => {
    ev.preventDefault();
    checkUser();
    showLogin();

    resetButtons();
    loginBtn.className = 'active';
});

registerBtn.addEventListener('click', (ev) => {
    ev.preventDefault();
    checkUser();
    showRegister();

    resetButtons();
    registerBtn.className = 'active';
});

catalogBtn.addEventListener('click', async (ev) => {
    ev.preventDefault();
    checkUser();
    await showIndex();

    resetButtons();
    catalogBtn.className = 'active';
});

logoutBtn.addEventListener('click', async (ev) => {
    ev.preventDefault();
    await logout();
    checkUser();
});

createBtn.addEventListener('click', (ev) => {
    ev.preventDefault();
    showCreate();

    resetButtons();
    createBtn.className = 'active';
});

async function logout() {
    const response = await fetch('http://localhost:3030/users/logout', {
        method: 'get',
        headers: {
            'X-Authorization': sessionStorage.getItem('authToken')
        },
    });

    if (response.status === 200) {
        sessionStorage.removeItem('authToken');
        showIndex();
    } else {
        console.error(await response.json());
    }
}

function checkUser() {
    if (sessionStorage.hasOwnProperty('authToken')) {
        userDiv.style.display = 'inline';
        guestDiv.style.display = 'none';
    } else {
        userDiv.style.display = 'none';
        guestDiv.style.display = 'inline';
    }
}

function resetButtons() {
    buttons.forEach(x => x.className = '');
}

checkUser();
showIndex();