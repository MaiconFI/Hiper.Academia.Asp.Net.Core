using Hiper.Academia.AspNetCore.Dtos.MovimentacoesBancarias;
using System.Threading.Tasks;

namespace Hiper.Academia.AspNetCore.Services.MovimentacoesBancarias
{
    public interface IMovimentacaoBancariaServices
    {
        Task<MovimentacaoBancariaDto> CriarMovimentacaoBancariaAsync(CriarMovimentacaoBancariaDto dto);
    }
}