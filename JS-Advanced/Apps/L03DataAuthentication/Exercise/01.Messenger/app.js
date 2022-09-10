function attachEvents() {
    const url = 'http://localhost:3030/jsonstore/messenger';

    const name = document.getElementById('author');
    const message = document.getElementById('content');
    const send = document.getElementById('submit');
    const refresh = document.getElementById('refresh');
    const textArea = document.getElementById('messages');

    send.addEventListener('click', () => {
        if(name.value === '' || message.value === ''){
            return;
        }

        fetch(url, {
            method: 'post',
            headers: {'Content-type': 'application/json'},
            body: JSON.stringify({author: name.value, content: message.value})
        });

        name.value = '';
        message.value = '';
    });

    refresh.addEventListener('click', async () => {
        textArea.textContent = '';

        const response = await fetch(url);
        const messages = await response.json();

        const lines = [];
        Object.values(messages).forEach(x => lines.push(`${x.author}: ${x.content}`));

        textArea.textContent = lines.join('\n');
    });
}

attachEvents();