using Hiper.Academia.AspNetCore.Domain.ContasBancarias;
using System;

namespace Hiper.Academia.AspNetCore.Domain.MovimentacoesBancarias
{
    public class Deposito : MovimentacaoBancaria
    {
        public Deposito(ContaBancaria contaBancaria, DateTime data, decimal valor)
            : base(contaBancaria, data, valor)
        {
        }

        protected Deposito()
        {
        }
    }
}