using AutoMapper;
using Hiper.Academia.AspNetCore.Domain.Base;
using Hiper.Academia.AspNetCore.Domain.MovimentacoesBancarias;
using Hiper.Academia.AspNetCore.Dtos.Base;
using Hiper.Academia.AspNetCore.Dtos.Extrato;
using Hiper.Academia.AspNetCore.Dtos.MovimentacoesBancarias;
using Hiper.Academia.AspNetCore.Web.Mappers.Converters.Extrato;
using Hiper.Academia.AspNetCore.Web.Mappers.Converters.MovimentacoesBancarias;
using Hiper.Academia.AspNetCore.Web.Models.Extrato;
using Hiper.Academia.AspNetCore.Web.Models.MovimentacoesBancarias;

namespace Hiper.Academia.AspNetCore.Web.Mappers
{
    public class HiperAcademiaProfile : Profile
    {
        public HiperAcademiaProfile()
        {
            CreateMap<MovimentacaoBancaria, MovimentacaoBancariaDto>().ConvertUsing<MovimentacaoBancariaToMovimentacaoBancariaDtoConverter>();
            CreateMap<ErrorBase, DtoBase>();
            CreateMap<CriarMovimentacaoBancariaDto, CriarMovimentacaoBancariaViewModel>().ConvertUsing<CriarMovimentacaoBancariaDtoToCriarMovimentacaoBancariaViewModelConverter>();
            CreateMap<CriarMovimentacaoBancariaViewModel, CriarMovimentacaoBancariaDto>().ConvertUsing<CriarMovimentacaoBancariaViewModelToCriarMovimentacaoBancariaDtoConverter>();
            CreateMap<MovimentacaoBancariaDto, MovimentacaoBancariaViewModel>().ConvertUsing<MovimentacaoBancariaDtoToMovimentacaoBancariaViewModelConverter>();
            CreateMap<ExtratoDto, ExtratoViewModel>().ConvertUsing<ExtratoDtoToExtratoViewModelConverter>();
        }
    }
}