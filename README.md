# ProfitDistribution

### Tecnologias
* REST API
* [.NET 5.0](https://dotnet.microsoft.com/download/dotnet/5.0)
* [Firebase Realtime Database](https://firebase.google.com/products/realtime-database)
* XUnit
* Swagger


### Instalação/Configuração

Clone o projeto e acesse o diretório criado:
    
    $ git clone https://github.com/leandrocamara/ProfitDistribution.git
    $ cd ProfitDistribution

Por padrão, já existe um Banco de Dados configurado no projeto. Caso exista a necessidade de testar um `outro` Firebase Realtime Database:
1) Acesse o `Console` do Firebase, criar um Projeto e um Realtime Database, respectivamente.
2) Importe o arquivo `employees.json` no Banco de Dados.
3) Inclua a URL do Banco de Dados na variável `DefaultConnection`, presente no arquivo `appsettings.Development.json` (ProfitDistribution.API).

### Execução

Inicie a Aplicação (ProfitDistribution.API):

    $ dotnet run --project ./ProfitDistribution.API/ProfitDistribution.API.csproj

Acesse o Swagger UI da API: `https://localhost:5001/swagger`

Execute os testes unitários (ProfitDistribution.Test.Unit):

    $ dotnet test ./ProfitDistribution.Test.Unit/ProfitDistribution.Test.Unit.csproj --logger "console;verbosity=detailed"
