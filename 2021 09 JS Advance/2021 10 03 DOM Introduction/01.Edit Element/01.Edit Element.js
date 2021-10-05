function editElement(reference, match, replacer) {
    const referenceText = reference.textContent;
    const result = referenceText.replaceAll(match, replacer);
    //const result = referenceText.split(match).join(replacer);
    reference.textContent = result;
}