function time(steps, footprint, speedKmH){
    let speedMH = speedKmH * 1000;
    let speedMM = speedMH / 60;
    let speedMS = speedMM / 60;

    let distanceM = steps * footprint;
    
    let hours = Math.floor(distanceM / speedMH);
    distanceM -= hours * speedMH;
    
    let restTime = Math.floor(distanceM / 500);

    let minutes = Math.floor(distanceM / speedMM);
    distanceM -= minutes * speedMM;
    minutes += restTime;

    if(minutes > 60){
        hours += minutes % 60;
        minutes %= 60;
    }

    let seconds = Math.round(distanceM / speedMS);

    let hoursStr = String(hours).padStart(2, '0');
    let minutesStr = String(minutes).padStart(2, '0');
    let secondsStr = String(seconds).padStart(2, '0');

    console.log(`${hoursStr}:${minutesStr}:${secondsStr}`)
}

time(4000, 0.60, 5);
time(2564, 0.70, 5.5);