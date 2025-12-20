# ProjetoFacul - API de Empresas e Funcionários

API REST em ASP.NET Core para gerenciar **Empresas** e **Funcionários**.

## Principais features
- CRUD para Empresas e Funcionários
- Persistência com SQLite via Entity Framework Core
- Validações por Data Annotations
- Documentação com Swagger (aberta em /swagger)

## Endpoints principais
- GET /api/v1/empresas
- GET /api/v1/empresas/{id}
- POST /api/v1/empresas
- PUT /api/v1/empresas/{id}
- DELETE /api/v1/empresas/{id}

- GET /api/v1/funcionarios
- GET /api/v1/funcionarios/{id}
- GET /api/v1/funcionarios/empresa/{empresaId}
- POST /api/v1/funcionarios
- PUT /api/v1/funcionarios/{id}
- DELETE /api/v1/funcionarios/{id}

## Como executar
1. Restaurar pacotes: `dotnet restore`
2. Rodar a aplicação: `dotnet run`
3. Abrir `http://localhost:5000/swagger` (ou a porta exibida) para testar via Swagger UI.

Observação: projeto usa SQLite por padrão (`app.db`). Para criar migrations e aplicar via EF CLI, instale as ferramentas e rode:

```cmd
dotnet tool install --global dotnet-ef
dotnet ef migrations add InitialCreate
dotnet ef database update
```

---

Para mais detalhes e relatório técnico, veja o diretório `docs/` (em progresso).

## Postman

- A coleção Postman para testar os endpoints está em `docs/postman/ProjetoFacul.postman_collection.json`.
- Importe a coleção no Postman e ajuste a variável `baseUrl` (padrão: `http://localhost:5000`).

## Banco de dados (export)

- O arquivo SQLite `app.db` é gerado na raiz do projeto após a primeira execução ou após aplicar migrations.
- Para incluir o banco nas entregas: copie `app.db` para a pasta de artefatos ou anexe ao ZIP do projeto.