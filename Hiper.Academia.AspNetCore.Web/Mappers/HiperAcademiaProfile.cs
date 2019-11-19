using AutoMapper;
using Hiper.Academia.AspNetCore.Domain.Base;
using Hiper.Academia.AspNetCore.Domain.MovimentacoesBancarias;
using Hiper.Academia.AspNetCore.Dtos.Base;
using Hiper.Academia.AspNetCore.Dtos.MovimentacoesBancarias;
using Hiper.Academia.AspNetCore.Web.Mappers.Converters.MovimentacoesBancarias;

namespace Hiper.Academia.AspNetCore.Web.Mappers
{
    public class HiperAcademiaProfile : Profile
    {
        public HiperAcademiaProfile()
        {
            CreateMap<MovimentacaoBancaria, MovimentacaoBancariaDto>().ConvertUsing<MovimentacaoBancariaToMovimentacaoBancariaDtoConverter>();
            CreateMap<ErrorBase, DtoBase>();
        }
    }
}