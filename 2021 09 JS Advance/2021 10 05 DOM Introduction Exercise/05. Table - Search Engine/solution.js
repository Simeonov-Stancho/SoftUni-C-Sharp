function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      let searchText = document.getElementById('searchField').value;
      let tableRows = Array.from(document.querySelectorAll('body table tbody tr'));
      console.log(tableRows);

      tableRows.forEach(row => {
         if (row.textContent.includes(searchText)) {
            row.classList.add('select');        //select row
         } else {
            row.classList.remove('select');     //unselect row
         }
      });
      searchText = '';
   }
}

//with obj
// function solve() {
//    const data = {
//        collection: document.getElementsByTagName("tr"),
//        getValue: () => document.getElementById("searchField").value,
//    }

//    function onClick({ collection, value }) {
//        collection.map(x => (x.className = ""))
//        collection.map(x => {
//            if (x.innerHTML.includes(value)) x.className = "select"

//            return x
//        })
//    }

//    document.getElementById("searchBtn").addEventListener("click", () =>
//        onClick({
//            collection: Array.from(data.collection),
//            value: data.getValue(),
//        })
//    )
// }
