function squareOfStars(input){

    for(let i=1; i<= input; i++){

        let square= "";
        for(let z=1; z<=input; z++){
            square += '* ';
        }
        console.log(square);
    }
}

squareOfStars(4);