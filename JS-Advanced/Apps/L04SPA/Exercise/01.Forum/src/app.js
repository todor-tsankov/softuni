import {loadTopic, loadTopics, saveTopic,setupTopic} from "./topic.js";

const main = document.querySelector('main');
const index = document.getElementById('index');
const topicsList = document.getElementById('topicsList');

const form = document.getElementById('newTopicForm');

const topicName = document.getElementById('topicName');
const username = document.getElementById('username');
const postText = document.getElementById('postText');

const cancelBtn = document.getElementById('cancelBtn');
const newComment = document.getElementById('newComment');

const homeBtn = document.getElementById('homeBtn');

setupTopic(topicsList, main, newComment);
await loadTopics();

homeBtn.addEventListener('click', async (ev) => {
    ev.preventDefault();

    main.innerHTML = '';
    topicsList.innerHTML = '';

    main.appendChild(index);
    await loadTopics();
});

form.addEventListener('submit', async (ev) => {
    ev.preventDefault();

    if (topicName.value === '' || username.value === '' || postText.value === '') {
        return;
    }

    const ok = saveTopic(topicName.value, username.value, postText.value);

    if (ok) {
        clearForm();
        await loadTopics();
    }
});

cancelBtn.addEventListener('click', () => clearForm());

topicsList.addEventListener('click', async (ev) => {
    let target = ev.target;

    if (target.nodeName === 'H2') {
        target = target.parentElement;
    }

    if (target.nodeName !== 'A') {
        return;
    }

    await loadTopic(target.id);
});


function clearForm() {
    topicName.value = '';
    username.value = '';
    postText.value = '';
}



