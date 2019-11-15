using Hiper.Academia.AspNetCore.Domain.ContasBancarias;

namespace Hiper.Academia.AspNetCore.Domain.MovimentacoesBancarias
{
    public class Saque : MovimentacaoBancaria
    {
        public Saque(ContaBancaria contaBancaria, decimal valor)
            : base(contaBancaria, valor)
        {
        }

        protected Saque()
        {
        }
    }
}