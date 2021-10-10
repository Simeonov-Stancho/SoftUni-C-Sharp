function attachEventsListeners() {
    const retios = {
        days: 1,
        hours: 24,
        minutes: 1440,
        seconds: 86400
    }

    function convert(value, unit) {
        const inDays = value / retios[unit];
        return {
            days: inDays,
            hours: inDays * 24,
            minutes: inDays * 1440,
            seconds: inDays * 86400
        }
    }
    const days = document.getElementById('days');
    const hours = document.getElementById('hours');
    const minutes = document.getElementById('minutes');
    const seconds = document.getElementById('seconds');
    const mainTag = document.querySelector('main');
    
    mainTag.addEventListener('click', onClick)

    function onClick(event) {
        const array = [Number(days.value), Number(hours.value), Number(minutes.value), Number(seconds.value)];
        const eventType = event.target.type;

        if (eventType == 'button') {
            const value = Math.max(...array);
            let index = array.indexOf(Math.max(...array));
            const unit = event.target.parentElement.parentElement.children[index + 1].children[1].id;
            
            const currentTime = convert(value, unit);

            days.value = currentTime.days;
            hours.value = currentTime.hours;
            minutes.value = currentTime.minutes;
            seconds.value = currentTime.seconds;
        }
    }
}

// function attachEventsListeners() {
//     const daysBtn = document.getElementById('daysBtn');
//     const hoursBtn = document.getElementById('hoursBtn');
//     const minutesBtn = document.getElementById('minutesBtn');
//     const secondsBtn = document.getElementById('secondsBtn');

//     const days = document.getElementById('days');
//     const hours = document.getElementById('hours');
//     const minutes = document.getElementById('minutes');
//     const seconds = document.getElementById('seconds');

//     daysBtn.addEventListener('click', () => {
//         hours.value = days.value * 24;
//         minutes.value = hours.value * 60;
//         seconds.value = minutes.value * 60;
//     });

//     hoursBtn.addEventListener('click', () => {
//         days.value = hours.value / 24;
//         minutes.value = hours.value * 60;
//         seconds.value = minutes.value * 60;
//     });

//     minutesBtn.addEventListener('click', () => {
//         seconds.value = minutes.value * 60;
//         hours.value = minutes.value / 60;
//         days.value = minutes.value / 24;
//     });

//     secondsBtn.addEventListener('click', () => {
//         minutes.value = seconds.value / 60;
//         hours.value = minutes.value / 60;
//         days.value = hours.value / 24;
//     });
// }