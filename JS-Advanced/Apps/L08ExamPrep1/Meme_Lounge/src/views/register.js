import { html } from '../../node_modules/lit-html/lit-html.js';
import { register as apiRegister } from '../api/data.js'
import show from './notification.js';

const template = (onSubmit) => html`
<section id="register">
    <form id="register-form" @submit=${onSubmit}>
        <div class="container">
            <h1>Register</h1>
            <label for="username">Username</label>
            <input id="username" type="text" placeholder="Enter Username" name="username">
            <label for="email">Email</label>
            <input id="email" type="text" placeholder="Enter Email" name="email">
            <label for="password">Password</label>
            <input id="password" type="password" placeholder="Enter Password" name="password">
            <label for="repeatPass">Repeat Password</label>
            <input id="repeatPass" type="password" placeholder="Repeat Password" name="repeatPass">
            <div class="gender">
                <input type="radio" name="gender" id="female" value="female">
                <label for="female">Female</label>
                <input type="radio" name="gender" id="male" value="male" checked>
                <label for="male">Male</label>
            </div>
            <input type="submit" class="registerbtn button" value="Register">
            <div class="container signin">
                <p>Already have an account?<a href="#">Sign in</a>.</p>
            </div>
        </div>
    </form>
</section>`;

export default async function register(ctx) {
    ctx.render(template(onSubmit));

    async function onSubmit(e) {
        e.preventDefault();

        const formData = new FormData(e.target);

        const username = formData.get('username');
        const email = formData.get('email');
        const password = formData.get('password');
        const repeatPass = formData.get('repeatPass');
        const gender = formData.get('gender');

        if (username === '' || email === '' || password === '' || gender === '' || password !== repeatPass) {
            window.alert('Please fill all fields');
            show('PLease fill all fields!');
            return;
        }

        try {
            await apiRegister(username, email, password, gender);
            ctx.setUserNav();
            ctx.page.redirect('/all');
        } catch (e) {
            show('Username or email already exist!');
        }

    }
}