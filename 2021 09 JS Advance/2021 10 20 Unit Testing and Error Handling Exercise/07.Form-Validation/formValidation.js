function validate() {
    const html = {
        isCompanyCheck: document.getElementById(`company`),
        submit: document.getElementById(`submit`),
        validDiv: document.getElementById(`valid`),
        companyInfo: document.getElementById(`companyInfo`)
    }

    const inputFields = {
        username: document.getElementById(`username`),
        email: document.getElementById(`email`),
        password: document.getElementById(`password`),
        'confirm-password': document.getElementById(`confirm-password`),
        companyNumber: document.getElementById(`companyNumber`),

    }

    const checkLength = (input, minLength, maxLength) => input.length >= minLength && input.length <= maxLength
    const checkPassword = (input, minLength, maxLength, currentField) =>
        checkLength(input, minLength, maxLength) && /^\w+$/g.test(input) && input === inputFields[currentField].value

    const validate = {
        username: (input) => checkLength(input, 3, 20) && /^[a-zA-Z0-9]*$/g.test(input),
        password: (input) => checkPassword(input, 5, 15, 'confirm-password'),
        'confirm-password': (input) => checkPassword(input, 5, 15, 'password'),
        email: (input) => /^.*@.*\..*$/g.test(input),
        companyNumber: (input, isChecked) => isChecked ? input >= 1000 && input <= 9999 : true
    }

    const changeBorder = (isChecked, e) => {
        const style = isChecked ? 'border: none' : 'border-color: red'

        e.style = style
    }

    html.isCompanyCheck.addEventListener('change', (event) => {
        if (event.target.checked === true) {
            html.companyInfo.style.display = 'block'
        } else {
            html.companyInfo.style.display = 'none'
        }
    })

    html.submit.addEventListener('click', (ev) => {
        ev.preventDefault()
        const checked = html.isCompanyCheck.checked
        let oneInvalid = false

        Object.entries(inputFields).forEach(([name, valueField]) => {
            const valid = validate[name](valueField.value, checked)

            changeBorder(valid, inputFields[name])

            if (!valid) oneInvalid = true
        })

        if (oneInvalid) {
            html.validDiv.style.display = 'none'
        } else {
            html.validDiv.style.display = 'block'
        }
    });
}