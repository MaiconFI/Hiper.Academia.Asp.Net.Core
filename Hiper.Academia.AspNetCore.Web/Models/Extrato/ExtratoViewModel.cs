using System.Collections.Generic;

namespace Hiper.Academia.AspNetCore.Web.Models.Extrato
{
    public class ExtratoViewModel
    {
        public ICollection<MovimentacaoBancariaViewModel> Movimentacoes { get; set; }
    }
}