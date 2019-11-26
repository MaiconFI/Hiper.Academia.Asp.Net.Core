using AutoMapper;
using Hiper.Academia.AspNetCore.Dtos.Extrato;
using Hiper.Academia.AspNetCore.Web.Models.Extrato;
using System.Collections.Generic;

namespace Hiper.Academia.AspNetCore.Web.Mappers.Converters.Extrato
{
    public class ExtratoDtoToExtratoViewModelConverter : ITypeConverter<ExtratoDto, ExtratoViewModel>
    {
        public ExtratoViewModel Convert(ExtratoDto source, ExtratoViewModel destination, ResolutionContext context)
            => new ExtratoViewModel()
            {
                Movimentacoes = context.Mapper.Map<ICollection<MovimentacaoBancariaViewModel>>(source.Movimentacoes),
            };
    }
}