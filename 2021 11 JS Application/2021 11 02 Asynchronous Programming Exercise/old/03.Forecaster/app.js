function attachEvents() {
    let location = document.getElementById('location');
    let submitBtn = document.getElementById('submit');
    let todayForecastElement = document.getElementById('current');
    let toDisplayElement = document.getElementById('forecast');
    let upcomingDaysElement = document.getElementById('upcoming');

    submitBtn.addEventListener('click',function (){
        fetch('http://localhost:3030/jsonstore/forecaster/locations')
        .then(res=>res.json())
        .then(data=>{
            console.log(data);
            let currCity = data.find(x=>x.name === location.value);
            let currCityCode = currCity.code;
            console.log(currCityCode);
            location.value = '';
            fetch(`http://localhost:3030/jsonstore/forecaster/today/${currCityCode}`)
            .then(res=>res.json())
            .then(cityData=>{
               
                let condition = cityData.forecast.condition;
                let high = cityData.forecast.high;
                let low = cityData.forecast.low;
                let cityName = cityData.name;
                let dataToAppend = createToday(condition,high,low,cityName);
                let divElement = document.createElement('div');
                divElement.classList.add('forecasts');
                divElement.innerHTML = dataToAppend;
                if(todayForecastElement.children.length === 2){
                    todayForecastElement.lastChild.remove();
                }

                todayForecastElement.appendChild(divElement);
                toDisplayElement.style.display = 'block';

            })
            
                
            let nextThreeDays = '';

            fetch(`http://localhost:3030/jsonstore/forecaster/upcoming/${currCityCode}`)
            .then(res=>res.json())
            .then(upcomingData=>{
                console.log(upcomingData);
                upcomingData.forecast.forEach(x => {
                     
                let condition = x.condition;
                let high = x.high;
                let low = x.low;
                nextThreeDays += createNextThreeDays(condition,high,low);
                let divElement = document.createElement('div');
                divElement.classList.add('forecast-info');
                divElement.innerHTML = nextThreeDays;
                if(upcomingDaysElement.children.length === 2){
                    upcomingDaysElement.lastChild.remove();
                }
                upcomingDaysElement.appendChild(divElement);
                upcomingDaysElement.style.display = 'block';

                 });

            })

             
        })
        .catch(err=>{
            if(err){
                if(todayForecastElement.children.length === 2){
                    todayForecastElement.lastChild.remove();
                }
                let divElement = document.createElement('div');
                divElement.classList.add('forecasts');
                divElement.innerHTML = 'Error';
                todayForecastElement.appendChild(divElement);
                toDisplayElement.style.display = 'block';

                if(upcomingDaysElement.children.length === 2){
                    upcomingDaysElement.lastChild.remove();
                }
                let divElementNext = document.createElement('div');
                divElementNext.classList.add('forecast-info');
                divElementNext.innerHTML = 'Error';
                upcomingDaysElement.appendChild(divElementNext);
                upcomingDaysElement.style.display = 'block';
                
                location.value = '';
                
            }
        })
        
        
        

    

    })
    
    function createToday(condition,high,low,cityName){
        let symbol = checkCondition(condition);
        let currentTemplate = `
        <span class='condition symbol'>${symbol}</span>
        <span class= 'condition'>
            <span class = 'forecast-data'>${cityName}</span>
            <span class = 'forecast-data'>${low}${'&#176'}/${high}${'&#176'}</span>
            <span class = 'forecast-data'>${condition}</span>
        </span>
        `;
        return currentTemplate;

    }

    function createNextThreeDays(condition,high,low){
        let symbol = checkCondition(condition);
        let currentTemplate = `
        <span class='upcoming'>
            <span class= 'symbol'>${symbol}</span>
            <span class = 'forecast-data'>${low}${'&#176'}/${high}${'&#176'}</span>
            <span class = 'forecast-data'>${condition}</span>
        </span>
        `;
        return currentTemplate;

    }

    function checkCondition(condition){
        let currCond = '';
        if(condition === 'Sunny'){
            currCond ='&#x2600';
        }else if(condition === 'Partly sunny'){
            currCond === '&#x26C5';
        }else if(condition=== 'Overcast'){
            currCond = '&#x2601';
        }else{
            currCond = '&#x2614'
        }
        return currCond;
    }

    
}

attachEvents();