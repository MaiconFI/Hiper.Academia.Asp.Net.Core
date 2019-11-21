using AutoMapper;
using Hiper.Academia.AspNetCore.Dtos.MovimentacoesBancarias;
using Hiper.Academia.AspNetCore.Web.Models.MovimentacoesBancarias;

namespace Hiper.Academia.AspNetCore.Web.Mappers.Converters.MovimentacoesBancarias
{
    public class CriarMovimentacaoBancariaDtoToCriarMovimentacaoBancariaViewModelConverter : ITypeConverter<CriarMovimentacaoBancariaDto, CriarMovimentacaoBancariaViewModel>
    {
        public CriarMovimentacaoBancariaViewModel Convert(CriarMovimentacaoBancariaDto source, CriarMovimentacaoBancariaViewModel destination, ResolutionContext context)
            => new CriarMovimentacaoBancariaViewModel()
            {
                ContaBancariaId = source.ContaBancariaId,
                Valor = source.Valor,
                Errors = source.Errors
            };
    }
}