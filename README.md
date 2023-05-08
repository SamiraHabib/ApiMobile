# Backend do Projeto Mobile do Curso Sistemas de Informação da Faculdade Cesgranrio

## Setup

### Instalando dependencias do projeto
- Usando Visual Studio 2022: `Solução ApiMobile -> Restaurar pacotes NuGet`
- Usando dotnet cli: `dotnet restore`
    - *Executar após comando cli acima: `dotnet tool install --global dotnet-ef`

### Environment variables
- Criar um arquivo `appsettings.json` dentro de "ApiMobile"
- Preencher as informações do arquivo conforme o arquivo de exemplo `appsettings.example.json`

### Migrations

- No Visual Studio 2022: Abrir Console do Gerenciador de Pacotes e executar o comando `Update-Database`
- Usando dotnet cli: `dotnet ef database update --project ApiMobile`

### Integração com API CRM

- Adquira sua chave de api em https://www.consultacrm.com.br/index/api
- Colocar a chave de acesso dentro do `appsettings.json`

### Usando uma API Fake para consulta de CRM

- Altere a configuração de ICRMApiService no arquivo startup.cs para utilizar a FakeCRMApiService, conforme o exemplo abaixo:
```cs
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<ICRMApiService, FakeCrmApiService>();
    }
```
<hr/>

## Rodando o Projeto

### Através da dotnet-cli
- Usando o terminal, rode o comando `dotnet run --project ApiMobile`