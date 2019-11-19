using Hiper.Academia.AspNetCore.Domain.MovimentacoesBancarias;
using System.Threading;
using System.Threading.Tasks;

namespace Hiper.Academia.AspNetCore.Repositories.MovimentacoesBancarias
{
    public interface IMovimentacaoBancariaRepository
    {
        Task AddAsync(MovimentacaoBancaria movimentacaoBancaria, CancellationToken cancellationToken);
    }
}