using Hiper.Academia.AspNetCore.Dtos.Base;
using System;

namespace Hiper.Academia.AspNetCore.Dtos.MovimentacoesBancarias
{
    public class MovimentacaoBancariaDto : DtoBase
    {
        public DateTime Data { get; set; }
        public bool IsEntrada { get; set; }
        public decimal Valor { get; set; }
    }
}