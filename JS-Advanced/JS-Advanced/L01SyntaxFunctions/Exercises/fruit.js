function price(fruit, weight, pricePerKg){
    let weightKg = weight / 1000;
    let price = (weightKg * pricePerKg).toFixed(2);

    console.log(`I need $${price} to buy ${weightKg.toFixed(2)} kilograms ${fruit}.`);
}

price('orange', 2500, 1.80);
price('apple', 1563, 2.35);