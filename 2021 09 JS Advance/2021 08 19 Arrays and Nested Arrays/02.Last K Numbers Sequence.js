function solve (n, k){
    let outputArr = [1];
    while(outputArr.length < n){
        let currentNum = 0;

        for(let j = outputArr.length - 1; j >= outputArr.length - k; j--) {
            if(outputArr.length > j && j >=0 ){
            currentNum += outputArr[j];
            }
        }

        outputArr.push(currentNum);
    }

    return outputArr;
}

console.log(solve(8, 0));