
## Primeiros Passos com docker

Você pode executar o projeto em qualquer sistema operacional. **Certifique-se de que o Docker está instalado e rodando no seu ambiente
** ([Get Docker Installation](https://docs.docker.com/get-docker/))

Clone o repositório e navegue até a pasta raiz /App-Fullstack, e então execute:

```
docker compose up -d
```
Logo após isso, você podera acessar as aplicações nas seguintes urls:

Front-end http://localhost:4200/

Back-end http://localhost:5156/swagger/index.html
## Caso você não tenha o docker instalado siga esses passos:

Para rodar o front-end entre na pasta /App-Fullstack/front-end e execute:
```
npm install 
```
E depois:
```
ng s
```
Logo após isso você podera acessar a aplicação na seguinte url:

http://localhost:4200/

Para rodar a aplicação back-end entre na pasta /App-Fullstack/back-end e execute:
```
dotnet run
```
Logo após isso a aplicação vai estar rodando na seguinte url:

http://localhost:5156/swagger/index.html

*Obs:*
*Caso você queira trocar a url/porta do back-end seja via docker-compose.yaml seja via launchSettings.json, você precisar alterar também a url/porta no arquivo environment.development.ts na pasta /App-Fullstack/front-end/src/enviroments*

---

## Tecnologias / Componentes implementados

- .NET 10
    - ASP.NET WebApi
    - Entity Framework Core
- Teste
   - xUnit
   - Bogus
   
- Componentes / Serviços
    - FluentValidator
    - MediatR
    - Swagger UI 

- Angular 20
   - Formulario reativos
   - RxJS
   - Integração com back-end
   
## Arquitetura:

### Arquitetura completa implementando as preocupações mais importantes e utilizadas, como:
- Clean Code
- Clean Architecture
- DDD - Domain Driven Design (Layers and Domain Model Pattern)
- Domain Validations
- CQRS (Immediate Consistency)
- Repository
