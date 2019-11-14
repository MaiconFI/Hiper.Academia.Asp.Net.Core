using Hiper.Academia.AspNetCore.Database.Context;
using Hiper.Academia.AspNetCore.Domain;
using System.Threading.Tasks;

namespace Hiper.Academia.AspNetCore.Database.Seeds.Entities
{
    public class InstituicaoFinanceiraSeed : IEntitySeed
    {
        private readonly IHiperAcademiaContext _hiperAcademiaContext;

        public InstituicaoFinanceiraSeed(IHiperAcademiaContext hiperAcademiaContext)
        {
            _hiperAcademiaContext = hiperAcademiaContext;
        }

        public async Task ExecuteAsync()
        {
            var instituicaoFinanceira = new InstituicaoFinanceira("001", "Banco do Brasil");
            await _hiperAcademiaContext.InstituicoesFinanceiras.AddAsync(instituicaoFinanceira);
        }
    }
}