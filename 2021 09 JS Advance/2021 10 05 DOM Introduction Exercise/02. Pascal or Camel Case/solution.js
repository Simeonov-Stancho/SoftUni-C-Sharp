function solve() {
  let text = document.getElementById("text").value;
  let namingConvention = document.getElementById("naming-convention").value;

  let resultArray = text.toLowerCase().split(" ");
  let result = "";
  let currentWord = "";
  while (resultArray.length != 0) {
    currentWord = resultArray.shift();
    result += (currentWord[0].toUpperCase() + currentWord.slice(1));
  }

  if (namingConvention != "Camel Case" && namingConvention != "Pascal Case") {
    result = "Error!";
  } else {
    result = namingConvention == "Pascal Case" ? result :
      `${result.charAt(0).toLowerCase()}${result.slice(1)}`
  }

  document.getElementById("result").textContent = result;
}

//with obj
function solve() {
  const data = {
    case: document.getElementById("naming-convention").value,
    text: document.getElementById("text").value,
    resultSpan: document.getElementById("result"),
  }
  const result = data.text
    .split(" ")
    .map(x => x.toLowerCase())
    .map(x => `${x[0].toUpperCase()}${x.slice(1)}`)
    .join("")

  if (data.case !== "Camel Case" && data.case !== "Pascal Case") {
    data.resultSpan.textContent = "Error!"
  } else {
    data.resultSpan.textContent =
      data.case === "Pascal Case"
        ? result
        : `${result.charAt(0).toLowerCase()}${result.slice(1)}`
  }
}