async function lockedProfile() {

    const profileTemplate = `<div class="profile"><img src="./iconProfile2.png" class="userIcon" />
                             <label>Lock</label><input type="radio" name="user@{id}Locked" value="lock" checked>
                             <label>Unlock</label><input type="radio" name="user@{id}Locked" value="unlock"><br>
                             <hr><label>Username</label><input type="text" name="user1Username" value="@username" disabled readonly />
                             <div id="user1HiddenFields" style="display: none"><hr><label>Email:</label><input type="email" name="user1Email" value="@email" disabled readonly />
                             <label>Age:</label><input type="email" name="user1Age" value="@age" disabled readonly />
                             </div><button>Show more</button></div>`;

    const profilesUrl = 'http://localhost:3030/jsonstore/advanced/profiles';

    const response = await fetch(profilesUrl);
    const profiles = await response.json();

    const main = document.getElementById('main');

    if (main.children[0]) {
        main.children[0].remove();
    }

    let counter = 1;

    for (let id in profiles) {
        const profile = profiles[id];
        main.innerHTML += profileTemplate
            .replaceAll('@{id}', (counter++).toString())
            .replace('@username', profile.username)
            .replace('@email', profile.email)
            .replace('@age', profile.age);
    }
    main.addEventListener('click', (e) => {
        if (e.target.nodeName !== 'BUTTON') {
            return;
        }

        const parentDiv = e.target.parentElement;
        const hiddenDiv = parentDiv.querySelector('#user1HiddenFields');
        const radio1 = parentDiv.querySelector('input');

        if (radio1.checked) {
            return;
        }

        if (hiddenDiv.style.display === 'none') {
            hiddenDiv.style.display = 'block';
            e.target.textContent = 'Hide it';
        } else {
            hiddenDiv.style.display = 'none';
            e.target.textContent = 'Show more';
        }
    });
}