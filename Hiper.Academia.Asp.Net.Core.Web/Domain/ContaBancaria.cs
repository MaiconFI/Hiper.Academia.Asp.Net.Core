using Hiper.Academia.Asp.Net.Core.Web.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hiper.Academia.Asp.Net.Core.Web.Domain
{
    public class ContaBancaria : BaseEntity
    {
        public const int NumeroDaContaMaxLength = 8;
        public const int DigitoDaContaMaxLength = 3;
        public const int NumeroDaAgenciaMaxLength = 5;
        public const int DigitoDaAgenciaMaxLength = 3;

        protected ContaBancaria()
        {
        }

        public Cliente Cliente { get; private set; }
        public InstituicaoFinanceira InstituicaoFinanceira { get; private set; }
        public string NumeroDaConta { get; private set; }
        public string DigitoDaConta { get; private set; }
        public string NumeroDaAgencia { get; private set; }
        public string DigitoDaAgencia { get; private set; }
    }
}