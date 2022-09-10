function loadRepos() {
    const div = document.getElementById('res');

    fetch('https://api.github.com/users/testnakov/repos')
        .then((response) => response.json())
        .then((json) => {
            div.textContent = JSON.stringify(json);
        });
}