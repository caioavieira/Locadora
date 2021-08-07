<h1 align="center">Locadora</h1>

## :computer: Projeto

Repositório de uma aplicação Web para simular um serviço de aluguel de filmes, projeto proposto como atividade final do treinamento .NET C# do Localiza Labs!

## :ballot_box_with_check: Desenvolvedores

- [Caio Vieira](https://github.com/caioavieira)
- [Paulo Alves](https://github.com/PauloAlves8039)
- [Jessica Magalhães](https://github.com/jessicaemg)
- [Mateus Ferreira](https://github.com/jessicaemg)
- [Luiz Fernando](https://github.com/caioavieira/Locadora)

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
    
