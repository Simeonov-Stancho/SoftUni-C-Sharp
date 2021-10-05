function colorize() {
    const rows = Array.from(document.querySelectorAll('table tr:nth-child(even)'));
    rows.map(row => row.style.backgroundColor = 'teal');
}

function colorize() {
    const rows = Array.from(document.querySelectorAll('table tr'));

    for (let i = 1; i < rows.length; i += 2) {
        rows[i].style.backgroundColor = 'teal';
    }
}
