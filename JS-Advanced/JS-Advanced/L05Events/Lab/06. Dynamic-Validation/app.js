function validate() {
    let emailInputEl = document.getElementById('email');
    emailInputEl.addEventListener('change', onChange);

    function onChange(){
        let email = emailInputEl.value;
        let regex = /^[a-z]+@[a-z]+\.[a-z]+$/;

        if (regex.test(email)){
            emailInputEl.className = '';
        }
        else{
            emailInputEl.className = 'error';
        }
    }
}