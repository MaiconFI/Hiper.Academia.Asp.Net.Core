using AutoMapper;
using Hiper.Academia.AspNetCore.Dtos.MovimentacoesBancarias;
using Hiper.Academia.AspNetCore.Web.Models.Extrato;

namespace Hiper.Academia.AspNetCore.Web.Mappers.Converters.Extrato
{
    public class MovimentacaoBancariaDtoToMovimentacaoBancariaViewModelConverter : ITypeConverter<MovimentacaoBancariaDto, MovimentacaoBancariaViewModel>
    {
        public MovimentacaoBancariaViewModel Convert(MovimentacaoBancariaDto source, MovimentacaoBancariaViewModel destination, ResolutionContext context)
            => new MovimentacaoBancariaViewModel()
            {
                Data = source.Data,
                IsSaque = source.IsSaque,
                Valor = source.Valor
            };
    }
}