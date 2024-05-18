
document.querySelector('.dropdown-toggle').addEventListener('click', function (event) {
    event.stopPropagation(); 
    document.querySelector('.dropdown-menu').classList.toggle('show');
});


