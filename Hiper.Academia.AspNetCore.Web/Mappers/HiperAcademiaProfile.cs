using AutoMapper;
using Hiper.Academia.AspNetCore.Domain.MovimentacoesBancarias;
using Hiper.Academia.AspNetCore.Dtos.MovimentacoesBancarias;
using Hiper.Academia.AspNetCore.Web.Mappers.Converters.Operacoes;

namespace Hiper.Academia.AspNetCore.Web.Mappers
{
    public class HiperAcademiaProfile : Profile
    {
        public HiperAcademiaProfile()
        {
            CreateMap<MovimentacaoBancaria, MovimentacaoBancariaDto>().ConvertUsing<MovimentacaoBancariaToMovimentacaoBancariaDtoConverter>();
        }
    }
}