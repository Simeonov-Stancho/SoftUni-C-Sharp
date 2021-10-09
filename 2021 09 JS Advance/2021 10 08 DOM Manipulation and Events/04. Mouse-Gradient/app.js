function attachGradientEvents() {
    const result = document.getElementById('result');
    const hoverEl = document.getElementById('gradient');
    hoverEl.addEventListener('mousemove', onMove);

    function onMove(event) {
        const box = event.target;
        let percent = Math.floor(event.offsetX / box.clientWidth * 100);
        result.textContent = `${percent}%`;
    }
}