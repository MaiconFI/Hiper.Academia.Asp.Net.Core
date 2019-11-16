using Hiper.Academia.AspNetCore.Domain.Base;
using Hiper.Academia.AspNetCore.Domain.ContasBancarias;

namespace Hiper.Academia.AspNetCore.Domain.MovimentacoesBancarias
{
    public abstract class MovimentacaoBancaria : EntityBase
    {
        public MovimentacaoBancaria(ContaBancaria contaBancaria, decimal valor)
        {
            SetContaBancaria(contaBancaria);
            SetValor(valor);
        }

        protected MovimentacaoBancaria()
        {
        }

        public ContaBancaria ContaBancaria { get; private set; }

        public decimal Valor { get; private set; }

        private void SetContaBancaria(ContaBancaria contaBancaria)
        {
            if (ContaBancaria is null)
            {
                AddError("A conta bancária é obrigatória.");
                return;
            }

            ContaBancaria = contaBancaria;
        }

        private void SetValor(decimal valor)
        {
            if (Valor >= default(decimal))
            {
                AddError("O valor informado deve maior que zero.");
                return;
            }

            Valor = valor;
        }
    }
}