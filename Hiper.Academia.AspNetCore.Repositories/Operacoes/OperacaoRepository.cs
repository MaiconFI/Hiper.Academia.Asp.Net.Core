using Hiper.Academia.AspNetCore.Database.Context;
using Hiper.Academia.AspNetCore.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hiper.Academia.AspNetCore.Repositories.Operacoes
{
    public class OperacaoRepository : IOperacaoRepository
    {
        private readonly IHiperAcademiaContext _context;

        public OperacaoRepository(IHiperAcademiaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Operacao>> GetAllAsync()
            => await _context.Operacoes.OrderBy(x => x.Data).ToListAsync();
    }
}