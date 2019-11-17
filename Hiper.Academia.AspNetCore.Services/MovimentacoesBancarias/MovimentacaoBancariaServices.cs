using Hiper.Academia.AspNetCore.Dtos.MovimentacoesBancarias;
using Hiper.Academia.AspNetCore.Repositories.ContasBancarias;
using System.Threading.Tasks;

namespace Hiper.Academia.AspNetCore.Services.MovimentacoesBancarias
{
    public class MovimentacaoBancariaServices : IMovimentacaoBancariaServices
    {
        private readonly IContaBancariaRepository _contaBancariaRepository;

        public MovimentacaoBancariaServices(IContaBancariaRepository contaBancariaRepository)
        {
            _contaBancariaRepository = contaBancariaRepository;
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

            return null;
        }
    }
}