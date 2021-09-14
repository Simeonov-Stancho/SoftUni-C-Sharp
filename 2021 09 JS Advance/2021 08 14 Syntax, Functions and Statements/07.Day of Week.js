function dayOfWeek(day){
    let result = 'error';
        if(day=="Monday"){
            result = 1;
        }
        if(day=="Tuesday"){
            result = 2;
        }
        if(day=="Wednesday"){
                result = 3;
        }
        if(day=="Thursday"){
            result = 4;
        }
        if(day=="Friday"){
            result = 5;
        }
        if(day=="Saturday"){
            result = 6;
        }
        if(day=="Sunday"){
            result = 7;
        }
        console.log(result);
    }

    dayOfWeek("8")