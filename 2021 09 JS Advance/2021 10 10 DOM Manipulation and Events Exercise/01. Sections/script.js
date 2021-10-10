function create(words) {
   const content = document.getElementById('content');

   for (let i = 0; i < words.length; i++) {
      const div = document.createElement('div');
      const p = document.createElement('p');
      p.textContent = words[i];
      p.style.display = 'none';
      div.appendChild(p);
      div.addEventListener('click', onClick);

      content.appendChild(div);
   }
   
   function onClick(event) {
      console.log(event.target)
      event.currentTarget.children[0].style.display = 'block';
   }
}