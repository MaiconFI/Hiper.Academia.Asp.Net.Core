using AutoMapper;
using Hiper.Academia.AspNetCore.Dtos.MovimentacoesBancarias;
using Hiper.Academia.AspNetCore.Repositories.ContasBancarias;
using Hiper.Academia.AspNetCore.Services.MovimentacoesBancarias.Saques;
using Hiper.Academia.AspNetCore.Web.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace Hiper.Academia.AspNetCore.Web.Controllers
{
    [Route("conta")]
    public class ContaController : BaseController
    {
        private readonly IContaBancariaRepository _contaBancariaRepository;
        private readonly IMapper _mapper;
        private readonly ISaqueServices _saqueServices;

        public ContaController(IContaBancariaRepository contaBancariaRepository, IMapper mapper, ISaqueServices saqueServices)
            : base(contaBancariaRepository)
        {
            _contaBancariaRepository = contaBancariaRepository;
            _mapper = mapper;
            _saqueServices = saqueServices;
        }

        [HttpGet("depositar")]
        public IActionResult Depositar()
            => View();

        [HttpGet("sacar")]
        public async Task<IActionResult> Sacar(CancellationToken cancellationToken)
        {
            var contaBancaria = await GetContaBancariaPadraoAsync(cancellationToken);
            var dto = new GetMovimentacaoBancariaDto()
            {
                ContaBancariaId = contaBancaria.IdExterno,
                Saldo = await _contaBancariaRepository.GetSaldoAsync(contaBancaria.IdExterno, cancellationToken)
            };
            return View(dto);
        }

        [HttpPost("sacar")]
        public async Task<IActionResult> Sacar(CriarMovimentacaoBancariaDto dto, CancellationToken cancellationToken)
        {
            var resultDto = await _saqueServices.CriarMovimentacaoBancariaAsync(dto, cancellationToken);
            var getMovimentacaoDto = _mapper.Map<GetMovimentacaoBancariaDto>(resultDto);
            var contaBancaria = await GetContaBancariaPadraoAsync(cancellationToken);
            getMovimentacaoDto.ContaBancariaId = contaBancaria.IdExterno;
            getMovimentacaoDto.Saldo = await _contaBancariaRepository.GetSaldoAsync(contaBancaria.IdExterno, cancellationToken);

            return View(dto);
        }

        [HttpGet("visualizar-extrato")]
        public async Task<IActionResult> VisualizarExtrato(CancellationToken cancellationToken)
        {
            var contaBancaria = await GetContaBancariaPadraoAsync(cancellationToken);
            var extrato = await _contaBancariaRepository.GetExtratoAsync(contaBancaria.IdExterno, cancellationToken);

            return View(extrato);
        }
    }
}