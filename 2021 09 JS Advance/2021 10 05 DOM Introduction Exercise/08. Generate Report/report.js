function generateReport() {
    let table = Array.from(document.getElementsByTagName('input'));

    const outputTable = [];
    const tableRows = Array.from(document.getElementsByTagName('tr'));
    const checkedColumnsIndex = [];

    for (let i = 0; i < tableRows.length; i++) {
        const currentRow = tableRows[i];
        let currentRowObj = {};

        for (let x = 0; x < currentRow.children.length; x++) {
            const currentValue = currentRow.children[x];

            //find checked columns
            if (i == 0) {
                if (currentValue.children[0].checked) {
                    checkedColumnsIndex.push(x);
                }
                continue;
            }

            if (checkedColumnsIndex.includes(x)) {
                let tableHeadName = table[x].name;
                currentRowObj[tableHeadName] = currentValue.textContent;
            }
        }
        if (i > 0) {
            outputTable.push(currentRowObj);
        }
    }

    document.getElementById('output').value = JSON.stringify(outputTable);
}