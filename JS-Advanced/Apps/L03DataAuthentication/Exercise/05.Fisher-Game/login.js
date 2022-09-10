function attachListeners() {
    const [registerForm, loginForm] = document.querySelectorAll('form');

    const loginUrl = 'http://localhost:3030/users/login';
    const registerUrl = 'http://localhost:3030/users/register';

    registerForm.addEventListener('submit', async (e) => {
        e.preventDefault();

        const [email, pass, rePass] = registerForm.querySelectorAll('input');

        if (email.value === '' || pass.value === '' || rePass.value === '' || pass.value !== rePass.value) {
            return;
        }

        const response = await fetch(registerUrl, {
            method: 'post',
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify({email: email.value, password: pass.value}),
        });

        if (!response.ok) {
            return;
        }

        const info = await response.json();
        storeInfo(info);

        email.value = '';
        pass.value = '';
        rePass.value = '';
    });

    loginForm.addEventListener('submit', async (e) => {
        e.preventDefault();

        const [email, pass] = loginForm.querySelectorAll('input');

        const response = await fetch(loginUrl, {
            method: 'post',
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify({email: email.value, password: pass.value}),
        });

        if (!response.ok) {
            return;
        }

        const info = await response.json();
        storeInfo(info);

        email.value = '';
        pass.value = '';
    });

    function storeInfo(info) {
        localStorage.removeItem('accessToken');
        localStorage.removeItem('userId');
        localStorage.setItem('accessToken', info.accessToken);
        localStorage.setItem('userId', info._id);
    }
}

attachListeners();