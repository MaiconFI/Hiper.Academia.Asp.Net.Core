using Hiper.Academia.AspNetCore.Database.Context;
using Hiper.Academia.AspNetCore.Domain.MovimentacoesBancarias;
using System.Threading;
using System.Threading.Tasks;

namespace Hiper.Academia.AspNetCore.Repositories.MovimentacoesBancarias
{
    public class MovimentacaoBancariaRepository : IMovimentacaoBancariaRepository
    {
        private readonly IHiperAcademiaContext _hiperAcademiaContext;

        public MovimentacaoBancariaRepository(IHiperAcademiaContext hiperAcademiaContext)
        {
            _hiperAcademiaContext = hiperAcademiaContext;
        }

        public async Task AddAsync(MovimentacaoBancaria movimentacaoBancaria, CancellationToken cancellationToken)
            => await _hiperAcademiaContext.MovimentacoesBancarias.AddAsync(movimentacaoBancaria, cancellationToken);
    }
}