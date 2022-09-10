import redirect from './app.js';

const registerUrl = 'http://localhost:3030/users/register';

let parent;
let form;

export function setupRegister(parentTarget, formTarget){
    parent = parentTarget;
    form = formTarget;

    form.addEventListener('submit', onSubmit);
}

export function showRegister(){
    parent.innerHTML = '';
    parent.appendChild(form);
}

async function onSubmit(ev){
    ev.preventDefault();

    const [email, password, repeat] = [...form.querySelectorAll('input')];

    if(email.value === '' || password.value === '' || password.value !== repeat.value || password.length < 6){
        return;
    }

    const response = await fetch(registerUrl, {
        method: 'post',
        headers: {'Content-Type': 'application/json'},
        body: JSON.stringify({email: email.value, password: password.value}),
    });

    if(response.ok){
        const info = await response.json();

        email.value = '';
        password.value = '';
        repeat.value = '';

        sessionStorage.removeItem('email');
        sessionStorage.removeItem('accessToken');

        sessionStorage.setItem('email', info.email);
        sessionStorage.setItem('accessToken', info.accessToken);

        redirect('home');
    }
}