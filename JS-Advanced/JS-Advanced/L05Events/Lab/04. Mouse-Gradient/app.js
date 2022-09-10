function attachGradientEvents() {
    let gradientBox = document.getElementById('gradient');
    gradientBox.addEventListener('mousemove', onMove)

    function onMove(event) {
        let percent = Math.floor(event.offsetX / gradientBox.clientWidth * 100);
        document.getElementById('result').textContent = percent + '%';
    }
}