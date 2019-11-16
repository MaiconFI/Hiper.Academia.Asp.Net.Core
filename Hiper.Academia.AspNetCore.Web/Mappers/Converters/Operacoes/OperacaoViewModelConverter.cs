using AutoMapper;
using Hiper.Academia.AspNetCore.Domain.MovimentacoesBancarias;
using Hiper.Academia.AspNetCore.Dtos.MovimentacoesBancarias;

namespace Hiper.Academia.AspNetCore.Web.Mappers.Converters.Operacoes
{
    public class MovimentacaoBancariaDtoConverter : ITypeConverter<MovimentacaoBancaria, MovimentacaoBancariaDto>
    {
        public MovimentacaoBancariaDto Convert(MovimentacaoBancaria source, MovimentacaoBancariaDto destination, ResolutionContext context)
            => new MovimentacaoBancariaDto()
            {
                Data = source.Data,
                IsEntrada = source is Deposito,
                Valor = source.Valor
            };
    }
}