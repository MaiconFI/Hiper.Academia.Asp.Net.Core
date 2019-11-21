using Hiper.Academia.AspNetCore.Web.Models.Base;
using System;

namespace Hiper.Academia.AspNetCore.Web.Models.MovimentacoesBancarias
{
    public class CriarMovimentacaoBancariaViewModel : BaseViewModel
    {
        public Guid ContaBancariaId { get; set; }
        public decimal Saldo { get; set; }
        public decimal Valor { get; set; }
    }
}