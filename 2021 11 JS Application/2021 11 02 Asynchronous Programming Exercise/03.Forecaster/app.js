function attachEvents() {
    const submitBtn = document.getElementById('submit');
    submitBtn.addEventListener('click', submit);
}

attachEvents();

async function submit() {
    removeErrorMsg();
    const url = `http://localhost:3030/jsonstore/forecaster/locations`;
    const response = await fetch(url);
    const data = await response.json();

    const location = document.getElementById('location').value;

    try {
        const code = data.filter(l => l.name == location)[0].code;

        const todayForecasterUrl = `http://localhost:3030/jsonstore/forecaster/today/${code}`;
        const upcomingForecasterUrl = `http://localhost:3030/jsonstore/forecaster/upcoming/${code}`;

        const [todayForecaster, upcomingForecaster] = await Promise.all([
            getData(todayForecasterUrl),
            getData(upcomingForecasterUrl)
        ]);

        const todayCondition = todayForecaster.forecast.condition;
        let todayConditionSymbol = getConditionSymbol(todayCondition);

        const upcomingCondition = upcomingForecaster.forecast;

        const city = todayForecaster.name;
        const todayLowT = todayForecaster.forecast.low;
        const todayHighT = todayForecaster.forecast.high;

        const forecast = document.getElementById('forecast');
        forecast.style.display = 'block';

        const currentForecast = document.getElementById('current');
        currentForecast.innerHTML = `<div class="label">Current conditions</div><div class="forecasts"><span class="condition symbol">${todayConditionSymbol}</span><span class="condition"><span class="forecast-data">${city}</span><span class="forecast-data">${todayLowT}${'&#176'}/${todayHighT}${'&#176'}</span><span class="forecast-data">${todayCondition}</span></span></div></div>`;

        const upcomingForecast = document.getElementById('upcoming');

        let elRemove = document.querySelectorAll('div[class="forecast-info"]')
        if (elRemove.length == 0) {
            let divEl = document.createElement('div');
            divEl.classList.add('forecast-info');
            upcomingForecast.appendChild(divEl);

            upcomingCondition.forEach(c => {
                const spanEl = document.createElement('span');
                spanEl.classList.add('upcoming');
                spanEl.innerHTML = `<span class"symbol">${getConditionSymbol(c.condition)}</span><span class="forecast-data">${c.low}${'&#176'}/${c.high}${'&#176'}</span><span class="forecast-data">${c.condition}</span>`;
                divEl.appendChild(spanEl);
            })
        }
    } catch (error) {
        const forecast = document.getElementById('forecast');
        forecast.style.display = 'none';
        let bodyEl = document.querySelector('body');
        let divEl = document.createElement('div');
        divEl.classList.add('error')
        divEl.textContent = 'There is no data for this location or invalid location. Please enter new location.';
        bodyEl.appendChild(divEl);
    }
}

async function getData(url) {
    const response = await fetch(url);
    const data = await response.json();

    return data;
}

function getConditionSymbol(condition) {
    if (condition == 'Sunny') {
        conditionSymbol = '&#x2600';
    } else if (condition == 'Partly sunny') {
        conditionSymbol = '&#x26C5';
    } else if (condition == 'Overcast') {
        conditionSymbol = '&#x2601';
    } else if (condition == 'Rain') {
        conditionSymbol = '&#x2614';
    } else if (condition == 'Degrees') {
        conditionSymbol = '&#&#176';
    }

    return conditionSymbol;
}

function removeErrorMsg() {
    let errorEl = document.querySelector('div[class="error"]');
    if (errorEl != null) {
        errorEl.parentElement.removeChild(errorEl.parentElement.lastChild);
    }
}