function lockedProfile() {
    let buttons = document.querySelectorAll('div[class="profile"] button');

    for(let x = 0; x < buttons.length; x++){
        buttons[x].addEventListener('click', onClick);
    }

    function onClick(event){
        let parent = event.target.parentElement;

        if (!parent.children[2].checked && parent.children[4].checked){
            let hiddenElement = parent.querySelector('div');
            let button = parent.querySelector('button');

            if (hiddenElement.style.display === ''){
                hiddenElement.style.display = 'inline';
                button.textContent = 'Hide it';
            }
            else{
                hiddenElement.style.display = '';
                button.textContent = 'Show more';
            }
        }
    }
}