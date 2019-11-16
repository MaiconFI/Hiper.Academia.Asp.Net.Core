using Hiper.Academia.AspNetCore.Database.Context;
using Hiper.Academia.AspNetCore.Domain.ContasBancarias;
using Hiper.Academia.AspNetCore.Domain.MovimentacoesBancarias;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<ContaBancaria> GetContaBancariaLogadaAsync()
            => await _hiperAcademiaContext.ContasBancarias.FirstOrDefaultAsync();

        public async Task<ICollection<MovimentacaoBancaria>> GetMovimentacoesAsync(Guid contaBancariaIdExterno)
            => await _hiperAcademiaContext.MovimentacoesBancarias
                    //.Where(x => x.ContaBancaria.IdExterno == contaBancariaIdExterno)
                    .ToListAsync();

        public async Task<decimal> GetSaldoAsync(Guid contaBancariaIdExterno)
                    => await _hiperAcademiaContext.MovimentacoesBancarias
                //.Where(x => x.ContaBancaria.IdExterno == contaBancariaIdExterno)
                .Select(x => new
                {
                    Valor = x is Deposito ? x.Valor : -x.Valor
                })
                .SumAsync(x => x.Valor);
    }
}