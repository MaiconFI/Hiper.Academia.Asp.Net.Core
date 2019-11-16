using AutoMapper;
using Hiper.Academia.AspNetCore.Domain;
using Hiper.Academia.AspNetCore.Web.Mappers.Converters.Operacoes;
using Hiper.Academia.AspNetCore.Web.ViewModels.Conta.Extrato;

namespace Hiper.Academia.AspNetCore.Web.Mappers
{
    public class HiperAcademiaProfile : Profile
    {
        public HiperAcademiaProfile()
        {
            CreateMap<Operacao, OperacaoViewModel>().ConvertUsing<OperacaoViewModelConverter>();
        }
    }
}