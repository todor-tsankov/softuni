async function solution() {
    const template = `<div class="accordion"><div class="head"><span>@title</span>
                      <button class="button" id="@id">More</button>
                      </div><div class="extra"> <p></p></div> </div>`;

    const main = document.getElementById('main');

    const initialUrl = 'http://localhost:3030/jsonstore/advanced/articles/list';
    const response = await fetch(initialUrl);
    const list = await response.json();

    list.forEach(x => {
        main.innerHTML += template
            .replace('@id', x._id)
            .replace('@title', x.title);
    });

    main.addEventListener('click', async (e) => {
        if (e.target.nodeName !== 'BUTTON') {
            return;
        }

        const accordionDiv = e.target.parentElement.parentElement;
        const extra = accordionDiv.querySelector('.extra');
        const p = extra.querySelector('p');

        if(e.target.textContent === 'More'){
            extra.style.display = 'inline';
            e.target.textContent = 'Less';
        } else {
            extra.style.display = 'none';
            e.target.textContent = 'More';
        }

        if(p.textContent !== ''){
            return;
        }

        const detailsUrl = `http://localhost:3030/jsonstore/advanced/articles/details/${e.target.id}`;
        const response = await fetch(detailsUrl);
        const info = await response.json();

        p.textContent = info.content;
    });
}

solution().then();