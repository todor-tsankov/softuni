function solve() {
    const inputs = document.getElementById('container').children;

    const name = inputs[0];
    const hall = inputs[1];
    const ticketPrice = inputs[2];
    const button = inputs[3];

    const moviesUl = document.querySelector('#movies ul');
    const archiveUl = document.querySelector('#archive ul');
    const clearBtn = document.querySelector('#archive button');

    button.addEventListener('click', addMovie);
    clearBtn.addEventListener('click', clear);

    function addMovie(event){
        event.preventDefault();

        if (name.value.length < 1 || hall.value.length < 1 || ticketPrice.value.length < 1 || Number.isNaN(Number(ticketPrice.value))){
            return;
        }

        const li = document.createElement('li');

        const spanInLi = document.createElement('span');
        spanInLi.textContent = name.value;

        const strongInLi = document.createElement('strong');
        strongInLi.textContent = `Hall: ${hall.value}`;

        const divInLi = document.createElement('div');

        const strongInDiv = document.createElement('strong');
        strongInDiv.textContent = Number(ticketPrice.value).toFixed(2);

        const inputInDiv = document.createElement('input');
        inputInDiv.placeholder = 'Tickets Sold';

        const buttonInDiv = document.createElement('button');
        buttonInDiv.textContent = 'Archive';

        buttonInDiv.addEventListener('click', archive);

        li.appendChild(spanInLi);
        li.appendChild(strongInLi);
        li.appendChild(divInLi);

        divInLi.appendChild(strongInDiv);
        divInLi.appendChild(inputInDiv);
        divInLi.appendChild(buttonInDiv);

        moviesUl.appendChild(li);

        for(let x = 0; x < inputs.length; x++){
            inputs[x].value = '';
        }
    }

    function archive(e){
        const oldLi = e.target.parentElement.parentElement;
        const li = document.createElement('li');

        const span = document.createElement('span');
        span.textContent = oldLi.children[0].textContent;

        const strong = document.createElement('strong');

        const ticketsStr = oldLi.children[2].children[1].value;
        const numberTickets = Number(ticketsStr);

        const price = Number(oldLi.children[2].children[0].textContent);

        if (ticketsStr === undefined || ticketsStr.length < 1 || Number.isNaN(numberTickets)){
            return;
        }

        strong.textContent = `Total amount: ${(numberTickets * price).toFixed(2)}`;

        const button = document.createElement('button');
        button.textContent = 'Delete';

        li.appendChild(span);
        li.appendChild(strong);
        li.appendChild(button);

        archiveUl.appendChild(li);
        button.addEventListener('click', deleteArchive);
        oldLi.remove();
    }

    function deleteArchive(e){
        e.target.parentElement.remove();
    }

    function clear(e){
        let lis = document.querySelectorAll('#archive ul li');

        for (let x = 0; x < lis.length; x++){
            lis[x].remove();
        }
    }
}