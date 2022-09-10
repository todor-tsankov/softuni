function deleteByEmail() {
    let email = document.querySelector('input[name="email"]');
    let rows = document.querySelectorAll('tbody tr');

    let found = false;

    for(let x = 0; x < rows.length; x++){
        let currentRow = rows[x];
        let currentEmail = currentRow.children[1];

        if (email.value === currentEmail.textContent){
            currentRow.remove();
            found = true;
        }
    }

    document.getElementById('result').textContent = found ? 'Deleted.' : 'Not found.';
    email.value = '';
}