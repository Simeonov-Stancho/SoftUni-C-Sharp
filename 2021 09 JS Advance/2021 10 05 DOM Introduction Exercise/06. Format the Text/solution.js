function solve() {
  let input = document.getElementById('input').value;
  let output = document.getElementById('output');

  let textSentences = input.split('.');
  textSentences.pop();

  while (textSentences.length != 0) {
    let pText = textSentences.splice(0, 3).join('.') + '.';
    let newParagraph = document.createElement('p');
    newParagraph.textContent = pText;
    output.appendChild(newParagraph);
  }
}