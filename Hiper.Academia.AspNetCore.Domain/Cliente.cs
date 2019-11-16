using Hiper.Academia.AspNetCore.Domain.Base;
using Hiper.Academia.AspNetCore.Domain.ContasBancarias;
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
            SetCidade(cidade);
            SetDataDeNascimento(dataDeNascimento);
            SetNome(nome);
            SetTelefone(telefone);
        }

        protected Cliente()
        {
        }

        public string Cidade { get; private set; }

        public ICollection<ContaBancaria> ContasBancarias { get; private set; }

        public DateTime DataDeNascimento { get; private set; }

        public string Nome { get; private set; }

        public string Telefone { get; private set; }

        private void SetCidade(string cidade)
        {
            if (string.IsNullOrWhiteSpace(cidade))
            {
                AddError("A cidade é obrigatória");
                return;
            }

            Cidade = cidade;
        }

        private void SetDataDeNascimento(DateTime dataDeNascimento)
        {
            if (dataDeNascimento == default)
            {
                AddError("A data de nascimento é obrigatória.");
                return;
            }

            DataDeNascimento = dataDeNascimento;
        }

        private void SetNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                AddError("A nome é obrigatório.");
                return;
            }

            Nome = nome;
        }

        private void SetTelefone(string telefone)
        {
            if (string.IsNullOrWhiteSpace(telefone))
            {
                AddError("A telefone é obrigatório.");
                return;
            }

            Telefone = telefone;
        }
    }
}