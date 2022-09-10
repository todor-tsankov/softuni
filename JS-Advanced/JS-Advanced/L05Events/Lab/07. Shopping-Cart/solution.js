function solve() {
    document.querySelector('.shopping-cart').addEventListener('click', addProduct);
    document.querySelector('.checkout').addEventListener('click', checkout);

    let products = [];
    let totalPrice = 0;

    let textArea = document.querySelector('textarea');

    function addProduct(event) {
        if (event.target.className !== 'add-product') {
            return;
        }

        let product = event.target.parentElement.parentElement;

        let name = product.children[1].children[0].textContent;
        let price = Number(product.children[3].textContent);

        if (!products.some(y => y === name)) {
            products.push(name);
        }

        totalPrice += price;
        textArea.value += `Added ${name} for ${price.toFixed(2)} to the cart.\n`;
    }

    function checkout() {
        textArea.value += `You bought ${products.join(', ')} for ${totalPrice.toFixed(2)}.`;

        document.querySelector('.shopping-cart').removeEventListener('click', addProduct);
        document.querySelector('.checkout').removeEventListener('click', checkout);

        Array.from(document.querySelectorAll('button[class="add-product"]')).forEach(x => x.disabled = true);
    }
}