function notify(message) {

  let textDiv = document.getElementById('notification');
  textDiv.textContent = message;
  textDiv.style.display = 'block';

  textDiv.addEventListener('click', hideMessage);

  function hideMessage(event) {
    event.target.style.display = 'none';
  }
}