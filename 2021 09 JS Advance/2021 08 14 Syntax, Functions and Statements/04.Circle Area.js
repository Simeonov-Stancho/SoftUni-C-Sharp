function circleArea(input){
    let typeInput = typeof(input);

    if(typeInput == "number"){
        let circleArea = Math.PI * input * input;
        console.log(circleArea.toFixed(2));
    }else{
        console.log(`We can not calculate the circle area, because we receive a ${typeInput}.`);
    }
}

circleArea(5);