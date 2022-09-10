function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      const search = document.getElementById('searchField').value.toLowerCase();
      const items = document.querySelectorAll('tbody tr td');

      for (let x= 0; x < items.length; x++){
         items[x].parentElement.className = '';
      }

      for (let x= 0; x < items.length; x++){
         let item = items[x];

         if (item.textContent.toLowerCase().includes(search)){
            item.parentElement.className = 'select';
         }
      }
   }
}