async function loadCommits() {
    const ul = document.getElementById('commits');
    Array.from(ul.children).forEach(x => x.remove());

    const username = document.getElementById('username').value;
    const repo = document.getElementById('repo').value;

    const url = `https://api.github.com/repos/${username}/${repo}/commits`;

    const response = await fetch(url);

    if (response.status !== 200) {
        makeLi(`Error: ${response.status} (${response.statusText})`);
        return;
    }

    const commits = await response.json();
    commits.forEach(x => makeLi(`${x.commit.author.name}: ${x.commit.message}`));

    function makeLi(text) {
        const li = document.createElement('li');
        li.textContent = text;

        ul.appendChild(li);
    }
}