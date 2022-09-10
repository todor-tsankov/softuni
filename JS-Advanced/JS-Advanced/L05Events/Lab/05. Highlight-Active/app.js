function focus() {
    Array.from(document.querySelectorAll('div div')).forEach(x => {
        x.children[1].addEventListener('focus', onFocus);
        x.children[1].addEventListener('blur', onBlur);
    });

    function onFocus(event){
        event.target.parentElement.className = 'focused';
    }

    function onBlur(event){
        event.target.parentElement.className = '';
    }
}