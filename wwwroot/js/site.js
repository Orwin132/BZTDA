window.addEventListener('load', () => {
    let mask = document.querySelector('.mask');
    if (typeof maskLoader === 'undefined') {
        mask.classList.add('hide');
        setTimeout(() => {
            mask.remove();
        }, 600);
    }
});
