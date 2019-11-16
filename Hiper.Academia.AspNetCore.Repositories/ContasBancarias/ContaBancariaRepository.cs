using Hiper.Academia.AspNetCore.Database.Context;
using Hiper.Academia.AspNetCore.Domain.MovimentacoesBancarias;
using System;
using System.Linq;

namespace Hiper.Academia.AspNetCore.Repositories.ContasBancarias
{
    public class ContaBancariaRepository : IContaBancariaRepository
    {
        private readonly IHiperAcademiaContext _hiperAcademiaContext;

        public ContaBancariaRepository(IHiperAcademiaContext hiperAcademiaContext)
        {
            _hiperAcademiaContext = hiperAcademiaContext;
        }

        public decimal GetSaldo(Guid contaBancariaIdExterno)
            => _hiperAcademiaContext.MovimentacoesBancarias
                .Where(x => x.ContaBancaria.IdExterno == contaBancariaIdExterno)
                .Select(x => new
                {
                    Valor = x is Deposito ? x.Valor : -x.Valor
                })
                .Sum(x => x.Valor);
    }
}