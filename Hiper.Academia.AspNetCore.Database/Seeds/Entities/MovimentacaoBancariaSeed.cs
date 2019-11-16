using Hiper.Academia.AspNetCore.Database.Context;
using Hiper.Academia.AspNetCore.Domain.MovimentacoesBancarias;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hiper.Academia.AspNetCore.Database.Seeds.Entities
{
    public class MovimentacaoBancariaSeed : IEntitySeed
    {
        private readonly IHiperAcademiaContext _hiperAcademiaContext;

        public MovimentacaoBancariaSeed(IHiperAcademiaContext hiperAcademiaContext)
        {
            _hiperAcademiaContext = hiperAcademiaContext;
        }

        public async Task ExecuteAsync()
        {
            var contaBancaria = await _hiperAcademiaContext.ContasBancarias.FirstOrDefaultAsync();
            var movimentacoes = new List<MovimentacaoBancaria>() {
                new Deposito(contaBancaria, DateTime.Parse("2019-11-01"), 1299.9m),
                new Saque(contaBancaria, DateTime.Parse("2019-11-01"), 29.9m),
                new Saque(contaBancaria, DateTime.Parse("2019-11-04"), 59.9m),
                new Saque(contaBancaria, DateTime.Parse("2019-11-05"), 156.9m),
                new Saque(contaBancaria, DateTime.Parse("2019-11-06"), 5.9m),
            };
            await _hiperAcademiaContext.MovimentacoesBancarias.AddRangeAsync(movimentacoes);
        }
    }
}