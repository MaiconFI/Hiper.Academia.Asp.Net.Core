using Hiper.Academia.AspNetCore.Database.Context;
using Hiper.Academia.AspNetCore.Domain.ContasBancarias;
using Hiper.Academia.AspNetCore.Domain.MovimentacoesBancarias;
using Hiper.Academia.AspNetCore.Domain.MovimentacoesBancarias.Depositos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Hiper.Academia.AspNetCore.Repositories.ContasBancarias
{
    public class ContaBancariaRepository : IContaBancariaRepository
    {
        private readonly IHiperAcademiaContext _hiperAcademiaContext;

        public ContaBancariaRepository(IHiperAcademiaContext hiperAcademiaContext)
        {
            _hiperAcademiaContext = hiperAcademiaContext;
        }

        public async Task<ContaBancaria> GetContaBancariaAsync(Guid contaBancariaIdExterno, CancellationToken cancellationToken)
            => await _hiperAcademiaContext.ContasBancarias.Where(x => x.IdExterno == contaBancariaIdExterno)
                .FirstOrDefaultAsync(cancellationToken);

        public async Task<ContaBancaria> GetContaBancariaPadraoAsync(CancellationToken cancellationToken)
            => await _hiperAcademiaContext.ContasBancarias
                .FirstOrDefaultAsync(cancellationToken);

        public async Task<ICollection<MovimentacaoBancaria>> GetMovimentacoesAsync(Guid contaBancariaIdExterno, CancellationToken cancellationToken)
            => await _hiperAcademiaContext.MovimentacoesBancarias
                .Where(x => x.ContaBancaria.IdExterno == contaBancariaIdExterno)
                .ToListAsync(cancellationToken);

        public async Task<decimal> GetSaldoAsync(Guid contaBancariaIdExterno, CancellationToken cancellationToken)
            => await _hiperAcademiaContext.MovimentacoesBancarias
                .Where(x => x.ContaBancaria.IdExterno == contaBancariaIdExterno)
                .Select(x => new
                {
                    Valor = x is Deposito ? x.Valor : -x.Valor
                })
                .SumAsync(x => x.Valor, cancellationToken);
    }
}