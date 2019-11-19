using Hiper.Academia.AspNetCore.Domain.Base.Builders;
using Hiper.Academia.AspNetCore.Domain.ContasBancarias;
using System;

namespace Hiper.Academia.AspNetCore.Domain.MovimentacoesBancarias.Saques.Builders
{
    public class SaqueBuilder : IBuilder<Saque>
    {
        private ContaBancaria ContaBancaria { get; set; }
        private DateTime Data { get; set; }
        private decimal Valor { get; set; }

        public Saque Build()
            => new Saque(ContaBancaria, Data, Valor);

        public SaqueBuilder WithContaBancaria(ContaBancaria contaBancaria)
        {
            ContaBancaria = contaBancaria;
            return this;
        }

        public SaqueBuilder WithData(DateTime data)
        {
            Data = data;
            return this;
        }

        public SaqueBuilder WithValor(decimal valor)
        {
            Valor = valor;
            return this;
        }
    }
}