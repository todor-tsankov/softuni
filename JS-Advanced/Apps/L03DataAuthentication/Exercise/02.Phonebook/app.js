function attachEvents() {
    const phoneBookUl = document.getElementById('phonebook');
    const person = document.getElementById('person');
    const phone = document.getElementById('phone');

    const loadBtn = document.getElementById('btnLoad');
    const createBtn = document.getElementById('btnCreate');

    const baseUrl = 'http://localhost:3030/jsonstore/phonebook';

    loadBtn.addEventListener('click', async () => {
        const response = await fetch(baseUrl);
        const records = await response.json();

        phoneBookUl.innerHTML = '';

        Object.entries(records).forEach(([id, x]) => {
            const li = document.createElement('li');
            const deleteDtn = document.createElement('button');

            li.textContent = `${x.person}: ${x.phone} `;

            deleteDtn.textContent = 'Delete';
            deleteDtn.id = id;

            li.appendChild(deleteDtn);
            phoneBookUl.appendChild(li);
        });
    });

    createBtn.addEventListener('click', () => {
        fetch(baseUrl, {
            method: 'post',
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify({person: person.value, phone: phone.value}),
        });

        person.value = '';
        phone.value = '';

        loadBtn.click();
    });

    phoneBookUl.addEventListener('click', (e) => {
        if (e.target.nodeName !== 'BUTTON') {
            return;
        }

        fetch(baseUrl + '/' + e.target.id, {
            method: 'delete',
        });

        e.target.parentElement.remove();
    });
}

attachEvents();