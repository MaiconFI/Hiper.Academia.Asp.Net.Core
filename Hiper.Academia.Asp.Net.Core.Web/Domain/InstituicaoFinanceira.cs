using Hiper.Academia.Asp.Net.Core.Web.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hiper.Academia.Asp.Net.Core.Web.Domain
{
    public class InstituicaoFinanceira : BaseEntity
    {
        public const int NomeMaxLength = 100;

        public const int CodigoMaxLength = 10;

        protected InstituicaoFinanceira()
        {
        }

        public string Nome { get; private set; }

        public string Codigo { get; private set; }
    }
}