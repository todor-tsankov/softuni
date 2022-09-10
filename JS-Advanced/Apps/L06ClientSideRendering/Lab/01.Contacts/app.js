import {html, render} from '../node_modules/lit-html/lit-html.js';
import {contacts} from './contacts.js'

const contactsDiv = document.getElementById('contacts');

const cardTemplate = (contact) => html`
    <div class="contact card">
        <div>
            <i class="far fa-user-circle gravatar"></i>
        </div>
        <div class="info">
            <h2>Name: ${contact.name}</h2>
            <button class="detailsBtn">Details</button>
            <div class="details" id=${contact.id}>
                <p>Phone number: ${contact.phoneNumber}</p>
                <p>Email: ${contact.email}</p>
            </div>
        </div>
    </div>
`;

render(contacts.map(cardTemplate), contactsDiv);

contactsDiv.addEventListener('click', (e) => {
    if (e.target.nodeName !== 'BUTTON') {
        return;
    }

    const detailsDiv = e.target.parentNode.querySelector('.details');

    if (detailsDiv.style.display === 'block') {
        detailsDiv.style.display = 'none';
    } else {
        detailsDiv.style.display = 'block';
    }
});