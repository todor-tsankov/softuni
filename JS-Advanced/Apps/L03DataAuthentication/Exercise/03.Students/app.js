async function addListeners() {
    const form = document.getElementById('form');
    const tBody = document.querySelector('tbody');

    const url = 'http://localhost:3030/jsonstore/collections/students';

    await loadStudents();

    form.addEventListener('submit', async (e) => {
        e.preventDefault();

        const formData = new FormData(form);

        const firstName = formData.get('firstName');
        const lastName = formData.get('lastName');
        const facultyNumber = formData.get('facultyNumber');
        const grade = Number(formData.get('grade'));

        if (firstName === '' || lastName === '' || facultyNumber === ''
            || Number.isNaN(grade) || !/^\d*$/.test(facultyNumber) || !/^\d*$/.test(grade)) {
            return;
        }

        await fetch(url, {
            method: 'post',
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify({firstName, lastName, facultyNumber, grade}),
        });

        await loadStudents();

        [...form.querySelectorAll('input')].forEach(x => x.value = '');
    });

    async function loadStudents() {
        tBody.innerHTML = '';

        const response = await fetch(url);
        const students = await response.json();

        Object.values(students).forEach(x => {
            const tr = document.createElement('tr');

            tr.appendChild(makeTd(x.firstName));
            tr.appendChild(makeTd(x.lastName));
            tr.appendChild(makeTd(x.facultyNumber));
            tr.appendChild(makeTd(x.grade.toFixed(2)));

            tBody.appendChild(tr);
        });
    }

    function makeTd(text) {
        const td = document.createElement('td');
        td.textContent = text;

        return td;
    }
}

addListeners();