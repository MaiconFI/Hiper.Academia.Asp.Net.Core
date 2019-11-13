using Hiper.Academia.Asp.Net.Core.Web.Domain.Base;
using System;

namespace Hiper.Academia.Asp.Net.Core.Web.Domain
{
    public class Cliente : BaseEntity
    {
        public const int CidadeMaxLength = 100;
        public const int NomeMaxLength = 100;
        public const int TelefoneMaxLength = 15;

        protected Cliente()
        {
        }

        public string Cidade { get; set; }
        public DateTime DataDeNascimento { get; private set; }
        public string Nome { get; private set; }
        public string Telefone { get; set; }
    }
}