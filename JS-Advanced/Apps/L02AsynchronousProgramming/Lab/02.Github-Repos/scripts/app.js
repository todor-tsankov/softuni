function loadRepos() {
    const ul = document.getElementById('repos');
    const username = document.getElementById('username').value;

    const url = `https://api.github.com/users/${username}/repos`;
    Array.from(ul.children).forEach(x => x.remove());

    fetch(url)
        .then(response => response.json())
        .then((json) => {
            if(json.length === 0){
                const li = document.createElement('li');
                ul.appendChild(li);
                li.textContent = 'No repos for this user!';
                return;
            }

            json.forEach(x => {
                const li = document.createElement('li');
                const a = document.createElement('a');

                li.appendChild(a);
                ul.appendChild(li);

                a.href = x.html_url;
                a.textContent = x.full_name;
            })
        })
        .catch(() => {
            const li = document.createElement('li');
            li.textContent = 'No such username!';

            ul.appendChild(li);
        });
}