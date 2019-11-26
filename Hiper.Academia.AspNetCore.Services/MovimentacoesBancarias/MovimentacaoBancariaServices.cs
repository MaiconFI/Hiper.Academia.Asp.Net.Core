using AutoMapper;
using Hiper.Academia.AspNetCore.Database.Context;
using Hiper.Academia.AspNetCore.Domain.MovimentacoesBancarias;
using Hiper.Academia.AspNetCore.Dtos.MovimentacoesBancarias;
using Hiper.Academia.AspNetCore.Repositories.MovimentacoesBancarias;
using System.Threading;
using System.Threading.Tasks;

namespace Hiper.Academia.AspNetCore.Services.MovimentacoesBancarias
{
    public abstract class MovimentacaoBancariaServices : IMovimentacaoBancariaServices
    {
        private readonly IHiperAcademiaContext _hiperAcademiaContext;
        private readonly IMapper _mapper;
        private readonly IMovimentacaoBancariaRepository _movimentacaoBancariaRepository;

        protected MovimentacaoBancariaServices(IHiperAcademiaContext hiperAcademiaContext,
            IMapper mapper,
            IMovimentacaoBancariaRepository movimentacaoBancariaRepository)
        {
            _hiperAcademiaContext = hiperAcademiaContext;
            _mapper = mapper;
            _movimentacaoBancariaRepository = movimentacaoBancariaRepository;
        }

        public async Task<CriarMovimentacaoBancariaDto> CriarMovimentacaoBancariaAsync(CriarMovimentacaoBancariaDto dto, CancellationToken cancellationToken)
        {
            if (dto is null)
            {
                dto = new CriarMovimentacaoBancariaDto();
                dto.AddError("A movimentação bancária é obrigatória e não pode ser nula.");
                return dto;
            }

            var movimentacaoBancaria = await GetMovimentacaoBancariaAsync(dto, cancellationToken);
            if (movimentacaoBancaria.IsValid())
            {
                await _movimentacaoBancariaRepository.AddAsync(movimentacaoBancaria, cancellationToken);
                await _hiperAcademiaContext.SaveChangesAsync(cancellationToken);
            }

            return dto;
        }

        protected abstract Task<MovimentacaoBancaria> GetMovimentacaoBancariaAsync(CriarMovimentacaoBancariaDto dto, CancellationToken cancellationToken);
    }
}