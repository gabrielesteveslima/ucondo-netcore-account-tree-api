# ucondo-netcore-account-tree-api

Projeto de API com .NET Core 6

## Sobre o projeto

O proposito desse projeto é criar contas ("Accounts") e vincular a outras contas pais ("AccountRelations") e selecionar tipos de contas ("AccountsTypes")

## Base de dados

Para simplificar o uso do projeto foi utilizado Ef Core 6 com Migrations em cima de uma banco SQLServer.

`As migration são executadas junto com o projeto.`

## Estrutura do projeto

A solução possui alguns projetos, separando uma intenção de camada de dominio, digo intenção porque visto que é somente
para aprendizado e o projeto não possui alta complexidade de negocio.

Camadas de aplicação e infraestrutura e uma camada compartilhada chamada `SeedWorks`.

* As regras de negocios + contratos de infraestrutura estão na Camada de Dominio (evitando classes anemicas (somentes entidades com Get e Sets sem logicas))
* Dentro do Application estão a Orquestração entre Domain, Infra e UI (no caso uma API.. mas poderia ser uma console etc)
* Validações feitas com o FluentValidation para os Commands no seguinte padrão:

````
{
  "errors": [
    {
      "title": "Items[0].Qtd",
      "description": "'Qtd' must not be empty.",
      "code": 64257825,
      "type": "Error"
    }
  ],
  "type": "InvalidCommandRuleValidationExceptionProblemDetails",
  "status": 400
}

````

## Docker

Para simplificar o teste da solução criei os arquivos do containers do docker, junto com o docker-compose, portanto para
rodar a solução basta:

``` bash
docker-compose up -d --build --force-recreate
```

Feito isso o docker vai levantar os serviços configurados sendo eles:

* O banco de dados SQLServer; e
* A aplicação web api;

Assim temos os serviços de API e o banco rodando nas portas http/8080 e tcp/1433 respectivamente.

É isso! Obrigado pela atenção.
