using Hiper.Academia.AspNetCore.Database.Context;
using Hiper.Academia.AspNetCore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hiper.Academia.AspNetCore.Database.Seeds.Entities
{
    public class OperacaoSeed : IEntitySeed
    {
        private readonly IHiperAcademiaContext _hiperAcademiaContext;

        public OperacaoSeed(IHiperAcademiaContext hiperAcademiaContext)
        {
            _hiperAcademiaContext = hiperAcademiaContext;
        }

        public async Task ExecuteAsync()
        {
            var contaBancaria = await _hiperAcademiaContext.ContasBancarias.FirstOrDefaultAsync();
            var operacoes = new List<Operacao>() {
                new Operacao(contaBancaria, DateTime.Parse("2019-11-01"), "Depósito ", true, 1299.9m),
                new Operacao(contaBancaria, DateTime.Parse("2019-11-01"), "Débito no cartão final 3552", false, 29.9m),
                new Operacao(contaBancaria, DateTime.Parse("2019-11-04"), "Débito no cartão final 3552", false, 59.9m),
                new Operacao(contaBancaria, DateTime.Parse("2019-11-05"), "Crédito no cartão final 3552", false, 156.9m),
                new Operacao(contaBancaria, DateTime.Parse("2019-11-06"), "Débito no cartão final 3552", false, 5.9m),
            };
            await _hiperAcademiaContext.Operacoes.AddRangeAsync(operacoes);
        }
    }
}