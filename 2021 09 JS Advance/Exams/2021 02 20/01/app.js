function solve() {
   let author = document.getElementById('creator');
   let title = document.getElementById('title');
   let category = document.getElementById('category');
   let content = document.getElementById('content');

   let createBtn = document.getElementsByClassName('btn create')[0];
   createBtn.addEventListener('click', createPost);

   let sectionEl = document.getElementsByTagName("section")[1];

   let olEl = document.getElementsByTagName("ol")[0];

   function createPost(event) {
      event.preventDefault();

      let articleEl = document.createElement('article');
      articleEl.innerHTML = `<h1>${title.value}</h1><p>Category:<strong>${category.value}</strong></p><p>Creator:<strong>${author.value}</strong></p><p>${content.value}</p><div class="buttons"><button class="btn delete">Delete</button><button class="btn archive">Archive</button></div>`;
      sectionEl.appendChild(articleEl);

      let deleteBtn = articleEl.querySelectorAll('button')[0];
      let archiveBtn = articleEl.querySelectorAll('button')[1];

      deleteBtn.addEventListener('click', () => {
         sectionEl.removeChild(articleEl);
      });
      archiveBtn.addEventListener('click', () => {
         let liEl = document.createElement('li');
         liEl.textContent = articleEl.children[0].textContent
         olEl.appendChild(liEl);
         sectionEl.removeChild(articleEl);

         Array.from(olEl.children)
            .sort((a, b) => a.textContent.localeCompare(b.textContent.toLowerCase()))
            .forEach(element => olEl.appendChild(element));
      });

      author.value = '';
      title.value = '';
      category.value = '';
      content.value = '';
   } 
}