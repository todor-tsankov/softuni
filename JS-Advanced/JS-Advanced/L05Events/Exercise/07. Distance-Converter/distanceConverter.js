function attachEventsListeners() {
    document.getElementById('convert').addEventListener('click', convert);

    const change = {
        km: (x, from) => from ? x * 1000 : x / 1000,
        m: (x) => x,
        cm: (x, from) => from ? x / 100 : x * 100,
        mm: (x, from) => from ? x / 1000 : x * 1000,
        mi: (x, from) => from ? x * 1609.34 : x / 1609.34,
        yrd: (x, from) => from ? x * 0.9144 : x / 0.9144,
        ft: (x, from) => from ? x * 0.3048 : x / 0.3048,
        in: (x, from) => from ? x * 0.0254 : x / 0.0254,
    };

    function convert() {
        const from = document.getElementById('inputUnits').value;
        const to = document.getElementById('outputUnits').value;

        const fromValue = Number(document.getElementById('inputDistance').value);
        document.getElementById('outputDistance').value = change[to](change[from](fromValue, true), false);
    }
}