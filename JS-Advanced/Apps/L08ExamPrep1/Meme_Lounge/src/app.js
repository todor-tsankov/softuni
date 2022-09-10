import page from '../node_modules/page/page.mjs';
import {render} from '../node_modules/lit-html/lit-html.js';

import all from './views/all.js';
import create from './views/create.js';
import details from './views/details.js';
import edit from './views/edit.js';
import home from './views/home.js';
import login from './views/login.js';
import profile from './views/profile.js';
import register from './views/register.js';

import {logout as apiLogout} from './api/data.js'

const main = document.querySelector('main');

page('/', decorateContext, home);
page('/all', decorateContext, all);
page('/create', decorateContext, create);
page('/details/:id', decorateContext, details);
page('/edit/:id', decorateContext, edit);
page('/login', decorateContext, login);
page('/register', decorateContext, register);
page('/profile', decorateContext, profile);

page.start();

setUserNav();

document.getElementById('logoutBtn').addEventListener('click', logout);

function decorateContext(ctx, next){
    ctx.setUserNav = setUserNav;
    ctx.render = (template) => render(template, main);

    next();
}

function setUserNav(){
    const guestNav = document.getElementById('guestNav');
    const userNav = document.getElementById('userNav');

    const email = sessionStorage.getItem('email');

    if(email){
        document.getElementById('welcomeSpan').textContent = `Welcome, ${email}`;
        guestNav.style.display = 'none';
        userNav.style.display = 'inline';
    } else{
        guestNav.style.display = 'inline';
        userNav.style.display = 'none';
    }
}

async function logout(){
    await apiLogout();
    setUserNav();
}