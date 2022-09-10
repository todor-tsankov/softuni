function attachEventsListeners() {
    document.getElementById('daysBtn').addEventListener('click', onDays);
    document.getElementById('hoursBtn').addEventListener('click', onHours);
    document.getElementById('minutesBtn').addEventListener('click', onMinutes);
    document.getElementById('secondsBtn').addEventListener('click', onSeconds);

    let days = document.getElementById('days');
    let hours = document.getElementById('hours');
    let minutes = document.getElementById('minutes');
    let seconds = document.getElementById('seconds');

    function onDays(){
        hours.value = days.value * 24;
        minutes.value = hours.value * 60;
        seconds.value = minutes.value * 60;
    }

    function onHours(){
        days.value = hours.value / 24;
        minutes.value = hours.value * 60;
        seconds.value = minutes.value * 60;
    }

    function onMinutes(){
        seconds.value = minutes.value * 60;
        hours.value = minutes.value / 60;
        days.value = hours.value / 24;
    }

    function onSeconds(){
        minutes.value = seconds.value / 60;
        hours.value = minutes.value / 60;
        days.value = hours.value / 24;
    }
}
