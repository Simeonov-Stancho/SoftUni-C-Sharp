window.addEventListener('load', solution);

function solution() {
  let fullName = document.getElementById('fname');
  let email = document.getElementById('email');
  let phone = document.getElementById('phone');
  let address = document.getElementById('address');
  let code = document.getElementById('code');

  //console.log(fullName.value, email.value, phone.value, address.value, code.value);

  const submitBtn = document.getElementById('submitBTN');
  submitBtn.addEventListener('click', submitReservation);

  let previewEl = document.getElementById('infoPreview');

  let editBtn = document.getElementById('editBTN');
  let continueBtn = document.getElementById('continueBTN');

  let divBlock = document.getElementById('block')

  let reservation = {
    fullName,
    email,
    phone,
    address,
    code,
  };

  let info = []

  function submitReservation(event) {
    event.preventDefault();

    if (fullName.value == '' || email.value == '') {
      return;
    }

    reservation = {
      fullName: fullName.value,
      email: email.value,
      phone: phone.value,
      address: address.value,
      code:code.value,
    };

    info.push(fullName.value,email.value, phone.value, address.value, code.value)
    
    submitBtn.disabled = true;
    editBtn.disabled = false;
    continueBtn.disabled = false;

    previewEl.innerHTML = `<li>Full Name: ${fullName.value}</li><li>Email: ${email.value}</li><li>Phone Number: ${phone.value}</li><li>Address: ${address.value}</li><li>Postal Code: ${code.value}</li>`;
    //console.log(previewEl);

    editBtn.addEventListener('click', editAggain);
    continueBtn.addEventListener('click', completeReservation);

    fullName.value = '';
    email.value = '';
    phone.value = '';
    address.value = '';
    code.value = '';
  }

  function editAggain(e) {
    submitBtn.disabled = false;
    editBtn.disabled = true;
    continueBtn.disabled = true;

    // fullName.value = previewEl.children[0].textContent.split(': ')[1];
    // email.value = previewEl.children[1].textContent.split(': ')[1];
    // phone.value = previewEl.children[2].textContent.split(': ')[1];
    // address.value = previewEl.children[3].textContent.split(': ')[1];
    // code.value = previewEl.children[4].textContent.split(': ')[1];

    // fullName.value = reservation.fullName;
    // email.value = reservation.email;
    // phone.value = reservation.phone;
    // address.value = reservation.address;
    // code.value = reservation.code;

    fullName.value = info[0];
    email.value = info[1];
    phone.value = info[2];
    address.value = info[3];
    code.value = info[4];

    previewEl.innerHTML = '';
  }

  function completeReservation(ev) {
    divBlock.innerHTML = `<h3>Thank you for your reservation!</h3>`
  }
}
