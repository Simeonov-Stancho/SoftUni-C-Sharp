// with regex
function extract(content) {
    let text = document.getElementById(content).textContent;
    let result = text.match(/\(.*?\)/g)
        .map(x => x.replace(/[()]/g, ""));;

    return result.join("; ");
}

//with for
function extract(content) {
    let text = document.getElementById(content).textContent;
    var newTxt = text.split('(');
    let result = [];
    console.log(newTxt);
    for (var i = 1; i < newTxt.length; i++) {
        result.push(newTxt[i].split(')')[0]);
    }

    return result.join("; ");
}