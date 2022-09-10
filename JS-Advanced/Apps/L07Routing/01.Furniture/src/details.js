import page from '../node_modules/page/page.mjs';
import {html, render} from '../node_modules/lit-html/lit-html.js';

import api from './api.js';

const root = document.getElementById('root');

export default async function details({params}) {
    const info = await api.details(params.id);

    if (info.img.startsWith('.')) {
        info.img = info.img.slice(1);
    }

    let creatorButtons = html`
        <div>
            <a href="/edit/${info._id}" class="btn btn-info">Edit</a>
            <a href="/delete/${info._id}" class="btn btn-red">Delete</a>
        </div>`;

    if(info._ownerId !== sessionStorage.getItem('_id')){
        creatorButtons = '';
    }

    const template = html`
        <div class="row space-top">
            <div class="col-md-12">
                <h1>Furniture Details</h1>
            </div>
        </div>
        <div class="row space-top">
            <div class="col-md-4">
                <div class="card text-white bg-primary">
                    <div class="card-body">
                        <img src=${info.img}>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <p>Make: <span>${info.make}</span></p>
                <p>Model: <span>${info.model}</span></p>
                <p>Year: <span>${info.year}</span></p>
                <p>Description: <span>${info.description}</span></p>
                <p>Price: <span>${info.price}</span></p>
                <p>Material: <span>${info.material || '-'}</span></p>
                ${creatorButtons}
            </div>
        </div>
    `;

    render(template, root);
}