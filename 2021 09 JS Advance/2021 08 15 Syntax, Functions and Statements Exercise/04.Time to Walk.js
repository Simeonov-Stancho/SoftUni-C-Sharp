function timeToWalk(steps, length, speed){
    let distance = steps * length / 1000;   // km
    let time = distance / speed * 3600; //sec
    let breaksTime = Math.floor(distance * 1000 / 500); // min

    let seconds = Math.round(time % 60).toFixed(0).padStart(2, '0');
    
    let minutes = Math.floor(((time / 60) + breaksTime) % 60).toFixed(0).padStart(2, '0');
    
    let hours = Math.floor(time / 3600).toFixed(0).padStart(2, '0');
    
    console.log(`${hours}:${minutes}:${seconds}`);
}

timeToWalk(402109, 0.6, 5);