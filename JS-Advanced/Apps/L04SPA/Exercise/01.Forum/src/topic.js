import {createTopicLink, createTopicPost} from './topicHelper.js';
import {saveComment, loadComments} from './comment.js';

const topicsUrl = 'http://localhost:3030/jsonstore/collections/myboard/posts';

let topicsList;
let main;
let newComment;
let currentTopicId;

export function setupTopic(topicsListTarget, mainTarget, newCommentTarget){
    topicsList = topicsListTarget;
    main = mainTarget;
    newComment = newCommentTarget;

    newComment.querySelector('form').addEventListener('submit', async (ev) => {
        ev.preventDefault();

        const commentUsername = newComment.querySelector('#comment-username');
        const commentText = newComment.querySelector('#commentText');

        if(commentUsername.value === '' || commentText.value === ''){
            return;
        }

        const ok = saveComment(commentText.value, commentUsername.value, currentTopicId);

        if (ok) {
            await loadTopic(currentTopicId);

            commentUsername.value = '';
            commentText.value = '';
        }
    });
}

export async function loadTopics() {
    const response = await fetch(topicsUrl);
    const posts = await response.json();

    topicsList.innerHTML = '';
    Object.values(posts).forEach(x => topicsList.appendChild(createTopicLink(x)));
}

export async function loadTopic(id) {
    currentTopicId = id;

    const response = await fetch(topicsUrl + '/' + id);
    const post = await response.json();

    main.innerHTML = '';

    const child = createTopicPost(post);
    main.appendChild(child);

    await loadComments(id, child);

    child.appendChild(newComment);
    newComment.style.display = 'block';
}

export async function saveTopic(topicName, username, postText) {
    const response = await fetch(topicsUrl, {
        method: 'post',
        headers: {'Content-Type': 'application/json'},
        body: JSON.stringify({
            topicName: topicName,
            username: username,
            postText: postText,
            time: new Date().toISOString()
        }),
    });

    const topicInfo = await response.json();
    await saveComment(postText, username, topicInfo._id);

    return response.ok;
}
