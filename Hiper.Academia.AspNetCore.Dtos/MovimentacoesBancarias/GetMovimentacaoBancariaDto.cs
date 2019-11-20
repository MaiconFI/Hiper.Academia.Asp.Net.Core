using Hiper.Academia.AspNetCore.Dtos.Base;
using System;

namespace Hiper.Academia.AspNetCore.Dtos.MovimentacoesBancarias
{
    public class GetMovimentacaoBancariaDto : DtoBase
    {
        public Guid ContaBancariaId { get; set; }
        public decimal Saldo { get; set; }
        public decimal Valor { get; set; }
    }
}