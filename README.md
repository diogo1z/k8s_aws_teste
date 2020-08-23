![vidalink](https://gitlab.com/uploads/-/system/group/avatar/4474270/vidalink-logo-66x33.png)

# API Mobile

API para funcionalidades específicas do APP Vidalink.

## Technologies

- .NET Core 3.1

### Tests

- [x] Pipeline - Integration Tests: Test Host e xUNit

## Infrastructure

### Application

A aplicação roda dentro do Kubernetes na GCP. Ambientes utilizados:
- [CD] Review
- [CD] Staging
- [Manual] Production

### Database

A aplicação não usa banco de dados.

## Getting started

Para rodar o projeto você precisa ter o [.NET Core 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1) instalado na máquina.

Clone o projeto para sua máquina e restaure os pacotes:

```shell
git clone https://gitlab.com/vidalink/ds/api-mobile
cd api-mobile/
dotnet restore src/
```
A aplicação está pronta para ser utilizada localmente.

### Building

Após alterar o código garanta que a aplicação está "buildando":

```shell
dotnet build src/
```

### Testing

Após alterar o código garanta que os testes da aplicação estão passando:

```shell
dotnet test src/
```

### Running

Para rodar a aplicação via dotnet CLI execute:

```shell
dotnet run -p src/Api
```
Para rodar a aplicação via [Docker](https://www.docker.com/products/docker-desktop) execute:

```shell
docker build . -t {nome-da-imagem}
docker run -p 5000:5000 -e ASPNETCORE_ENVIRONMENT=development {nome-da-imagem}
```
Em ambos os casos a aplicação irá estar disponivel em http://localhost:5000/

### Deploying

O deploy ocorre de forma automática para os ambiente de review e staging, basta fazer o push das alterações para o Gitlab e o pipeline irá fazer a integração e deploy do seu código:

```shell
git add -A
git commit -m "sua msg aqui"
git push origin {branch_desejada}
```

Para verificar o progresso do pipeline clique [aqui](https://gitlab.com/vidalink/ds/api-mobile/pipelines).

## Sonar

Ao rodar o pipeline do Gitlab diversas métricas de qualidade de código serão coletadas pelo Sonar. Verifique o resultado [aqui](http://35.226.78.56:9000/dashboard?id=vdlk-14016649).

## Swagger

Ao rodar local o swagger da aplicação estará disponivel em http://localhost:5000/swagger

## Links

TBD