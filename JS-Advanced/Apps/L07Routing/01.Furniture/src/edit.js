import page from '../node_modules/page/page.mjs';
import {html, render} from '../node_modules/lit-html/lit-html.js';

import api from './api.js';

const root = document.getElementById('root');

export default async function edit({params}) {
    const info = await api.details(params.id);

    const template = html`
        <div class="row space-top">
            <div class="col-md-12">
                <h1>Edit Furniture</h1>
                <p>Please fill all fields.</p>
            </div>
        </div>
        <form @submit=${(e) => onSubmit(e, params.id)}>
            <div class="row space-top">
                <div class="col-md-4">
                    <div class="form-group">
                        <label class="form-control-label" for="new-make">Make</label>
                        <input class="form-control" id="new-make" type="text" name="make" value=${info.make}>
                    </div>
                    <div class="form-group">
                        <label class="form-control-label" for="new-model">Model</label>
                        <input class="form-control" id="new-model" type="text" name="model"
                               value=${info.model}>
                    </div>
                    <div class="form-group">
                        <label class="form-control-label" for="new-year">Year</label>
                        <input class="form-control" id="new-year" type="number" name="year" value=${info.year}>
                    </div>
                    <div class="form-group">
                        <label class="form-control-label" for="new-description">Description</label>
                        <input class="form-control" id="new-description" type="text" name="description"
                               value=${info.description}>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-group">
                        <label class="form-control-label" for="new-price">Price</label>
                        <input class="form-control" id="new-price" type="number" name="price" value=${info.price}>
                    </div>
                    <div class="form-group">
                        <label class="form-control-label" for="new-image">Image</label>
                        <input class="form-control" id="new-image" type="text" name="img" value=${info.img}>
                    </div>

                    <div class="form-group">
                        <label class="form-control-label" for="new-material">Material (optional)</label>
                        <input class="form-control" id="new-material" type="text" name="material"
                               value=${info.material}>
                    </div>

                    <input type="submit" class="btn btn-info" value="Edit">
                </div>
            </div>
        </form>
    `;

    render(template, root);
}

async function onSubmit(e, id) {
    e.preventDefault();

    let valid = true;

    const makeEl = document.getElementById('new-make');
    const make = makeEl.value.trim();

    if (make.length < 4) {
        makeInvalid(makeEl);
        valid = false;
    } else {
        makeValid(makeEl);
    }

    const modelEl = document.getElementById('new-model');
    const model = modelEl.value.trim();

    if (model.length < 4) {
        makeInvalid(modelEl);
        valid = false;
    } else {
        makeValid(modelEl);
    }

    const yearEl = document.getElementById('new-year');
    const year = Number(yearEl.value);

    if (year < 1950 || year > 2050) {
        makeInvalid(yearEl);
        valid = false;
    } else {
        makeValid(yearEl);
    }

    const descriptionEl = document.getElementById('new-description');
    const description = descriptionEl.value.trim();

    if (description.length <= 10) {
        makeInvalid(descriptionEl);
        valid = false;
    } else {
        makeValid(descriptionEl);
    }

    const priceEl = document.getElementById('new-price');
    const price = Number(priceEl.value);

    if (priceEl.value === '' || price < 0) {
        makeInvalid(priceEl);
        valid = false;
    } else {
        makeValid(priceEl);
    }

    const imageEl = document.getElementById('new-image');
    const img = imageEl.value.trim();

    let imageOk = false;

    try {
        imageOk = (await fetch(img)).ok;
    } catch { }

    if (!imageOk) {
        makeInvalid(imageEl);
        valid = false;
    } else {
        makeValid(imageEl);
    }

    const materialEl = document.getElementById('new-material');
    const material = materialEl.value.trim();

    if (!valid) {
        return;
    }

    const ok = await api.update(id, {make, model, year, description, price, img, material});

    if (ok) {
        page.redirect('/my-furniture');
    }
}

function makeValid(el) {
    el.classList.add('is-valid');
    el.classList.remove('is-invalid');
}

function makeInvalid(el) {
    el.classList.add('is-invalid');
    el.classList.remove('is-valid');
}