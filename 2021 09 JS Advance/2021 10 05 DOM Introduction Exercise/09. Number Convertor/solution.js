function solve() {
    const html = {
        input: document.getElementById("input"),
        convertTo: document.getElementById("selectMenuTo"),
        output: document.getElementById("result"),
        button: document.querySelector("#container > button"),
    };

    const makeOptions = arr =>
        arr.map(x => {
            const option = document.createElement("option")
            x = x.toLowerCase()
            option.value = x
            option.text = `${x.charAt(0).toUpperCase()}${x.slice(1)}`
            return option
        });

    const print = n => (html.output.value = n);
    makeOptions(["binary", "hexadecimal"]).forEach(x => html.convertTo.add(x));

    function convert(to, n) {
        n = Number(n) || 0
        const formats = {
            binary: n => (n >>> 0).toString(2),
            hexadecimal: n => n.toString(16).toLocaleUpperCase(),
        }

        return formats[to](n)
    };

    html.button.addEventListener("click", () =>
        print(convert(html.convertTo.value, html.input.value))
    );
}