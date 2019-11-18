using AutoMapper;
using Hiper.Academia.AspNetCore.Database.Context;
using Hiper.Academia.AspNetCore.Domain.MovimentacoesBancarias;
using Hiper.Academia.AspNetCore.Dtos.MovimentacoesBancarias;
using Hiper.Academia.AspNetCore.Repositories.ContasBancarias;
using Hiper.Academia.AspNetCore.Repositories.MovimentacoesBancarias;
using System.Threading.Tasks;

namespace Hiper.Academia.AspNetCore.Services.MovimentacoesBancarias
{
    public abstract class MovimentacaoBancariaServices : IMovimentacaoBancariaServices
    {
        private readonly IContaBancariaRepository _contaBancariaRepository;
        private readonly IHiperAcademiaContext _hiperAcademiaContext;
        private readonly IMapper _mapper;
        private readonly IMovimentacaoBancariaRepository _movimentacaoBancariaRepository;

        public MovimentacaoBancariaServices(IContaBancariaRepository contaBancariaRepository,
            IHiperAcademiaContext hiperAcademiaContext,
            IMapper mapper,
            IMovimentacaoBancariaRepository movimentacaoBancariaRepository)
        {
            _contaBancariaRepository = contaBancariaRepository;
            _hiperAcademiaContext = hiperAcademiaContext;
            _mapper = mapper;
            _movimentacaoBancariaRepository = movimentacaoBancariaRepository;
        }

        public async Task<MovimentacaoBancariaDto> CriarMovimentacaoBancariaAsync(CriarMovimentacaoBancariaDto dto)
        {
            var resultDto = new MovimentacaoBancariaDto();

            if (dto is null)
            {
                resultDto.AddError("O dto é obrigatório e não pode ser nulo.");
                return resultDto;
            }

            var saldo = await _contaBancariaRepository.GetSaldoAsync(dto.ContaBancariaId);

            var movimentacaoBancaria = CriarMovimentacaoBancaria(saldo);
            if (movimentacaoBancaria.IsValid())
            {
                await _movimentacaoBancariaRepository.AddAsync(movimentacaoBancaria);
                await _hiperAcademiaContext.SaveChangesAsync();
            }

            return _mapper.Map<MovimentacaoBancariaDto>(movimentacaoBancaria);
        }

        protected abstract MovimentacaoBancaria CriarMovimentacaoBancaria(decimal saldo);
    }
}