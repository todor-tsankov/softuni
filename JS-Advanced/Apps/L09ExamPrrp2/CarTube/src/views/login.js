import { html } from '../../node_modules/lit-html/lit-html.js';
import { login as apiLogin } from '../api/data.js';

const template = (onSubmit) => html`
`;

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

        }
    }
}
