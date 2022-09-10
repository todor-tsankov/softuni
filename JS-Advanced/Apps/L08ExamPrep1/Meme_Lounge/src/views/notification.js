export default function show(message){
    const box = document.getElementById('errorBox');
    box.innerHTML = `<span>${message}</span>`;
    box.style.display = 'inline';

    setTimeout(() => {
        box.style.display = 'none';
    }, 3000);
}