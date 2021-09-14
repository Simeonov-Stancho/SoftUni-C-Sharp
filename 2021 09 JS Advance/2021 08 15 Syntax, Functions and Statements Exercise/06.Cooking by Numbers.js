function cookingByNUmbers(startingPoint, operation1, operation2, operation3, operation4, operation5){
    let points = Number(startingPoint);
   
    function cooking(points, operation){
    
        if(operation == "chop"){
            points = points / 2;
        }
     
        else if(operation == "dice"){
            points = Math.sqrt(points);
        }
     
        else if(operation == "spice"){
         points += 1;
         }
     
         else if(operation == "bake"){
             points *= 3;
         }
     
         else if(operation == "fillet"){
             points *= 0.80;
         }
     
         return points;
     }

    points = cooking(points, operation1);
    console.log(points);
    points = cooking(points, operation2);
    console.log(points);
    points = cooking(points, operation3);
    console.log(points);
    points = cooking(points, operation4);
    console.log(points);
    points = cooking(points, operation5);
    console.log(points);
}

cookingByNUmbers('9', 'dice', 'spice', 'chop', 'bake', 'fillet');