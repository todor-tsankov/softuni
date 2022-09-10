solve('["PizzaHut - Peter 500, George 300, Mark 800","TheLake - Bob 130, Joe 70, Jane 60","PizzaHut - Peter1 500, George1 300, Mark1 800"]');

function solve(input) {
    let restaurantsInfo = input.replace('["', '').replace('"]', '').split('","');
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

    let firstAvg = restaurants[0].average();
    let second = restaurants[1].average();

    let best = restaurants.reduce((acc, c) => acc.average() > c.average() ? acc : c);
    best.workers.sort((a, b) => b.salary - a.salary);

    function makeRestaurant(name, workers) {
        return {
            name,
            workers,
            average() {
                return Number(this.workers.reduce((acc, c) => acc + c.salary / this.workers.length, 0).toFixed(2));
            },
            max() {
                return Number(this.workers.reduce((acc, c) => acc > c.salary ? acc : c.salary, 0).toFixed(2));
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
