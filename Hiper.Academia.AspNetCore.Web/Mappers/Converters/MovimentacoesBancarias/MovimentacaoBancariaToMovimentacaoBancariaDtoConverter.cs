using AutoMapper;
using Hiper.Academia.AspNetCore.Domain.MovimentacoesBancarias;
using Hiper.Academia.AspNetCore.Dtos.MovimentacoesBancarias;

namespace Hiper.Academia.AspNetCore.Web.Mappers.Converters.MovimentacoesBancarias
{
    public class MovimentacaoBancariaToMovimentacaoBancariaDtoConverter : ITypeConverter<MovimentacaoBancaria, MovimentacaoBancariaDto>
    {
        public MovimentacaoBancariaDto Convert(MovimentacaoBancaria source, MovimentacaoBancariaDto destination, ResolutionContext context)
            => new MovimentacaoBancariaDto()
            {
                Data = source.Data,
                IsDeposito = source is Deposito,
                IsSaque = source is Saque,
                Valor = source.Valor
            };
    }
}