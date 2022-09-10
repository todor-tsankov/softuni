function attachEvents() {
    const loadBtn = document.getElementById('loadBtn');
    const catchesDiv = document.getElementById('catches');
    const addForm = document.getElementById('addForm');
    const addBtn = document.getElementById('addBtn');

    const baseUrl = 'http://localhost:3030/data/catches';

    if (this.localStorage.getItem('accessToken')) {
        addBtn.disabled = false;
    }

    loadBtn.addEventListener('click', async () => {
        catchesDiv.innerHTML = '';

        const response = await fetch(baseUrl);
        const catches = await response.json();

        catches.forEach(createCatch);
    });

    addBtn.addEventListener('click', async () => {
        const [angler, weight, species, location, bait, captureTime] = addForm.querySelectorAll('input');

        if (angler.value === ''
            || weight.value === ''
            || species.values === ''
            || location.value === '' || bait.value === ''
            || captureTime.value === '') {
            return;
        }

        await fetch(baseUrl, {
            method: 'post',
            headers: {'Content-Type': 'application/json', 'X-Authorization': localStorage.getItem('accessToken')},
            body: JSON.stringify({
                angler: angler.value,
                weight: Number(weight.value),
                location: location.value,
                species: species.value,
                bait: bait.value,
                'captureTime ': Number(captureTime.value),
            })
        });

        loadBtn.click();

        angler.value = '';
        weight.value = '';
        species.value = '';
        location.value = '';
        bait.value = '';
        captureTime.value = '';
    });

    function createCatch(info) {
        let disabled = true;

        if (info._ownerId === localStorage.getItem('userId')) {
            disabled = false;
        }

        const _catch = e('div', {className: 'catch'},
            e('label', {}, 'Angler'),
            e('input', {type: 'text', className: 'angler', value: info.angler}),
            e('hr'),
            e('label', {}, 'Weight'),
            e('input', {type: 'text', className: 'weight', value: info.weight}),
            e('hr'),
            e('label', {}, 'Species'),
            e('input', {type: 'text', className: 'species', value: info.species}),
            e('hr'),
            e('label', {}, 'Location'),
            e('input', {type: 'text', className: 'location', value: info.location}),
            e('hr'),
            e('label', {}, 'Bait'),
            e('input', {type: 'text', className: 'bait', value: info.bait}),
            e('hr'),
            e('label', {}, 'Capture Time'),
            e('input', {type: 'text', className: 'captureTime', value: info['captureTime ']}),
            e('hr'),
            e('button', {disabled: disabled}, 'Update'),
            e('button', {disabled: disabled}, 'Delete'),
        );

        _catch.id = info._id;

        catchesDiv.appendChild(_catch);
    }

    catchesDiv.addEventListener('click', async (e) => {
        if (e.target.nodeName !== 'BUTTON') {
            return;
        }

        const id = e.target.parentElement.id;
        const thisUrl = baseUrl + '/' + id;

        if (e.target.textContent === 'Update') {
            const [angler, weight, species, location, bait, captureTime] = e.target.parentElement.querySelectorAll('input');
            await fetch(thisUrl, {
                method: 'put',
                headers: {'Content-Type': 'application/json', 'X-Authorization': localStorage.getItem('accessToken')},
                body: JSON.stringify({
                    angler: angler.value,
                    weight: Number(weight.value),
                    location: location.value,
                    species: species.value,
                    bait: bait.value,
                    'captureTime ': Number(captureTime.value),
                }),
            });
        } else if (e.target.textContent === 'Delete') {
            await fetch(thisUrl, {
                method: 'delete',
                headers: {'Content-Type': 'application/json', 'X-Authorization': localStorage.getItem('accessToken')},
            });
        }

        loadBtn.click();
    });

    function e(type, attributes, ...content) {
        const result = document.createElement(type);

        for (let [attr, value] of Object.entries(attributes || {})) {
            if (attr.substring(0, 2) == 'on') {
                result.addEventListener(attr.substring(2).toLocaleLowerCase(), value);
            } else {
                result[attr] = value;
            }
        }

        content = content.reduce((a, c) => a.concat(Array.isArray(c) ? c : [c]), []);

        content.forEach(e => {
            if (typeof e == 'string' || typeof e == 'number') {
                const node = document.createTextNode(e);
                result.appendChild(node);
            } else {
                result.appendChild(e);
            }
        });

        return result;
    }
}

attachEvents();

