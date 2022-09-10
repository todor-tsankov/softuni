import redirect from './app.js';
const logoutUrl = 'http://localhost:3030/users/logout';

export async function logout(){
    const response = await fetch(logoutUrl, {
        method: 'get',
        headers: {'X-Authorization': sessionStorage.getItem('accessToken')},
    });

    if(response.ok){
        sessionStorage.removeItem('accessToken');
        sessionStorage.removeItem('email');

        redirect('home');
    }
}