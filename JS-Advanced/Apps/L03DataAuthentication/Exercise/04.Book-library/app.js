function attachListeners() {
    const loadBooksBtn = document.getElementById('loadBooks');
    const tBody = document.querySelector('tbody');
    const createForm = document.querySelector('form');

    const author = document.getElementById('author');
    const title = document.getElementById('title');

    const baseUrl = 'http://localhost:3030/jsonstore/collections/books';
    let editId;


    loadBooksBtn.addEventListener('click', async () => {
        tBody.innerHTML = '';

        const response = await fetch(baseUrl);
        const books = await response.json();

        Object.entries(books).forEach(([id, x]) => {
            const tr = document.createElement('tr');
            const td1 = document.createElement('td');
            const td2 = document.createElement('td');
            const td3 = document.createElement('td');
            const editBtn = document.createElement('button');
            const deleteBtn = document.createElement('button');

            tBody.appendChild(tr);

            tr.appendChild(td1);
            tr.appendChild(td2);
            tr.appendChild(td3);

            td3.appendChild(editBtn);
            td3.appendChild(deleteBtn);

            td1.textContent = x.author;
            td2.textContent = x.title;

            editBtn.textContent = 'Edit';
            deleteBtn.textContent = 'Delete';

            editBtn.id = id;
            deleteBtn.id = id;
        });
    });

    loadBooksBtn.click();

    createForm.addEventListener('submit', async(e) => {
        e.preventDefault();

        let method = 'post';
        let url = baseUrl;

        if(editId){
            method = 'put';
            url += '/' + editId;

            editId = undefined;
            switchForm();
        }

        await fetch(url, {
            method: method,
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify({author: author.value, title: title.value}),
        });

        author.value = '';
        title.value = '';

        loadBooksBtn.click();
    });

    tBody.addEventListener('click', async(e) => {
        if (e.target.nodeName !== 'BUTTON') {
            return;
        }

        if (e.target.textContent === 'Delete') {
            await del(e.target);
            loadBooksBtn.click();
        } else if (e.target.textContent === 'Edit') {
            edit(e.target);
        }
    });

    async function del(target) {
        await fetch(baseUrl + '/' + target.id, {method: 'delete'});
    }

    function edit(target) {
        const tr = target.parentElement.parentElement;

        author.value = tr.children[0].textContent;
        title.value = tr.children[1].textContent;

        editId = target.id;

        switchForm();
    }

    function switchForm(){
        const h3 = createForm.children[0];
        const btn = createForm.children[5];

        if(h3.textContent === 'FORM'){
            h3.textContent = 'Edit FORM';
            btn.textContent = 'Save';
        } else {
            h3.textContent = 'FORM';
            btn.textContent = 'Submit';
        }
    }
}

attachListeners();