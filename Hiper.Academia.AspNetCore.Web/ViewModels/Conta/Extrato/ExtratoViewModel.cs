using System.Collections.Generic;

namespace Hiper.Academia.AspNetCore.Web.ViewModels.Conta.Extrato
{
    public class ExtratoViewModel
    {
        public ICollection<OperacaoViewModel> Operacoes { get; set; }
        public decimal Saldo { get; set; }
    }
}