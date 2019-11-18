using Hiper.Academia.AspNetCore.Domain.Base;

namespace Hiper.Academia.AspNetCore.Domain
{
    public class InstituicaoFinanceira : EntityBase
    {
        public const int CodigoMaxLength = 10;
        public const int NomeMaxLength = 100;

        public InstituicaoFinanceira(string codigo, string nome)
        {
            GerarIdExterno();

            SetCodigo(codigo);
            SetNome(nome);
        }

        protected InstituicaoFinanceira()
        {
        }

        public string Codigo { get; private set; }
        public string Nome { get; private set; }

        private void SetCodigo(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo))
            {
                AddError("A codigo é obrigatório.");
                return;
            }

            Codigo = codigo;
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
    }
}