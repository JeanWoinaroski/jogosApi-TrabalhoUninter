# Relatório Técnico — ProjetoFacul

Resumo do que foi implementado:

- API REST em ASP.NET Core (.NET 9) com endpoints para gerenciamento de Empresas e Funcionários.
- Persistência com SQLite + Entity Framework Core (migrations aplicadas).
- Camadas: Controllers → Services → Repositories → Data (AppDbContext).
- Validações com DataAnnotations e tratamento global de erros (Middleware).
- Documentação via Swagger (configurada).

Como rodar:

1. Restaurar pacotes:

```cmd
dotnet restore
```

2. Aplicar migrations (se necessário):

```cmd
dotnet tool install --global dotnet-ef
dotnet ef database update
```

3. Rodar a aplicação:

```cmd
dotnet run
```

4. Testar via Swagger UI: `http://localhost:5000/swagger`

Export do banco de dados:

- O arquivo `app.db` é gerado na raiz do projeto. Basta copiar `app.db` para anexar ao relatório ou enviá-lo como artefato.
 
- Há um script auxiliar em `docs/scripts/export-db.bat` que copia `app.db` para `docs/artifacts` com timestamp (útil para empacotar artefatos no Windows).

Postman / API tests:

- A coleção Postman está em `docs/postman/ProjetoFacul.postman_collection.json`

Próximos passos recomendados (se desejar):

- Recuperar/ajustar os testes unitários (xUnit) ou converter temporariamente para MSTest/NUnit para retomar pipeline de CI.
- Adicionar integração contínua (GitHub Actions) para build, migrate e testes.
- Gerar PDF com este relatório (ex.: usar pandoc ou salvar em PDF via VS Code / print to PDF).
