using Hiper.Academia.AspNetCore.Dtos.MovimentacoesBancarias;
using System.Collections.Generic;

namespace Hiper.Academia.AspNetCore.Web.ViewModels.Conta.Extrato
{
    public class ExtratoViewModel
    {
        public ICollection<MovimentacaoBancariaDto> Movimentacoes { get; set; }
    }
}