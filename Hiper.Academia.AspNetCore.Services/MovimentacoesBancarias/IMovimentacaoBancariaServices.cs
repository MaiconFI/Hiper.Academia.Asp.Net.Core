using Hiper.Academia.AspNetCore.Domain.MovimentacoesBancarias;
using Hiper.Academia.AspNetCore.Dtos.MovimentacoesBancarias;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hiper.Academia.AspNetCore.Services.MovimentacoesBancarias
{
    public interface IMovimentacaoBancariaServices
    {
        Task<MovimentacaoBancariaDto> CriarMovimentacaoBancariaAsync(CriarMovimentacaoBancariaDto dto);

        Task<ICollection<MovimentacaoBancaria>> GetMovimentacoesAsync(Guid contaBancariaIdExterno);
    }
}