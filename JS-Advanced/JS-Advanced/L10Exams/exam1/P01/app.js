function solution() {
    const [gifts, sent, discarded] = document.querySelectorAll('section ul');

    const button = document.querySelector('button');
    const input = document.querySelector('input');

    button.addEventListener('click', () => {
        const li = document.createElement('li');
        li.className = 'gift';
        li.textContent = input.value;

        const sendBtn = document.createElement('button');
        sendBtn.textContent = 'Send';
        sendBtn.id = 'sendButton';
        const discardBtn = document.createElement('button');
        discardBtn.textContent = 'Discard';
        discardBtn.id = 'discardButton';

        li.appendChild(sendBtn);
        li.appendChild(discardBtn);

        gifts.appendChild(li);

        const newChildren = Array.from(gifts.children).sort((a, b) => a.textContent.localeCompare(b.textContent));
        newChildren.forEach(x => gifts.appendChild(x));

        input.value = '';

        sendBtn.addEventListener('click', (e) => {
           addListItem(sent, e)
        });

        discardBtn.addEventListener('click', (e) => {
            addListItem(discarded, e);
        });

        function addListItem(ul, e){
            const giftName =  e.target.parentElement.textContent.replace('SendDiscard', '');

            const li = document.createElement('li');
            li.className = 'gift';
            li.textContent = giftName;

            ul.appendChild(li);
            e.target.parentElement.remove();
        }
    });
}