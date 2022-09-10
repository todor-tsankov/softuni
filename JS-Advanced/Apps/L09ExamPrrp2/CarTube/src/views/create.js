import { html } from '../../node_modules/lit-html/lit-html.js';

const template = (onSubmit) => html`
`;

export default async function create(ctx) {
    ctx.render(template(onSubmit));

    async function onSubmit(e) {
        e.preventDefault();

        const formData = new FormData(e.target);
    }
}