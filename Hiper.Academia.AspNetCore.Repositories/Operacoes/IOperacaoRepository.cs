using System.Collections.Generic;
using System.Threading.Tasks;
using Hiper.Academia.AspNetCore.Domain;

namespace Hiper.Academia.AspNetCore.Repositories.Operacoes
{
    public interface IOperacaoRepository
    {
        Task<IEnumerable<Operacao>> GetAllAsync();
    }
}