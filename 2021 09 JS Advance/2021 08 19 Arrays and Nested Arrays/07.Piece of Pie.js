function solve(piesArr, startingFlovor, endingFlover) {

    const startIndex = piesArr.indexOf(startingFlovor);
    const endIndex = piesArr.indexOf(endingFlover);

    const output = piesArr.slice(startIndex, endIndex +1);

    return output;
}

console.log(solve(['Pumpkin Pie', 'Key Lime Pie', 'Cherry Pie', 'Lemon Pie', 'Sugar Cream Pie'], 'Key Lime Pie', 'Lemon Pie'))