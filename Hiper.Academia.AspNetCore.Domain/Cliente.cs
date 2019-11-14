using Hiper.Academia.AspNetCore.Domain.Base;
using System;
using System.Collections.Generic;

namespace Hiper.Academia.AspNetCore.Domain
{
    public class Cliente : EntityBase
    {
        public const int CidadeMaxLength = 100;
        public const int NomeMaxLength = 100;
        public const int TelefoneMaxLength = 15;

        public Cliente(string cidade, DateTime dataDeNascimento, string nome, string telefone)
        {
            Cidade = cidade;
            DataDeNascimento = dataDeNascimento;
            Nome = nome;
            Telefone = telefone;
        }

        protected Cliente()
        {
        }

        public string Cidade { get; private set; }
        public ICollection<ContaBancaria> ContasBancarias { get; private set; }
        public DateTime DataDeNascimento { get; private set; }
        public string Nome { get; private set; }
        public string Telefone { get; private set; }
    }
}