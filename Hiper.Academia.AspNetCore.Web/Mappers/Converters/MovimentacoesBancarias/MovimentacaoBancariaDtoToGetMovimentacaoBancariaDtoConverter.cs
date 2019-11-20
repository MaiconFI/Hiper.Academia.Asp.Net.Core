using AutoMapper;
using Hiper.Academia.AspNetCore.Dtos.MovimentacoesBancarias;

namespace Hiper.Academia.AspNetCore.Web.Mappers.Converters.MovimentacoesBancarias
{
    public class MovimentacaoBancariaDtoToGetMovimentacaoBancariaDtoConverter : ITypeConverter<MovimentacaoBancariaDto, GetMovimentacaoBancariaDto>
    {
        public GetMovimentacaoBancariaDto Convert(MovimentacaoBancariaDto source, GetMovimentacaoBancariaDto destination, ResolutionContext context)
        {
            var dto = new GetMovimentacaoBancariaDto()
            {
                Valor = source.Valor
            };
            dto.AddError(source.Errors);
            return dto;
        }
    }
}