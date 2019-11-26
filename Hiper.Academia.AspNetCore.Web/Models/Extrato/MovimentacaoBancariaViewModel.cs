using System;

namespace Hiper.Academia.AspNetCore.Web.Models.Extrato
{
    public class MovimentacaoBancariaViewModel
    {
        public DateTime Data { get; set; }
        public bool IsSaque { get; set; }
        public decimal Valor { get; set; }
    }
}