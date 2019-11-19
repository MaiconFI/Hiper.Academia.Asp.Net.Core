using Hiper.Academia.AspNetCore.Domain.Base;
using Hiper.Academia.AspNetCore.Domain.ContasBancarias;
using System;

namespace Hiper.Academia.AspNetCore.Domain.MovimentacoesBancarias
{
    public abstract class MovimentacaoBancaria : EntityBase
    {
        public MovimentacaoBancaria(ContaBancaria contaBancaria, DateTime data, decimal valor)
        {
            GerarIdExterno();

            SetContaBancaria(contaBancaria);
            SetData(data);
            SetValor(valor);
        }

        protected MovimentacaoBancaria()
        {
        }

        public ContaBancaria ContaBancaria { get; private set; }
        public DateTime Data { get; private set; }
        public decimal Valor { get; private set; }

        private void SetContaBancaria(ContaBancaria contaBancaria)
        {
            if (contaBancaria is null)
            {
                AddError("A conta bancária é obrigatória.");
                return;
            }

            ContaBancaria = contaBancaria;
        }

        private void SetData(DateTime data)
        {
            if (data == default)
            {
                AddError("A data é obrigatória.");
                return;
            }

            Data = data;
        }

        private void SetValor(decimal valor)
        {
            if (valor <= default(decimal))
            {
                AddError("O valor informado deve maior que zero.");
                return;
            }

            Valor = valor;
        }
    }
}