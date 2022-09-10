import page from '../node_modules/page/page.mjs';
import api from './api.js';

export default async function login() {
    await api.logout();
    page.redirect('/index');
}

