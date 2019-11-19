using Hiper.Academia.AspNetCore.Domain.Base.Builders;
using Hiper.Academia.AspNetCore.Domain.ContasBancarias;
using System;

namespace Hiper.Academia.AspNetCore.Domain.MovimentacoesBancarias.Depositos.Builders
{
    public class DepositoBuilder : IBuilder<Deposito>
    {
        private ContaBancaria ContaBancaria { get; set; }
        private DateTime Data { get; set; }
        private decimal Valor { get; set; }

        public Deposito Build()
            => new Deposito(ContaBancaria, Data, Valor);

        public DepositoBuilder WithContaBancaria(ContaBancaria contaBancaria)
        {
            ContaBancaria = contaBancaria;
            return this;
        }

        public DepositoBuilder WithData(DateTime data)
        {
            Data = data;
            return this;
        }

        public DepositoBuilder WithValor(decimal valor)
        {
            Valor = valor;
            return this;
        }
    }
}