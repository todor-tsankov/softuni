import { html } from '../../node_modules/lit-html/lit-html.js';
import { login as apiLogin } from '../api/data.js';
import show from './notification.js';

const template = (onSubmit) => html`
<section id="login">
    <form id="login-form" @submit=${onSubmit}>
        <div class="container">
            <h1>Login</h1>
            <label for="email">Email</label>
            <input id="email" placeholder="Enter Email" name="email" type="text">
            <label for="password">Password</label>
            <input id="password" type="password" placeholder="Enter Password" name="password">
            <input type="submit" class="registerbtn button" value="Login">
            <div class="container signin">
                <p>Dont have an account?<a href="/register">Sign up</a>.</p>
            </div>
        </div>
    </form>
</section>`;

export default function login(ctx) {
    ctx.render(template(onSubmit));

    async function onSubmit(e) {
        e.preventDefault();

        const formData = new FormData(e.target);

        const email = formData.get('email');
        const password = formData.get('password');

        if (email === '' || password === '') {
            window.alert('Please fill all fields!');
            show('PLease fill all fields!');
            return;
        }

        try {
            await apiLogin(email, password);
            ctx.setUserNav();
            ctx.page.redirect('/all');
        } catch (e) {
            show('Invalid credentials!');
        }
    }
}
