using AutoMapper;
using Hiper.Academia.AspNetCore.Dtos.MovimentacoesBancarias;
using Hiper.Academia.AspNetCore.Repositories.ContasBancarias;
using Hiper.Academia.AspNetCore.Web.Controllers.Base;
using Hiper.Academia.AspNetCore.Web.ViewModels.Conta.Extrato;
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
        public IActionResult Sacar()
            => View();

        [HttpGet("visualizar-extrato")]
        public async Task<IActionResult> VisualizarExtrato()
        {
            var contaBancariaId = await GetContaBancariaPadraoAsync();
            var movimentacoes = _mapper.Map<ICollection<MovimentacaoBancariaDto>>(await _contaBancariaRepository.GetMovimentacoesAsync(contaBancariaId));
            var extratoViewModel = new ExtratoViewModel { Movimentacoes = movimentacoes };

            return View(extratoViewModel);
        }
    }
}