import e from './helper.js';

export function createTopicPost(post) {
    return e('div', {className: 'topic-content'},
        e('div', {className: 'topic-title'},
            e('div', {className: 'topic-name-wrapper'},
                e('div', {className: 'topic-name'},
                    e('h2', {}, post.topicName),
                    e('p', {}, 'Date: ',
                        e('time', {}, post.time.slice(0, -5).replace('T', ' ')))),
                e('div', {className: 'subscribers'},
                    e('p', {}, 'Subscribers: ',
                        e('span', {}, '123'))))));
}

export function createTopicLink(post) {
    return e('div', {className: 'topic-container'},
        e('div', {className: 'topic-name-wrapper'},
            e('div', {className: 'topic-name'},
                e('a', {id: post._id, className: 'normal', href: '#'},
                    e('h2', {}, post.topicName)),
                e('div', {className: 'columns'},
                    e('div', {},
                        e('p', {},
                            'Date: ',
                            e('time', {}, post.time.slice(0, -5).replace('T', ' '))),
                        e('div', {className: 'nick-name'},
                            e('p', {}, 'Username: ',
                                e('span', {}, post.username)))),
                    e('div', {className: 'subscribers'}, '')))));
}