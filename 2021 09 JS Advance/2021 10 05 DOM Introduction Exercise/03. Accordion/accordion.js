// function toggle() {
//     let button = document.getElementsByClassName('button')[0];

//     if (button.textContent == "More") {
//         document.getElementById('extra').style.display = 'block';
//         button.textContent = "Less";
//     } else {
//         button.textContent = "More";
//         document.getElementById('extra').style.display = 'none';
//     }
// }

function toggle() {
    let button = {
        currentButton: document.getElementsByClassName('button')[0],
        content: document.getElementById('extra'),
    }
   
    if (button.currentButton.textContent == "More") {
        button.currentButton.textContent = "Less";
        button.content.style.display = "block"
    } else {
        button.currentButton.textContent = "More";
        button.content.style.display = "none"
    }
}