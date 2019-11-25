using Hiper.Academia.AspNetCore.Database.Context;
using Hiper.Academia.AspNetCore.Database.Seeds.Entities;
using System.Threading.Tasks;

namespace Hiper.Academia.AspNetCore.Database.Seeds
{
    public class Seed
    {
        private readonly IHiperAcademiaContext _hiperAcademiaContext;

        public Seed(IHiperAcademiaContext hiperAcademiaContext)
        {
            _hiperAcademiaContext = hiperAcademiaContext;
        }

        public void Execute() => Task.WaitAll(ExecuteAsync());

        private async Task ExecuteAsync()
        {
            await new InstituicaoFinanceiraSeed(_hiperAcademiaContext).ExecuteAsync();
            await _hiperAcademiaContext.SaveChangesAsync();
            await new ClienteSeed(_hiperAcademiaContext).ExecuteAsync();
            await _hiperAcademiaContext.SaveChangesAsync();
            await new ContaBancariaSeed(_hiperAcademiaContext).ExecuteAsync();
            await _hiperAcademiaContext.SaveChangesAsync();
            await new MovimentacaoBancariaSeed(_hiperAcademiaContext).ExecuteAsync();

            await _hiperAcademiaContext.SaveChangesAsync();
        }
    }
}