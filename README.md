# ProfitDistribution

### Tecnologias
* REST API
* [.NET 5.0](https://dotnet.microsoft.com/download/dotnet/5.0)
* [Firebase Realtime Database](https://firebase.google.com/products/realtime-database)
* XUnit
* Swagger


### Instalação/Configuração
	# Clone o projeto
    $ git clone https://github.com/leandrocamara/ProfitDistribution.git

    # Acesse o diretório do projeto
    $ cd ProfitDistribution

    # Por padrão, já existe um Banco de Dados configurado no projeto
    # Caso exista a necessidade de testar um outro Banco de Dados:
    1) Acessar o Console do Firebase, criar um Projeto e um Realtime Database, respectivamente
    2) Importar o arquivo "employees.json" no Banco de Dados
    3) Incluir a URL do Banco de Dados na variável "DefaultConnection", presente no arquivo "appsettings.Development.json" (ProfitDistribution.API)

### Execução
    # Inicie a Aplicação (ProfitDistribution.API)
    $ dotnet run --project ./ProfitDistribution.API/ProfitDistribution.API.csproj

    # Acessar Swagger UI
    > https://localhost:5001/swagger

    # Para executar os testes unitários (ProfitDistribution.Test.Unit)
    $ dotnet test ./ProfitDistribution.Test.Unit/ProfitDistribution.Test.Unit.csproj --logger "console;verbosity=detailed"
