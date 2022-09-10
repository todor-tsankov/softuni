function solve() {
    document.querySelector('body div div button').addEventListener('click', generate);
    document.querySelectorAll('body div div button')[1].addEventListener('click', buy);

    function buy() {
        let totalPrice = 0;
        let furniture = [];
        let decFactor = 0;
        let count = 0;

        let trs = Array.from(document.querySelectorAll('tbody tr'));

        for (let row of trs){
            let children = row.children;

            if (children[4].children[0].checked){
                furniture.push(children[1].children[0].textContent);
                totalPrice += Number(children[2].children[0].textContent);
                decFactor += Number(children[3].children[0].textContent);

                count++;
            }
        }

        let result = document.querySelectorAll('textarea')[1];
        decFactor = decFactor / count;

        result.value = `Bought furniture: ${furniture.join(', ')}\n`;
        result.value += `Total price: ${totalPrice.toFixed(2)}\n`;
        result.value += `Average decoration factor: ${decFactor}`;
    }

    function generate() {
        let array = JSON.parse(document.querySelector('body div div textarea').value);
        let tbody = document.querySelector('tbody');

        for (let furniture of array) {
            let tr = document.createElement('tr');

            let image = document.createElement('img');
            image.src = furniture.img;
            tr.appendChild(createTd(image));

            let name = document.createElement('p');
            name.textContent = furniture.name;
            tr.appendChild(createTd(name));

            let price = document.createElement('p');
            price.textContent = furniture.price;
            tr.appendChild(createTd(price));

            let decFactor = document.createElement('p');
            decFactor.textContent = furniture.decFactor;
            tr.appendChild(createTd(decFactor));

            let input = document.createElement('input');
            input.type = 'checkbox';
            tr.appendChild(createTd(input));

            tbody.appendChild(tr);
        }

        function createTd(element) {
            let td = document.createElement('td');
            td.appendChild(element);
            return td;
        }
    }
}
