function convertToUppercase(words) {
    return words.match(/\w+/g).join(", ").toLocaleUpperCase()
}

console.log(convertToUppercase('Hi, how! are you?'));
console.log(convertToUppercase('Functions in JS can be nested, i.e. hold other functions'));