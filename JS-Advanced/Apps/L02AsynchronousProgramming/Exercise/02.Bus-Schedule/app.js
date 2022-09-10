function solve() {
    const departBtn = document.getElementById('depart');
    const arriveBtn = document.getElementById('arrive');
    const infoSpan = document.querySelector('#info span');

    let nextStopId = 'depot';
    let stopName = '';

    async function depart() {
        try {
            const url = `http://localhost:3030/jsonstore/bus/schedule/${nextStopId}`;
            const response = await fetch(url);

            if(response.status !== 200){
                throw new Error();
            }

            const stopInfo = await response.json();

            if(typeof stopInfo.name !== 'string' || typeof stopInfo.next !== 'string'){
               throw new Error();
            }

            stopName = stopInfo.name;
            infoSpan.textContent = `Next stop ${stopName}`;
            nextStopId = stopInfo.next;

            departBtn.disabled = true;
            arriveBtn.disabled = false;
        } catch {

        }
    }

    function arrive() {
        infoSpan.textContent = `Arriving at ${stopName}`;

        departBtn.disabled = false;
        arriveBtn.disabled = true;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();