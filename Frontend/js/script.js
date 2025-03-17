function mostrarDetalhes(workshopId) {
    var workshops = document.querySelectorAll('.detalhes');
    workshops.forEach(function(workshop) {
        workshop.style.display = 'none';
    });

    var workshopDetalhes = document.getElementById(workshopId);
    workshopDetalhes.style.display = 'block';
}
