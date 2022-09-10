function solution() {
    const giftInput = document.querySelector('input');
    const [gifts, sent, discarded] = document.querySelectorAll('section ul');

    document.querySelector('button').addEventListener('click', () => {
        const li = document.createElement('li');
        li.textContent = giftInput.value;
        li.className = 'gift';

        const sendBtn = document.createElement('button');
        sendBtn.textContent = 'Send';
        sendBtn.id = 'sendButton';

        const discardBtn = document.createElement('button');
        discardBtn.textContent = 'Discard';
        discardBtn.id = 'discardButton';

        gifts.appendChild(li);
        li.appendChild(sendBtn);
        li.appendChild(discardBtn);

        giftInput.value = '';
        Array.from(gifts.children)
            .sort((a, b) => a.textContent.localeCompare(b.textContent))
            .forEach(x => gifts.appendChild(x));

        sendBtn.addEventListener('click', (e) => {
            moveGift(e.target.parentElement, sent);
        });

        discardBtn.addEventListener('click', (e) => {
            moveGift(e.target.parentElement, discarded);
        });

        function moveGift(parent, place) {
            const newLi = document.createElement('li');
            newLi.className = 'gift';
            newLi.textContent = parent.textContent.replace('SendDiscard', '');

            parent.remove();
            place.appendChild(newLi);
        }
    });
}