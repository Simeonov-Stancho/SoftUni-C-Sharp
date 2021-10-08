// function search() {
//    let towns = Array.from(document.getElementById('towns').children);
//    let searchText = document.getElementById('searchText').value;

//    let count = 0;
//    for (let i = 0; i < towns.length; i++) {
//       if (towns[i].textContent.includes(searchText)) {
//          towns[i].style.textDecoration = "underline"
//          towns[i].style.fontWeight = "bold"
//          count++;
//       }
//    }
//    document.getElementById('result').textContent = `${count} matches found`;
// }

//with object
function search() {
   const html = {
      searchText: document.getElementById('searchText').value,
      towns: Array.from(document.getElementById('towns').children),
   }

   let count = 0;
   html.towns.map(town => {
      if (town.textContent.includes(html.searchText)) {
         town.style.textDecoration = "underline";
         town.style.fontWeight = 'bold';
         count++;
      }
      return town;
   })

   document.getElementById('result').textContent = `${count} matches found`;
}
