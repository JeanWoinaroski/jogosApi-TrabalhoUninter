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
    public class EmpresaServiceTests
    {
        private AppDbContext CreateInMemoryContext(string name)
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: name)
                .Options;
            return new AppDbContext(options);
        }

        [TestMethod]
        public async Task CreateAsync_AddsEmpresa()
        {
            using var db = CreateInMemoryContext("CreateEmpresaDb");
            var repo = new EmpresaRepository(db);
            var service = new EmpresaService(repo);

            var empresa = new Empresa { Nome = "Test Co" };
            var created = await service.CreateAsync(empresa);

            Assert.IsNotNull(created);
            Assert.AreEqual("Test Co", created.Nome);
        }

        [TestMethod]
        public async Task UpdateAsync_Throws_WhenNotFound()
        {
            using var db = CreateInMemoryContext("UpdateEmpresaDb");
            var repo = new EmpresaRepository(db);
            var service = new EmpresaService(repo);

            var empresa = new Empresa { Id = 999, Nome = "Non existing" };
            await Assert.ThrowsExceptionAsync<KeyNotFoundException>(async () => await service.UpdateAsync(empresa));
        }

        [TestMethod]
        public async Task DeleteAsync_Throws_WhenNotFound()
        {
            using var db = CreateInMemoryContext("DeleteEmpresaDb");
            var repo = new EmpresaRepository(db);
            var service = new EmpresaService(repo);

            await Assert.ThrowsExceptionAsync<KeyNotFoundException>(async () => await service.DeleteAsync(123));
        }
    }
}
