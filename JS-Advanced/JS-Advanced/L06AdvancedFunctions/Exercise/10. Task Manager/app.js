function solve() {
    document.querySelector('form button').addEventListener('click', add);

    function add(e) {
        e.preventDefault();

        let inputs = document.querySelector('form').children;

        let title = inputs[2].value;
        let desc = inputs[6].value;
        let date = inputs[9].value;

        if (title.length < 1 || desc.length < 1 || date.length < 1) {
            return;
        }

        let article = document.createElement('article');

        let hInArticle = document.createElement('h3');
        hInArticle.textContent = title;
        article.appendChild(hInArticle);

        let pInArticle = document.createElement('p');
        pInArticle.textContent = `Description: ${desc}`;
        article.appendChild(pInArticle);

        let pInArticle2 = document.createElement('p');
        pInArticle2.textContent = `Due Date: ${date}`;
        article.appendChild(pInArticle2);

        let divInArticle = document.createElement('div');
        divInArticle.className = 'flex';
        article.appendChild(divInArticle);

        let startBtn = document.createElement('button');
        startBtn.textContent = 'Start';
        startBtn.className = 'green';


        startBtn.addEventListener('click', start);

        let deleteBtn = document.createElement('button');
        deleteBtn.textContent = 'Delete';
        deleteBtn.className = 'red';

        divInArticle.appendChild(startBtn);
        divInArticle.appendChild(deleteBtn);

        deleteBtn.addEventListener('click', deleteTask);

        document.querySelectorAll('section')[1].children[1].appendChild(article);

        function start(e) {
            let [first, second] = article.querySelectorAll('button');

            first.textContent = 'Delete';
            second.textContent = 'Finish';

            first.className = 'red';
            second.className = 'orange';

            first.removeEventListener('click', start);
            second.removeEventListener('click', deleteTask);

            first.addEventListener('click', deleteTask);
            second.addEventListener('click', finish);

            document.querySelectorAll('section')[2].children[1].appendChild(article);
        }

        function finish(){
            article.querySelector('div').remove();
            document.querySelectorAll('section')[3].children[1].appendChild(article);
        }

        function deleteTask(e) {
            article.remove();
        }
    }
}