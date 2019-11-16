using AutoMapper;
using Hiper.Academia.AspNetCore.Dtos.MovimentacoesBancarias;
using Hiper.Academia.AspNetCore.Services.ContasBancarias;
using Hiper.Academia.AspNetCore.Services.MovimentacoesBancarias;
using Hiper.Academia.AspNetCore.Web.ViewModels.Conta.Extrato;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hiper.Academia.AspNetCore.Web.Controllers
{
    [Route("conta")]
    public class ContaController : Controller
    {
        private readonly IContaBancariaServices _contaBancariaServices;
        private readonly IMapper _mapper;
        private readonly IMovimentacaoBancariaServices _movimentacaoBancariaServices;

        public ContaController(IContaBancariaServices contaBancariaServices, IMapper mapper, IMovimentacaoBancariaServices movimentacaoBancariaServices)
        {
            _contaBancariaServices = contaBancariaServices;
            _mapper = mapper;
            _movimentacaoBancariaServices = movimentacaoBancariaServices;
        }

        [HttpGet("depositar")]
        public IActionResult Depositar()
            => View();

        [HttpGet("sacar")]
        public IActionResult Sacar()
            => View();

        [HttpGet("visualizar-extrato")]
        public async Task<IActionResult> VisualizarExtrato()
        {
            var contaBancariaId = await GetContaBancariaIdLogada();
            var movimentacoes = _mapper.Map<ICollection<MovimentacaoBancariaDto>>(await _movimentacaoBancariaServices.GetMovimentacoesAsync(contaBancariaId));
            var extratoViewModel = new ExtratoViewModel { Movimentacoes = movimentacoes };

            return View(extratoViewModel);
        }

        private async Task<Guid> GetContaBancariaIdLogada()
            => (await _contaBancariaServices.GetContaBancariaLogadaAsync()).IdExterno;
    }
}