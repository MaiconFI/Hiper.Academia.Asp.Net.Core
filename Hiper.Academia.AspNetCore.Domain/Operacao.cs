using Hiper.Academia.AspNetCore.Domain.Base;
using System;

namespace Hiper.Academia.AspNetCore.Domain
{
    public class Operacao : EntityBase
    {
        public const int DescricaoDaOperacaoMaxLength = 80;

        public Operacao(ContaBancaria contaBancaria, string descricao, bool isEntrada, decimal valor)
        {
            ContaBancaria = contaBancaria;
            Descricao = descricao;
            IsEntrada = isEntrada;
            Valor = valor;
        }

        protected Operacao()
        {
        }

        public ContaBancaria ContaBancaria { get; private set; }
        public DateTime Data { get; private set; }
        public string Descricao { get; private set; }
        public bool IsEntrada { get; private set; }
        public decimal Valor { get; private set; }
    }
}