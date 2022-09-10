function solve() {
    document.querySelector('#btnSend').addEventListener('click', onClick);

    function onClick() {
        let restaurantsInfo = document.querySelector('#inputs textarea').value.replace('["', '').replace('"]', '').split('","');
        let restaurants = [];

        for (let x = 0; x < restaurantsInfo.length; x++) {
            let currentRestInfo = restaurantsInfo[x].split(' - ');

            let name = currentRestInfo[0];
            let workers = currentRestInfo[1].split(', ').map(x => {
                let info = x.split(' ');
                return makeWorker(info[0], Number(info[1]));
            });

            let restaurant = restaurants.find(x => x.name === name);

            if (restaurant) {
                let newWorkers = workers.filter(x => !restaurant.workers.some(y => y.name === x.name));
                newWorkers.forEach(x => restaurant.workers.push(x));
            } else {
                restaurants.push(makeRestaurant(name, workers));
            }
        }

        let best = restaurants.reduce((acc, c) => acc.average() > c.average() ? acc : c);
        best.workers.sort((a, b) => b.salary - a.salary);

        let bestParagraph = document.querySelector('#bestRestaurant p');
        let workersParagraph = document.querySelector('#workers p');

        workersParagraph.textContent = '';
        bestParagraph.textContent = `Name: ${best.name} Average Salary: ${best.average().toFixed(2)} Best Salary: ${best.max().toFixed(2)}`;

        best.workers.forEach(x => workersParagraph.textContent += `Name: ${x.name} With Salary: ${x.salary.toString()} `);
        workersParagraph.textContent = workersParagraph.textContent.trim();

        function makeRestaurant(name, workers) {
            return {
                name,
                workers,
                average() {
                    return this.workers.reduce((acc, c) => acc + c.salary / this.workers.length, 0);
                },
                max() {
                    return this.workers.reduce((acc, c) => acc > c.salary ? acc : c.salary, 0);
                }
            };
        }

        function makeWorker(name, salary) {
            return {
                name,
                salary,
            };
        }
    }
}