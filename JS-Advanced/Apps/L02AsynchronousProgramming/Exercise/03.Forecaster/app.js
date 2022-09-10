function attachEvents() {
    const forecastDiv = document.getElementById('forecast');
    const submitBtn = document.getElementById('submit');
    const location = document.getElementById('location');
    const locationsUrl = 'http://localhost:3030/jsonstore/forecaster/locations';

    const current = document.getElementById('current');
    const upcoming = document.getElementById('upcoming');

    const conditionSymbols = {
        'Sunny': '&#x2600;',
        'Partly sunny': ' &#x26C5;',
        'Overcast': '&#x2601;',
        'Rain': '&#x2614;',
        'Degrees': '&#176;',
    };

    submitBtn.addEventListener('click', async () => {
        try {
            clear();
            const response = await fetch(locationsUrl);
            const locations = await response.json();

            const code = locations.find(x => x.name === location.value).code;
            const todayUrl = `http://localhost:3030/jsonstore/forecaster/today/${code}`;

            const todayResponse = await fetch(todayUrl);
            const todayInfo = await todayResponse.json();

            const threeDayUrl = `http://localhost:3030/jsonstore/forecaster/upcoming/${code}`;
            const threeDayResponse = await fetch(threeDayUrl);
            const threeDayInfo = await threeDayResponse.json();

            //current
            const conditionDiv = createElement('div', 'forecasts', '');
            const conditionSymbolSpan = createElement('span', 'condition symbol', conditionSymbols[todayInfo.forecast.condition]);
            const conditionSpan = createElement('span', 'condition', '');

            createThreeSpansToday(todayInfo.forecast, conditionSpan, todayInfo.name);

            conditionDiv.appendChild(conditionSymbolSpan);
            conditionDiv.appendChild(conditionSpan);
            current.appendChild(conditionDiv);

            //upcoming
            const parentDiv = createElement('div', 'forecast-info', '');

            threeDayInfo.forecast.forEach(x => {
                const upSpan = createElement('span', 'upcoming', '');
                createThreeSpansUpcoming(x, upSpan);
                parentDiv.appendChild(upSpan);
            });

            upcoming.appendChild(parentDiv);

            forecastDiv.style.display = 'block';
            location.value = '';

        } catch (e) {
            clear();

            const span = document.createElement('span');
            span.textContent = 'Error!';

            current.appendChild(span);
            console.log(e.message);
        }
    });

    function clear() {
        if (current.children[1]) {
            current.children[1].remove();
        }

        if (upcoming.children[1]) {
            upcoming.children[1].remove();
        }
    }

    function createThreeSpansToday(forecast, parentSpan, locationName) {
        const span1 = createElement('span', 'forecast-data', locationName);
        const span2 = createElement('span', 'forecast-data', `${forecast.low}°/${forecast.high}°`);
        const span3 = createElement('span', 'forecast-data', forecast.condition);

        parentSpan.appendChild(span1);
        parentSpan.appendChild(span2);
        parentSpan.appendChild(span3);
    }

    function createThreeSpansUpcoming(forecast, parentSpan) {
        const span1 = createElement('span', 'symbol', conditionSymbols[forecast.condition]);
        const span2 = createElement('span', 'forecast-data', `${forecast.low}°/${forecast.high}°`);
        const span3 = createElement('span', 'forecast-data', forecast.condition);

        parentSpan.appendChild(span1);
        parentSpan.appendChild(span2);
        parentSpan.appendChild(span3);
    }

    function createElement(name, className, text) {
        const element = document.createElement(name);
        element.className = className;
        element.innerHTML = text;

        return element;
    }
}

attachEvents();