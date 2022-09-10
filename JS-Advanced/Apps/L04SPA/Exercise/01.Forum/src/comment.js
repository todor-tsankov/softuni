import createComment from "./commentHelper.js";

const commentsUrl = 'http://localhost:3030/jsonstore/collections/myboard/comments';

export async function saveComment(text, username, postId) {
    const response = await fetch(commentsUrl, {
        method: 'post',
        headers: {'Content-Type': 'application/json'},
        body: JSON.stringify({
            text: text,
            username: username,
            postId: postId,
            time: new Date().toISOString()
        })
    });

    return response.ok;
}

export async function loadComments(postId, parent) {
    const responseComments = await fetch(commentsUrl);
    const comments = await responseComments.json();

    Object.values(comments).filter(x => x.postId === postId).forEach(x => parent.appendChild(createComment(x)));
}