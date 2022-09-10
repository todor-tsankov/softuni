const Ascents = (props) => {

    const url = 'https://www.8a.nu/api/follows/global?pageIndex=1&pageSize=10';
    const input = <input/>;

    const load = async () => {
        const response = await fetch(url, {
            method: 'get',
            mode: 'no-cors'
        });

        console.log(response);
        const info = await response.json();

        console.log(input.value);
    };

    return (
        <div>
            <label>Number of items</label>
            {input}
            <button onClick={load}>Load from 8a</button>
        </div>
    );
};

export default Ascents;