function addDestination() {
    const [cityInput, countryInput] = document.querySelectorAll('input');
    const seasonSelect = document.querySelector('select');
    const tBody = document.getElementById('destinationsList');
    const [summer, autumn, winter, spring] = document.getElementById('summaryBox').querySelectorAll('input');

    if (cityInput.value === '' || countryInput.value === '') {
        return;
    }

    const tr = document.createElement('tr');
    const td1 = document.createElement('td');
    const td2 = document.createElement('td');

    td1.textContent = cityInput.value + ', ' + countryInput.value;
    td2.textContent = seasonSelect.value[0].toUpperCase() + seasonSelect.value.slice(1);

    tBody.appendChild(tr);
    tr.appendChild(td1);
    tr.appendChild(td2);

    if (seasonSelect.value === 'summer') {
        summer.value = (Number(summer.value) + 1).toString();
    } else if (seasonSelect.value === 'autumn') {
        autumn.value = (Number(autumn.value) + 1).toString();
    } else if (seasonSelect.value === 'winter') {
        winter.value = (Number(winter.value) + 1).toString();
    } else if (seasonSelect.value === 'spring') {
        spring.value = (Number(spring.value) + 1).toString();
    }

    cityInput.value = '';
    countryInput.value = '';
    seasonSelect.value = 'summer';

}