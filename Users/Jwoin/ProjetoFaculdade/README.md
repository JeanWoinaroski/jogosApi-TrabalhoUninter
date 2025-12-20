# ProjetoFaculdade API

API REST simples em ASP.NET Core com camadas (Controllers, Services, Repositories, Data) — CRUD para Empresas e Funcionários.

Como rodar

- Requisitos: .NET 9 SDK
- Restaurar pacotes: `dotnet restore`
- Build: `dotnet build`
- Rodar: `dotnet run`

A documentação Swagger estará disponível em `https://localhost:5001/swagger` (ou `http://localhost:5000/swagger`).

Observações

- As validações usam Data Annotations nos DTOs. O middleware global provê tratamento básico de exceções (retorna ProblemDetails para erros).
- Foram adicionados DTOs e AutoMapper para separar modelo de domínio da API."