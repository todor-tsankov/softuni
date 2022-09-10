import { html } from '../../node_modules/lit-html/lit-html.js';
import {details, edit as apiEdit} from '../api/data.js';
import show from './notification.js';

const template = (meme, onSubmit) => html`
<section id="edit-meme">
    <form id="edit-form" @submit=${onSubmit}>
        <h1>Edit Meme</h1>
        <div class="container">
            <label for="title">Title</label>
            <input id="title" type="text" placeholder="Enter Title" name="title" .value=${meme.title}>
            <label for="description">Description</label>
            <textarea id="description" placeholder="Enter Description" name="description" .value=${meme.description}></textarea>
            <label for="imageUrl">Image Url</label>
            <input id="imageUrl" type="text" placeholder="Enter Meme ImageUrl" name="imageUrl" .value=${meme.imageUrl}>
            <input type="submit" class="registerbtn button" value="Edit Meme">
        </div>
    </form>
</section>`;

export default async function edit(ctx){
    const meme = await details(ctx.params.id);
    ctx.render(template(meme, onSubmit));

    async function onSubmit(e){
        e.preventDefault();

        const formData = new FormData(e.target);

        const title = formData.get('title');
        const description = formData.get('description');
        const imageUrl = formData.get('imageUrl');

        if(title === '' || description === '' || imageUrl === ''){
            window.alert('Please fill all fields!');
            show('PLease fill all fields!');
            return;
        }

        await apiEdit(ctx.params.id, title, description, imageUrl);
        ctx.page.redirect('/details/' + ctx.params.id);
    }
}