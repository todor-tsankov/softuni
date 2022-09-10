function solve() {
    const form = document.querySelector('form');
    const [_, open, inProgress, complete ] = document.querySelectorAll('section div:nth-child(2)');

    const task = form.children[2];
    const desc = form.children[6];
    const date = form.children[9];

    form.children[11].addEventListener('click', (e) => {
       e.preventDefault();

        if(task.value === '' || desc.value === '' || date.value === ''){
            return;
        }

        const article = document.createElement('article');
        const h3 = document.createElement('h3');
        const p1 = document.createElement('p');
        const p2 = document.createElement('p');
        const div = document.createElement('div');
        const startBtn = document.createElement('button');
        const deleteBtn = document.createElement('button');

        article.appendChild(h3);
        article.appendChild(p1);
        article.appendChild(p2);
        article.appendChild(div);
        div.appendChild(startBtn);
        div.appendChild(deleteBtn);
        open.appendChild(article);

        h3.textContent = task.value;
        p1.textContent = 'Description: ' + desc.value;
        p2.textContent = 'Due Date: ' + date.value;
        div.className = 'flex';
        startBtn.className = 'green';
        startBtn.textContent = 'Start';
        deleteBtn.className = 'red';
        deleteBtn.textContent = 'Delete';

        let first = true;

        startBtn.addEventListener('click', (e) => {
            if(first){
                inProgress.appendChild(article);
                startBtn.textContent = 'Finish';
                startBtn.className = 'orange';
                div.appendChild(startBtn);
            } else if(!first){
                complete.appendChild(article);
                div.remove();
            }

            first = false;
        });

        deleteBtn.addEventListener('click', (e) => {
            e.target.parentElement.parentElement.remove();
        });
    });
}