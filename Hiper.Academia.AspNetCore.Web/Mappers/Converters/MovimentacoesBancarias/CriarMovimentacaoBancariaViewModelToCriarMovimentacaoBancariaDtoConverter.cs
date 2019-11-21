using AutoMapper;
using Hiper.Academia.AspNetCore.Dtos.MovimentacoesBancarias;
using Hiper.Academia.AspNetCore.Web.Models.MovimentacoesBancarias;

namespace Hiper.Academia.AspNetCore.Web.Mappers.Converters.MovimentacoesBancarias
{
    public class CriarMovimentacaoBancariaViewModelToCriarMovimentacaoBancariaDtoConverter : ITypeConverter<CriarMovimentacaoBancariaViewModel, CriarMovimentacaoBancariaDto>
    {
        public CriarMovimentacaoBancariaDto Convert(CriarMovimentacaoBancariaViewModel source, CriarMovimentacaoBancariaDto destination, ResolutionContext context)
            => new CriarMovimentacaoBancariaDto()
            {
                ContaBancariaId = source.ContaBancariaId,
                Valor = source.Valor
            };
    }
}