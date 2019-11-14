using Hiper.Academia.AspNetCore.Domain.Base;

namespace Hiper.Academia.AspNetCore.Domain
{
    public class InstituicaoFinanceira : EntityBase
    {
        public const int CodigoMaxLength = 10;
        public const int NomeMaxLength = 100;

        public InstituicaoFinanceira(string codigo, string nome)
        {
            Codigo = codigo;
            Nome = nome;
        }

        protected InstituicaoFinanceira()
        {
        }

        public string Codigo { get; private set; }
        public string Nome { get; private set; }
    }
}