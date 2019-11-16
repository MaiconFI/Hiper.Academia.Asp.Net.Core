using AutoMapper;
using Hiper.Academia.AspNetCore.Domain;
using Hiper.Academia.AspNetCore.Web.ViewModels.Conta.Extrato;

namespace Hiper.Academia.AspNetCore.Web.Mappers.Converters.Operacoes
{
    public class OperacaoViewModelConverter : ITypeConverter<Operacao, OperacaoViewModel>
    {
        public OperacaoViewModel Convert(Operacao source, OperacaoViewModel destination, ResolutionContext context)
            => new OperacaoViewModel()
            {
                Data = source.Data,
                Descricao = source.Descricao,
                IsEntrada = source.IsEntrada,
                Valor = source.Valor
            };
    }
}