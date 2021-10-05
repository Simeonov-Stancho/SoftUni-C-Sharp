function editElement(reference, match, replacer) {
    const referenceText = reference.textContent;
    //const result = referenceText.replaceAll(match, replacer); not work in Judge
    const result = referenceText.split(match).join(replacer);

    reference.textContent = result;
}

function editElement(reference, match, replacer) {
    const referenceText = reference.textContent;
    const matcher = new RegExp(match, 'g');
    const result = referenceText.replace(matcher, replacer);
    
    reference.textContent = result;
}  