// Função para mostrar os detalhes do workshop
function mostrarDetalhes(workshopId) {
    // Esconde todos os detalhes dos workshops
    var workshops = document.querySelectorAll('.detalhes');
    workshops.forEach(function(workshop) {
        workshop.style.display = 'none';
    });

    // Exibe o workshop clicado
    var workshopDetalhes = document.getElementById(workshopId);
    workshopDetalhes.style.display = 'block';
}
