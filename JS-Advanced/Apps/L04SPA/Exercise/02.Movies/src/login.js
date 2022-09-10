import redirect from './app.js';

const loginUrl = 'http://localhost:3030/users/login';

let parent;
let form;

export function setupLogin(parentTarget, formTarget){
    parent = parentTarget;
    form = formTarget;

    form.addEventListener('submit', onSubmit);
}

export function showLogin(){
    parent.innerHTML = '';
    parent.appendChild(form);
}

async function onSubmit(ev){
    ev.preventDefault();

    const [email, password] = [...form.querySelectorAll('input')];
    const response = await fetch(loginUrl, {
       method: 'post',
       headers: {'Content-Type': 'application/json'},
       body: JSON.stringify({email: email.value, password: password.value}),
    });

    if(response.ok){
        const info = await response.json();

        email.value = '';
        password.value = '';

        sessionStorage.removeItem('email');
        sessionStorage.removeItem('accessToken');

        sessionStorage.setItem('email', info.email);
        sessionStorage.setItem('accessToken', info.accessToken);

        redirect('home');
    }
}