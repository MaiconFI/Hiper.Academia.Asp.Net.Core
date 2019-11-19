using Hiper.Academia.AspNetCore.Dtos.MovimentacoesBancarias;
using System.Collections.Generic;

namespace Hiper.Academia.AspNetCore.Dtos.Extrato
{
    public class ExtratoDto
    {
        public ICollection<MovimentacaoBancariaDto> Movimentacoes { get; set; }
    }
}