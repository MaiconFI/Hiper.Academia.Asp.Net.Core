using Hiper.Academia.AspNetCore.Dtos.Base;
using System;

namespace Hiper.Academia.AspNetCore.Dtos.MovimentacoesBancarias
{
    public class CriarMovimentacaoBancariaDto : DtoBase
    {
        public Guid ContaBancariaId { get; set; }
        public decimal Valor { get; set; }
    }
}