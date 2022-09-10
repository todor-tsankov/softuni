import { html } from '../../node_modules/lit-html/lit-html.js';
import { register as apiRegister } from '../api/data.js'

const template = (onSubmit) => html`
`;

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
            return;
        }

        try {
            await apiRegister(username, email, password, gender);
            ctx.setUserNav();
            ctx.page.redirect('/all');
        } catch (e) {
        }
    }
}