import { html } from '../../node_modules/lit-html/lit-html.js';
import { details as apiDetails, del } from '../api/data.js';

const template = (meme, owner, onDelete) => html`
<section id="meme-details">
    <h1>Meme Title: ${meme.title}

    </h1>
    <div class="meme-details">
        <div class="meme-img">
            <img alt="meme-alt" src=${meme.imageUrl}>
        </div>
        <div class="meme-description">
            <h2>Meme Description</h2>
            <p>${meme.description}</p>

            ${owner ? html`<a class="button warning" href="/edit/${meme._id}">Edit</a>
            <button class="button danger" @click=${onDelete}>Delete</button>` : ''}
        </div>
    </div>
</section>`;

export default async function details(ctx) {
    const meme = await apiDetails(ctx.params.id);
    const owner = meme._ownerId === sessionStorage.getItem('userId');

    ctx.render(template(meme, owner, onDelete));

    async function onDelete() {
        await del(ctx.params.id);
        ctx.page.redirect('/all');
    }
}