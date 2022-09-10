async function getInfo() {
    const stopId = document.getElementById('stopId');
    const div = document.getElementById('stopName');

    const ul = document.getElementById('buses');
    Array.from(ul.children).forEach(x => x.remove());

    const url = `http://localhost:3030/jsonstore/bus/businfo/${stopId.value}`;
    stopId.value = '';

    try {
        const response = await fetch(url);

        if (response.status !== 200) {
            throw new Error();
        }

        const stopInfo = await response.json();
        div.textContent = stopInfo.name;

        if(typeof stopInfo.buses !== 'object'){
            throw new Error();
        }

        for (let busId in stopInfo.buses) {
            const minutes = stopInfo.buses[busId];

            if(typeof minutes !== 'number'){
                throw new Error();
            }

            const li = document.createElement('li');
            li.textContent = `Bus ${busId} arrives in ${minutes} minutes`;

            ul.appendChild(li);
        }
    } catch {
        Array.from(ul.children).forEach(x => x.remove());
        div.textContent = 'Error';
    }

}