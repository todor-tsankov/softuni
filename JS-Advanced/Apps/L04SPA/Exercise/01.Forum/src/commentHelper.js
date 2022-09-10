import e from './helper.js';

export default function createComment(comment) {
    return e('div', {className: 'comment'},
        e('header', {className: 'header'},
            e('p', {},
                e('strong', {}, `${comment.username}`),
                ` posted on `,
                e('strong', {}, comment.time.slice(0, -5).replace('T', ' ')))),
        e('div', {className: 'comment-main'},
            e('div', {className: 'userdetails'},
                e('img', {src: './static/profile.png', alt: 'avatar'})),
            e('div', {className: 'post-content'},
                e('p', {}, comment.text))),
        e('div', {className: 'footer'},
            e('p', {},
                e('span', {}, '3'),
                ' Likes')));
}