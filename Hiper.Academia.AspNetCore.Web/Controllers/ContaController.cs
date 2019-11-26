using AutoMapper;
using Hiper.Academia.AspNetCore.Dtos.MovimentacoesBancarias;
using Hiper.Academia.AspNetCore.Repositories.ContasBancarias;
using Hiper.Academia.AspNetCore.Services.MovimentacoesBancarias.Saques;
using Hiper.Academia.AspNetCore.Web.Controllers.Base;
using Hiper.Academia.AspNetCore.Web.Models.Extrato;
using Hiper.Academia.AspNetCore.Web.Models.MovimentacoesBancarias;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
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
            var dto = new CriarMovimentacaoBancariaViewModel
            {
                ContaBancariaId = contaBancaria.IdExterno,
                Saldo = await _contaBancariaRepository.GetSaldoAsync(contaBancaria.IdExterno, cancellationToken)
            };
            return View(dto);
        }

        [HttpPost("sacar")]
        public async Task<IActionResult> Sacar(CriarMovimentacaoBancariaViewModel viewModel, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid) return View(viewModel);

            var dto = _mapper.Map<CriarMovimentacaoBancariaDto>(viewModel);
            var resultDto = await _saqueServices.CriarMovimentacaoBancariaAsync(dto, cancellationToken);
            viewModel = _mapper.Map<CriarMovimentacaoBancariaViewModel>(resultDto);

            return viewModel.Errors.Any()
                ? View(viewModel)
                : (IActionResult)RedirectToAction("VisualizarExtrato");
        }

        [HttpGet("visualizar-extrato")]
        public async Task<IActionResult> VisualizarExtrato(CancellationToken cancellationToken)
        {
            var contaBancaria = await GetContaBancariaPadraoAsync(cancellationToken);
            var extratoDto = await _contaBancariaRepository.GetExtratoAsync(contaBancaria.IdExterno, cancellationToken);
            var viewModel = _mapper.Map<ExtratoViewModel>(extratoDto);

            return View(viewModel);
        }
    }
}