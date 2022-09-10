class Contact {
    constructor(firstName, lastName, phone, email) {
        this._firstName = firstName;
        this._lastName = lastName;
        this._phone = phone;
        this._email = email;

        this._online = false;
        this.titleDiv = document.createElement('div');
        this.article = document.createElement('article');

        this.titleDiv.className = 'title';
        this.titleDiv.textContent = this._firstName + ' ' + this._lastName;

        this.buttonInTitle = document.createElement('button');
        this.buttonInTitle.innerHTML = '&#8505;';

        const infoDiv = document.createElement('div');
        infoDiv.className = 'info';
        infoDiv.style.display = 'none';

        this.phoneSpan = document.createElement('span');
        this.phoneSpan.innerHTML = `&phone; ${this._phone}`;

        this.emailSpan = document.createElement('span');
        this.emailSpan.innerHTML = `&#9993; ${this._email}`;


        this.article.appendChild(this.titleDiv);
        this.article.appendChild(infoDiv);

        this.titleDiv.appendChild(this.buttonInTitle);
        infoDiv.appendChild(this.phoneSpan);
        infoDiv.appendChild(this.emailSpan);

        this.buttonInTitle.addEventListener('click', () => {
            if (infoDiv.style.display === 'none') {
                infoDiv.style.display = 'block';
            } else {
                infoDiv.style.display = 'none';
            }
        });
    }

    get firstName(){
        return this._firstName;
    }

    set firstName(value){
        this._firstName = value;
        this.titleDiv.innerHTML = this._firstName + ' ' + this._lastName;
        this.titleDiv.appendChild(this.buttonInTitle);
    }

    get lastName(){
        return this._lastName;
    }

    set lastName(value){
        this._lastName = value;
        this.titleDiv.innerHTML = this._firstName + ' ' + this._lastName;
        this.titleDiv.appendChild(this.buttonInTitle);
    }

    get phone(){
        return this._phone;
    }

    set phone(value){
        this._phone = value;
        this.phoneSpan.innerHTML = `&phone; ${this._phone}`;
    }

    get email(){
        return this._email;
    }

    set email(value){
        this._email = value;
        this.emailSpan.innerHTML = `&#9993; ${this._email}`;
    }

    get online() {
        return this._online;
    }

    set online(value) {
        if (value) {
            this.titleDiv.classList.add('online');
        } else {
            this.titleDiv.classList.remove('online');
        }

        this._online = value;
    }

    render(id) {
        const element = document.getElementById(id);
        element.appendChild(this.article);
    }
}

class Contact {
    constructor(firstName, lastName, phone, email) {
        this._firstName = firstName;
        this._lastName = lastName;
        this._phone = phone;
        this._email = email;

        this._online = false;
        this.titleDiv = document.createElement('div');
        this.article = document.createElement('article');

        this.titleDiv.className = 'title';
        this.titleDiv.textContent = this.firstName + ' ' + this.lastName;

        const buttonInTitle = document.createElement('button');
        buttonInTitle.innerHTML = '&#8505;';

        const infoDiv = document.createElement('div');
        infoDiv.className = 'info';
        infoDiv.style.display = 'none';

        this.phoneSpan = document.createElement('span');
        this.phoneSpan.innerHTML = `&phone; ${this.phone}`;

        this.emailSpan = document.createElement('span');
        this.emailSpan.innerHTML = `&#9993; ${this.email}`;


        this.article.appendChild(this.titleDiv);
        this.article.appendChild(infoDiv);

        this.titleDiv.appendChild(buttonInTitle);
        infoDiv.appendChild(this.phoneSpan);
        infoDiv.appendChild(this.emailSpan);

        buttonInTitle.addEventListener('click', () => {
            if (infoDiv.style.display === 'none') {
                infoDiv.style.display = '';
            } else {
                infoDiv.style.display = 'none';
            }
        });
    }

    get firstName(){
        return this._firstName;
    }

    set firstName(value){
        this._firstName = value;
        this.titleDiv.textContent = this._firstName + ' ' + this._lastName;
    }

    get lastName(){
        return this._lastName;
    }

    set lastName(value){
        this._lastName= value;
        this.titleDiv.textContent = this._firstName + ' ' + this._lastName;
    }

    get phone(){
        return this._phone;
    }

    set phone(value){
        this._phone = value;
        this.phoneSpan.innerHTML = `&phone; ${this._phone}`;
    }

    get email(){
        return this._email;
    }

    set email(value){
        this._email = value;
        this.emailSpan.innerHTML = `&#9993; ${this._email}`;
    }

    get online() {
        return this._online;
    }

    set online(value) {
        if (value) {
            this.titleDiv.classList.add('online');
        } else {
            this.titleDiv.classList.remove('online');
        }

        this._online = value;
    }

    render(id) {
        const element = document.getElementById(id);
        element.appendChild(this.article);
    }
}