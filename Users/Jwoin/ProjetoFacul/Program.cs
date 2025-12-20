using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using ProjetoFacul.Data;
using ProjetoFacul.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "ProjetoFacul API",
        Version = "v1",
        Description = "API para gerenciamento de Empresas e Funcionários (CRUD)",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact { Name = "Equipe Projeto", Email = "dev@exemplo.com" }
    });

    // If XML documentation file exists, include it in Swagger UI
    try
    {
        var xmlFile = System.IO.Path.ChangeExtension(System.Reflection.Assembly.GetExecutingAssembly().Location, ".xml");
        if (System.IO.File.Exists(xmlFile)) options.IncludeXmlComments(xmlFile);
    }
    catch { /* ignore if assembly location not available during build */ }
});

// Configure DbContext (SQLite)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection") ?? "Data Source=app.db")
);

// Repositories and services (Clean Architecture)
builder.Services.AddScoped<ProjetoFacul.Repositories.Interfaces.IEmpresaRepository, ProjetoFacul.Repositories.Implementations.EmpresaRepository>();
builder.Services.AddScoped<ProjetoFacul.Repositories.Interfaces.IFuncionarioRepository, ProjetoFacul.Repositories.Implementations.FuncionarioRepository>();
builder.Services.AddScoped<ProjetoFacul.Services.Interfaces.IEmpresaService, ProjetoFacul.Services.Implementations.EmpresaService>();
builder.Services.AddScoped<ProjetoFacul.Services.Interfaces.IFuncionarioService, ProjetoFacul.Services.Implementations.FuncionarioService>();

var app = builder.Build();

// Create DB and seed sample data if necessary
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    // Apply migrations at startup (recommended for development). This will create the DB schema using migrations.
    try
    {
        db.Database.Migrate();
    }
    catch (Exception ex)
    {
        // In rare cases migration may fail (locked DB, etc.). Log and continue so app can still start for diagnostics.
        Console.WriteLine($"EF Migrate failed: {ex.Message}");
    }

    // If seed data via migrations wasn't applied, ensure sample data exists
    if (!db.Empresas.Any())
    {
        db.Empresas.AddRange(new ProjetoFacul.core.Empresa { Nome = "Acme Corp", Cnpj = "12.345.678/0001-90", Endereco = "Rua A, 123" },
                             new ProjetoFacul.core.Empresa { Nome = "Inovatech", Cnpj = "98.765.432/0001-10", Endereco = "Av. B, 456" });
        db.SaveChanges();
    }

    if (!db.Funcionarios.Any())
    {
        db.Funcionarios.AddRange(new ProjetoFacul.core.Funcionario { Nome = "João Silva", Email = "joao.silva@acme.com", Cargo = "Desenvolvedor", EmpresaId = 1 },
                                 new ProjetoFacul.core.Funcionario { Nome = "Maria Santos", Email = "maria.santos@inovatech.com", Cargo = "Analista", EmpresaId = 2 });
        db.SaveChanges();
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Global error handling middleware
app.UseErrorHandling();

app.UseAuthorization();
app.MapControllers();
app.Run();