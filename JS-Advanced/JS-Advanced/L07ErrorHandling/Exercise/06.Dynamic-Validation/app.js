function validate() {
    const input = document.getElementById('email');

    input.addEventListener('change', () => {
       if(/^[a-z]+@[a-z]+\.[a-z]+$/.test(input.value)){
           input.classList.remove('error');
       }
       else {
           input.classList.add('error');
       }
    });
}