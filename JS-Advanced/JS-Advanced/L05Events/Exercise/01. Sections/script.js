function create(words) {
   let contentDiv = document.getElementById('content');

   words.forEach(w => {
      let div = document.createElement('div');
      let paragraph = document.createElement('p');

      paragraph.textContent = w;
      paragraph.style.display = 'none';

      div.appendChild(paragraph);
      div.addEventListener('click', onClick);

      contentDiv.appendChild(div);
   });

   function onClick(event){
      if (event.target.nodeName === 'DIV'){
         event.target.children[0].style.display = 'block';
      }
   }
}