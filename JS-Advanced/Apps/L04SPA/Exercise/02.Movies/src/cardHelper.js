import e from './helper.js';

export default function createMovieCard(id,title, imgSrc) {
    return e('div', {className: 'card mb-4'},
        e('img', {className: 'card-img-top', src: imgSrc, alt: 'Card image cap', width: '400'}),
        e('div', {className: 'card-body'},
            e('h4', {className: 'card-title'}, title)),
        e('div', {className: 'card-footer'},
            e('a', {href: '', id: id},
                e('button', {type: 'button', className: 'btn btn-info'}, 'Details'))));
}