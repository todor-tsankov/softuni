function radar(speed, area) {
    let limit;

    if (area == 'motorway') {
        limit = 130;
    } else if (area == 'interstate') {
        limit = 90;
    } else if (area == 'city') {
        limit = 50;
    } else if (area == 'residential') {
        limit = 20;
    }

    let overLimit = speed - limit;
    let message;

    if(overLimit > 0){
        let status;

        if(overLimit <= 20){
            status = 'speeding';
        } else if(overLimit <= 40){
            status = 'excessive speeding';
        } else{
            status = 'reckless driving';
        }

        message = `The speed is ${overLimit} km/h faster than the allowed speed of ${limit} - ${status}`;
    } else{
        message = `Driving ${speed} km/h in a ${limit} zone`
    }

    console.log(message);
}

radar(40, 'city');
radar(21, 'residential');
radar(120, 'interstate');
radar(200, 'motorway');