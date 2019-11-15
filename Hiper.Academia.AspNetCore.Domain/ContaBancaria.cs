using Hiper.Academia.AspNetCore.Domain.Base;
using System.Collections.Generic;

namespace Hiper.Academia.AspNetCore.Domain
{
    public class ContaBancaria : EntityBase
    {
        public const int DigitoDaAgenciaMaxLength = 3;
        public const int DigitoDaContaMaxLength = 3;
        public const int NumeroDaAgenciaMaxLength = 5;
        public const int NumeroDaContaMaxLength = 8;

        public ContaBancaria(Cliente cliente, InstituicaoFinanceira instituicaoFinanceira, string numeroDaAgencia, string digitoDaAgencia, string numeroDaConta, string digitoDaConta)
        {
            Cliente = cliente;
            InstituicaoFinanceira = instituicaoFinanceira;
            NumeroDaAgencia = numeroDaAgencia;
            DigitoDaAgencia = digitoDaAgencia;
            NumeroDaConta = numeroDaConta;
            DigitoDaConta = digitoDaConta;
        }

        protected ContaBancaria()
        {
        }

        public Cliente Cliente { get; private set; }
        public string DigitoDaAgencia { get; private set; }
        public string DigitoDaConta { get; private set; }
        public InstituicaoFinanceira InstituicaoFinanceira { get; private set; }
        public string NumeroDaAgencia { get; private set; }
        public string NumeroDaConta { get; private set; }
        public ICollection<Operacao> Operacoes { get; private set; }
    }
}