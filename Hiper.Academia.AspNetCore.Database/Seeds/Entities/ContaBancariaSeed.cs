using Hiper.Academia.AspNetCore.Database.Context;
using Hiper.Academia.AspNetCore.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Hiper.Academia.AspNetCore.Database.Seeds.Entities
{
    public class ContaBancariaSeed : IEntitySeed
    {
        private readonly IHiperAcademiaContext _hiperAcademiaContext;

        public ContaBancariaSeed(IHiperAcademiaContext hiperAcademiaContext)
        {
            _hiperAcademiaContext = hiperAcademiaContext;
        }

        public async Task ExecuteAsync()
        {
            var cliente = await _hiperAcademiaContext.Clientes.FirstOrDefaultAsync();
            var instituicaoFinanceira = await _hiperAcademiaContext.InstituicoesFinanceiras.FirstOrDefaultAsync();
            var contaBancaria = new ContaBancaria(cliente, instituicaoFinanceira, "123", "1", "5874", "2");
            await _hiperAcademiaContext.ContasBancarias.AddAsync(contaBancaria);
        }
    }
}