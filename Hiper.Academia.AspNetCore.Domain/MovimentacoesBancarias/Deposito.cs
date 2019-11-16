using Hiper.Academia.AspNetCore.Domain.ContasBancarias;

namespace Hiper.Academia.AspNetCore.Domain.MovimentacoesBancarias
{
    public class Deposito : MovimentacaoBancaria
    {
        public Deposito(ContaBancaria contaBancaria, decimal valor)
            : base(contaBancaria, valor)
        {
        }

        protected Deposito()
        {
        }
    }
}