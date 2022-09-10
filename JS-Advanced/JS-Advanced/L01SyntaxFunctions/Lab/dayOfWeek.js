function day(day){
    let dayNumber;

    if(day == 'Monday'){
        dayNumber = 1;
    } else if(day == 'Tuesday'){
        dayNumber = 2;
    } else if(day == 'Wednesday'){
        dayNumber = 3;
    } else if(day == 'Thursday'){
        dayNumber = 4;
    } else if(day == 'Friday'){
        dayNumber = 5;
    } else if(day == 'Saturday'){
        dayNumber = 6;
    } else if(day == 'Sunday'){
        dayNumber = 7;
    } else{
        dayNumber = 'error';
    }

    console.log(dayNumber);
}

day('Monday');
day('Sunday');
day('asdad');