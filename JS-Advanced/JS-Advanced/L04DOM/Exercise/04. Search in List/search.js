function search() {
    let searchItem = document.getElementById('searchText').value;
    let listItems = document.getElementById('towns').children;

    let result = 0;

    for (let x = 0; x < listItems.length; x++){
        let listItem = listItems[x];

        if (listItem.textContent.includes(searchItem)){
            result++;
            listItem.setAttribute('style', 'font-weight: bold; text-decoration: underline;');
        }
        else{
            listItem.style.textDecoration  = '';
            listItem.removeAttribute('style');
        }
    }

    document.getElementById('result').textContent = `${result} matches found`;
}
