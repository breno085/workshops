# Desafio FAST

## Descrição
Projeto desenvolvido para o desafio de estágio full stack da FAST.

### Backend
- .NET C# para desenvolvimento da API
- SQL Server como banco de dados
- Swagger para documentação da API

### Frontend
- HTML
- CSS
- BootStrap
- JavaScript

## Instruções para Execução Local

### Backend (WorkshopParticipationAPI)

1. Clone o repositório:
```bash
git clone https://github.com/seu-usuario/workshops-desafio-fast.git
```
> Substitua `seu-usuario` pelo seu nome de usuário do GitHub

2. Navegue até a pasta do projeto backend:
```bash
cd workshops-desafio-fast/WorkshopParticipationAPI
```

3. Certifique-se de ter o SQL Server instalado e rodando em sua máquina local

4. Abra o projeto no Visual Studio ou IDE de sua preferência

5. Configure a string de conexão com o sql server no arquivo `appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=.;Database=WorkshopParticipationDb;User Id=seu_usuario;Password=sua_senha;TrustServerCertificate=True;"
     }
   }
   ```

6. Execute as migrações:
```bash
dotnet ef database update
```

8. execute o seguinte script no SQL Server usando o SQL Server Management Studio (SSMS) para popular o banco com dados de teste:
```sql
USE WorkshopParticipationDb
GO

INSERT INTO Colaboradores (Nome) VALUES
('Alice Santos'),
('Bruno Almeida'),
('Carla Souza'),
('Daniel Lima'),
('Eduarda Rocha'),
('Felipe Mendes'),
('Gabriela Nunes'),
('Henrique Castro'),
('Isabela Ferreira'),
('João Pereira');

INSERT INTO Workshops (Nome, DataRealizacao, Descricao)
VALUES
('Gestão Ágil', '2025-01-02 16:00:00', 'Técnicas e metodologias ágeis.'),
('Banco de Dados SQL', '2025-01-09 16:00:00', 'Introdução ao SQL Server.'),
('Desenvolvimento Web', '2025-01-16 16:00:00', 'Fundamentos de desenvolvimento web moderno.'),
('Machine Learning', '2025-01-23 16:00:00', 'Introdução ao aprendizado de máquina.'),
('APIs REST', '2025-01-30 16:00:00', 'Boas práticas para desenvolvimento de APIs RESTful.'),
('DevOps', '2025-02-06 16:00:00', 'Automação e CI/CD para desenvolvimento ágil.');

INSERT INTO Presencas (ColaboradorId, WorkshopId) VALUES
(1, 1), (2, 1), (3, 1),
(2, 2), (4, 2),
(1, 3), (3, 3), (5, 3), (6, 3),
(4, 4), (5, 4),
(1, 5), (2, 5), (3, 5),
(6, 6), (7, 6), (8, 6), (9, 6);
```

7. Execute o projeto
   - No Visual Studio: Pressione F5 ou clique em "Start"
   - Via linha de comando: `dotnet watch run`
   - A documentação da API no swagger irá abrir no seu navegador
   - Teste a API

### Frontend

1. Navegue até a pasta do projeto frontend:
```bash
cd Frontend
```

2. Abra o arquivo `index.html` em seu navegador preferido

3. Para abrir o arquivo, você pode:
   - Dar um duplo clique no arquivo `index.html`
   - Ou arrastar o arquivo para seu navegador
   - Ou usar um servidor local simples (como Live Server do VS Code)

## Observações
- Inicialmente, considerei um endpoint /api/presencas para gerenciar a participação dos colaboradores nos workshops de forma modular. No entanto, para atender aos requisitos do desafio, essa relação foi integrada aos endpoints existentes
- O frontend ainda não foi conectado à API
