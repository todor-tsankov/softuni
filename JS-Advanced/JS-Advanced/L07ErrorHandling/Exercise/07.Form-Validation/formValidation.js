function validate() {
    const button = document.getElementById('submit');
    const username = document.getElementById('username');
    const password = document.getElementById('password');
    const confirmPassword = document.getElementById('confirm-password');
    const email = document.getElementById('email');

    const isCompany = document.getElementById('company');
    const companyInfo = document.getElementById('companyInfo');
    const companyNumber = document.getElementById('companyNumber');

    const validDiv = document.getElementById('valid');

    isCompany.addEventListener('change', () => {
        if (isCompany.checked) {
            companyInfo.style.display = 'block';
        } else {
            companyInfo.style.display = 'none';
        }
    });

    button.addEventListener('click', (e) => {
        e.preventDefault();
        let isEverythingValid = true;

        if (username.value.length === 0 || !/^[A-Za-z0-9]{3,20}$/.test(username.value)) {
            applyIncorrectStyle(username);
            isEverythingValid = false;
        } else {
            removeStyle(username);
        }

        if (password.value.length === 0 || !/^[\w]{5,15}$/.test(password.value)) {
            applyIncorrectStyle(password);
            applyIncorrectStyle(confirmPassword);

            isEverythingValid = false;
        } else {
            removeStyle(password);
            removeStyle(confirmPassword);
        }

        if (password.value !== confirmPassword.value) {
            applyIncorrectStyle(password);
            applyIncorrectStyle(confirmPassword);

            isEverythingValid = false;
        }

        const emailParts = email.value.split('@');

        if (emailParts.length !== 2 || !emailParts[1].includes('.')) {
            applyIncorrectStyle(email);
            isEverythingValid = false;
        } else {
            removeStyle(email);
        }

        if (isCompany.checked) {
            const number = Number(companyNumber.value);

            if (Number.isNaN(number) || number < 1000 || number > 9999) {
                applyIncorrectStyle(companyNumber);
                isEverythingValid = false;
            } else {
                removeStyle(companyNumber);
            }
        } else {
            removeStyle(companyNumber);
        }

        if(isEverythingValid){
            validDiv.style.display = 'block';
        } else {
            validDiv.style.display = 'none';
        }

        function applyIncorrectStyle(el) {
            el.style.borderColor = 'red';
        }

        function removeStyle(el) {
            el.style.border = '';
        }
    });
}
