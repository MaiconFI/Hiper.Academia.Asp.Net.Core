using AutoMapper;
using Hiper.Academia.AspNetCore.Dtos.MovimentacoesBancarias;
using Hiper.Academia.AspNetCore.Repositories.ContasBancarias;
using Hiper.Academia.AspNetCore.Web.Controllers.Base;
using Hiper.Academia.AspNetCore.Web.ViewModels.Conta.Extrato;
using Hiper.Academia.AspNetCore.Web.ViewModels.Conta.Saque;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hiper.Academia.AspNetCore.Web.Controllers
{
    [Route("conta")]
    public class ContaController : BaseController
    {
        private readonly IContaBancariaRepository _contaBancariaRepository;
        private readonly IMapper _mapper;

        public ContaController(IContaBancariaRepository contaBancariaRepository,
            IMapper mapper) :
            base(contaBancariaRepository)
        {
            _contaBancariaRepository = contaBancariaRepository;
            _mapper = mapper;
        }

        [HttpGet("depositar")]
        public IActionResult Depositar()
            => View();

        [HttpGet("sacar")]
        public async Task<IActionResult> Sacar()
        {
            var contaBancaria = await GetContaBancariaPadraoAsync();
            var saqueViewModel = new SaqueViewModel
            {
                ContaBancariaId = contaBancaria.IdExterno,
                Saldo = await _contaBancariaRepository.GetSaldoAsync(contaBancaria.IdExterno)
            };
            return View(saqueViewModel);
        }

        [HttpGet("visualizar-extrato")]
        public async Task<IActionResult> VisualizarExtrato()
        {
            var contaBancaria = await GetContaBancariaPadraoAsync();
            var movimentacoes = await _contaBancariaRepository.GetMovimentacoesAsync(contaBancaria.IdExterno);
            var movimentacoesDto = _mapper.Map<ICollection<MovimentacaoBancariaDto>>(movimentacoes);
            var extratoViewModel = new ExtratoViewModel { Movimentacoes = movimentacoesDto };

            return View(extratoViewModel);
        }
    }
}