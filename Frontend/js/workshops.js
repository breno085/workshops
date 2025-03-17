function mostrarDetalhes(workshopId) {
    // Esconde todos os workshops
    const workshops = document.querySelectorAll('.detalhes');
    workshops.forEach(workshop => workshop.style.display = 'none');

    // Mostra o workshop selecionado
    const workshopSelecionado = document.getElementById(workshopId);
    if (workshopSelecionado) {
        workshopSelecionado.style.display = 'block';
    }
}

// Dados para o gráfico de pizza
const data = {
    labels: ['Web Design', 'Desenvolvimento Mobile', 'Marketing Digital', 'Desenvolvimento Web', 'Métodos Ágeis', 'DevOps', 'Banco de Dados SQL', 'Machine Learning'],
    datasets: [{
        label: 'Colaboradores',
        data: [6, 6, 7, 8, 9, 7, 7, 9], // Quantidade de colaboradores em cada workshop
        backgroundColor: [
            '#ff9999', '#66b3ff', '#99ff99', '#ffcc99', '#c2c2f0', '#ffb3e6', '#c2f0c2', '#ffb366'
        ],
        borderColor: '#fff',
        borderWidth: 1
    }]
};

// Configuração do gráfico de pizza
const config = {
    type: 'pie',
    data: data,
    options: {
        responsive: true,
        plugins: {
            legend: {
                position: 'top',
            },
            tooltip: {
                callbacks: {
                    label: function(tooltipItem) {
                        return tooltipItem.label + ': ' + tooltipItem.raw + ' colaboradores';
                    }
                }
            }
        }
    }
};

// Criar o gráfico
const ctx = document.getElementById('pieChart').getContext('2d');
new Chart(ctx, config);