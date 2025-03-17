 // Dados para o gráfico de barras (quantidade de workshops por colaborador)
const colaboradores = [
    'João Silva', 'Maria Oliveira', 'Carlos Pereira', 'Ana Costa', 'Felipe Souza', 
    'Ricardo Almeida', 'Patrícia Silva', 'Juliana Martins', 'Eduardo Gomes', 'Fernanda Rocha', 
    'Raul Pereira', 'Sílvia Almeida'
];
const workshopsParticipados = [3, 2, 4, 5, 1, 3, 4, 2, 5, 1, 4, 2]; // Exemplo de dados

const data = {
    labels: colaboradores,  // Nomes dos colaboradores
    datasets: [{
        label: 'Quantidade de Workshops',
        data: workshopsParticipados,  // Dados de workshops
        backgroundColor: '#66b3ff',  // Cor de fundo das barras
        borderColor: '#0056b3',      // Cor da borda das barras
        borderWidth: 1
    }]
};

// Configuração do gráfico de barras
const config = {
    type: 'bar',
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
                        return tooltipItem.label + ': ' + tooltipItem.raw + ' workshops';
                    }
                }
            }
        },
        scales: {
            x: {
                beginAtZero: true
            },
            y: {
                beginAtZero: true
            }
        }
    }
};

// Criar o gráfico de barras
const ctx = document.getElementById('barChart').getContext('2d');
new Chart(ctx, config);