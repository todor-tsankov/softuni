function attachEvents() {
    const [, loadPostsBtn, postsSelect, viewPostBtn, title, body, , comments] = document.querySelector('body').children;
    const posts = [];

    const postsUrl = 'http://localhost:3030/jsonstore/blog/posts';
    const commentsUrl = 'http://localhost:3030/jsonstore/blog/comments';

    loadPostsBtn.addEventListener('click', async () => {
        Array.from(postsSelect.children).forEach(x => x.remove());

        const response = await fetch(postsUrl);
        const postsInfo = await response.json();

        for (let id in postsInfo) {
            const postInfo = postsInfo[id];
            const option = document.createElement('option');
            option.value = postInfo.id;
            option.textContent = postInfo.title;

            postsSelect.appendChild(option);

            posts.push(postInfo);
        }
    });

    viewPostBtn.addEventListener('click', async () => {
        if(postsSelect.value === ''){
            return;
        }

        Array.from(comments.children).forEach(x => x.remove());

        const response = await fetch(commentsUrl);
        const commentsInfo = await response.json();

        const postInfo = posts.find(x => x.id === postsSelect.value);
        title.textContent = postInfo.title;
        body.textContent = postInfo.body;

        for(let id in commentsInfo){
            let commentInfo = commentsInfo[id];

            if(commentInfo.postId !== postsSelect.value){
                continue;
            }

            const li = document.createElement('li');
            li.id = commentInfo.id;
            li.textContent = commentInfo.text;

            comments.appendChild(li);
        }
    });
}

attachEvents();

