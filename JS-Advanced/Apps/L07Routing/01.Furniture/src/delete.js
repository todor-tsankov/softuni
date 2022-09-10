import page from '../node_modules/page/page.mjs';
import api from './api.js';

export default async function del({params}) {
    const ok = await api.del(params.id);

    if (ok) {
        page.redirect('/my-furniture');
    }
}