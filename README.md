<h1 align="center">Locadora</h1>

## :computer: Projeto

Repositório de uma aplicação Web para simular um serviço de aluguel de filmes, projeto proposto como atividade final do treinamento .NET C# do Localiza Labs.

Nessa aplicação o cliente vai dispor de recursos para solicitar um cadastro que lhe permite acesso a uma área de solicitação de reservar de itens, com isso será possível escolher um prazo de locação de 2 dias a 1 semana.

Com o cliente executando a devolução do item que solicitou o aluguel essa confirmação é feita pelo funcionário, que vai poder ter acesso a uma área responsável pela baixa da locação.


## :camera: Diagrama do Banco de Dados

<p align="center"> <img src="https://github.com/caioavieira/Locadora/blob/master/src/Locadora.WebApp/wwwroot/images/diagrama-locadora.png" /></p>

## :ballot_box_with_check: Desenvolvedores

- [Caio Vieira](https://github.com/caioavieira)
- [Paulo Alves](https://github.com/PauloAlves8039)
- [Jessica Magalhães](https://github.com/jessicaemg)
- [Mateus Ferreira](https://github.com/mfladeira)
- [Luiz Fernando](https://github.com/LFernando994)

## :wrench: Recursos Utilizados

- [ASP.NET Core MVC v5.0.203](https://dotnet.microsoft.com/download/dotnet/5.0)
- [C#](https://docs.microsoft.com/pt-br/dotnet/csharp/getting-started/)
- [Entity Framework Core v5.0.7](https://docs.microsoft.com/pt-br/ef/core/)
- [SQL Server v18.8](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)
- [Bootstrap v4.3.1](https://getbootstrap.com/)
- [RabbitMQ v6.2.2](https://www.rabbitmq.com/)


## :floppy_disk: Clonar Repositório

`git clone https://github.com/caioavieira/Locadora.git`

## :arrows_counterclockwise: Instalação

Dentro da pasta  `Locadora\src` aplicar as seguintes instruções nas camadas da aplicação:

### Locadora.Infrastructure
    - Atualizar a string de conexão dentro da pasta LocadoraContextFactory.cs para a string que você irá conectar
    - Executar o comando dotnet ef database update
    
### Locadora.Webapi
    - Alterar a string de conexão no arquivo appsettings.json para a string que você irá conectar

### Locadora.WebApp
    - Definir dentro do arquivo appsetting.json a key 'LocadoraApiUrl' para url da webapi
    - Modificar a string de conexão no arquivo Startup.cs para a string que você irá conectar

### Locadora.Worker
    - Mudar dentro do arquivo appsetting.json a key 'LocadoraApiUrl' para url da webapi
    - Alterar a string de conexão no arquivo Program.cs para a string que você irá conectar
    
