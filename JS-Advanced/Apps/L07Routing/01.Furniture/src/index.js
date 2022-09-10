import page from '../node_modules/page/page.mjs';
import {html, render} from '../node_modules/lit-html/lit-html.js';
import api from './api.js';

const root = document.getElementById('root');

export default async function index() {
    const items = (await api.all()).map(x => html`
        <div class="col-md-4">
            <div class="card text-white bg-primary">
                <div class="card-body">
                    <img alt="" src=${x.img}>
                    <p>${x.description}</p>
                    <footer>
                        <p>Price: <span>${x.price} $</span></p>
                    </footer>
                    <div>
                        <a href="/details/${x._id}" class="btn btn-info">Details</a>
                    </div>
                </div>
            </div>
        </div>
    `);

    const template = html`
        <div class="row space-top">
            <div class="col-md-12">
                <h1>Welcome to Furniture System</h1>
                <p>Select furniture from the catalog to view details.</p>
            </div>
        </div>
        <div class="row space-top">
            ${items}
        </div>
    `;

    render(template, root);
}