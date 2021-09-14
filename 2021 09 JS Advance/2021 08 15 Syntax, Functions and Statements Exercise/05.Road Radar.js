function roadRadar(speed, area){
    let speedLimit = 0;
    let message = '';
    if(area == 'motorway'){
        speedLimit = 130;
    }

    else if(area == 'interstate'){
        speedLimit = 90;
    }

    else if(area == 'city'){
        speedLimit = 50;
    }

    else if(area == 'residential'){
        speedLimit = 20;
    }

    if(speedLimit + 40 < speed){
        message = `The speed is ${speed - speedLimit} km/h faster than the allowed speed of ${speedLimit} - reckless driving`;
    }

    else if(speedLimit + 20 < speed){
        message = `The speed is ${speed - speedLimit} km/h faster than the allowed speed of ${speedLimit} - excessive speeding`;
    }

    else if(speedLimit < speed){
        message =  `The speed is ${speed - speedLimit} km/h faster than the allowed speed of ${speedLimit} - speeding`;
    }

    else if(speedLimit >= speed){
        message = `Driving ${speed} km/h in a ${speedLimit} zone`;
    }

    console.log(message);
}

roadRadar(200, 'motorway')