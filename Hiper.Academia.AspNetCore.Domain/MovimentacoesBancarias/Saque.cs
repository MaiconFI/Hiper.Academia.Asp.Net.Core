using Hiper.Academia.AspNetCore.Domain.ContasBancarias;
using System;

namespace Hiper.Academia.AspNetCore.Domain.MovimentacoesBancarias
{
    public class Saque : MovimentacaoBancaria
    {
        public Saque(ContaBancaria contaBancaria, DateTime data, decimal valor)
            : base(contaBancaria, data, valor)
        {
        }

        protected Saque()
        {
        }
    }
}