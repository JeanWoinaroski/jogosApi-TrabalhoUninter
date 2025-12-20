using Microsoft.EntityFrameworkCore;
using ProjetoFacul.Data;
using ProjetoFacul.Repositories.Implementations;
using ProjetoFacul.Services.Implementations;
using ProjetoFacul.core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System;

namespace ProjetoFacul.Tests.Services
{
    [TestClass]
    public class FuncionarioServiceTests
    {
        private AppDbContext CreateInMemoryContext(string name)
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: name)
                .Options;
            return new AppDbContext(options);
        }

        [TestMethod]
        public async Task CreateAsync_Throws_WhenEmpresaInvalid()
        {
            using var db = CreateInMemoryContext("FuncionarioEmpresaInvalidDb");
            var empresaRepo = new EmpresaRepository(db);
            var funcRepo = new FuncionarioRepository(db);
            var service = new FuncionarioService(funcRepo, empresaRepo);

            var funcionario = new Funcionario { Nome = "Fulano", Email = "f@x.com", EmpresaId = 42 };
            await Assert.ThrowsExceptionAsync<KeyNotFoundException>(async () => await service.CreateAsync(funcionario));
        }

        [TestMethod]
        public async Task UpdateAsync_Throws_WhenNotFound()
        {
            using var db = CreateInMemoryContext("FuncionarioUpdateDb");
            var empresaRepo = new EmpresaRepository(db);
            var funcRepo = new FuncionarioRepository(db);
            var service = new FuncionarioService(funcRepo, empresaRepo);

            var funcionario = new Funcionario { Id = 999, Nome = "NoOne", Email = "na@na.com", EmpresaId = 1 };
            await Assert.ThrowsExceptionAsync<KeyNotFoundException>(async () => await service.UpdateAsync(funcionario));
        }
    }
}
