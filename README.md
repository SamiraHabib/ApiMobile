# Backend do Projeto Mobile do Curso Sistemas de Informação da Faculdade Cesgranrio

## Setup

- Criar um arquivo `appsettings.json` dentro de "ApiMobile"
- Preencher as informações do arquivo conforme o arquivo de exemplo `appsettings.example.json`

## Migrations

- Abrir Console do Gerenciador de Pacotes e executar o comando `Update-Database`

## Integração com API CRM

- Adquira sua chave de api em https://www.consultacrm.com.br/index/api
- Colocar a chave de acesso dentro do `appsettings.json`

## Usando uma API Fake para consulta de CRM

- Altere a configuração de ICRMApiService para utilizar a FakeCRMApiService
### Exemplo
```cs
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<ICRMApiService, FakeCrmApiService>();
    }
```
