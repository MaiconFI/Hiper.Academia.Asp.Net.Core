using AutoMapper;
using Hiper.Academia.AspNetCore.Repositories.Operacoes;
using Hiper.Academia.AspNetCore.Web.ViewModels.Conta.Extrato;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hiper.Academia.AspNetCore.Web.Controllers
{
    [Route("conta")]
    public class ContaController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IOperacaoRepository _operacaoRepository;

        public ContaController(IMapper mapper, IOperacaoRepository operacaoRepository)
        {
            _mapper = mapper;
            _operacaoRepository = operacaoRepository;
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
            var operacoes = _mapper.Map<ICollection<OperacaoViewModel>>(await _operacaoRepository.GetAllAsync());
            var extratoViewModel = new ExtratoViewModel { Operacoes = operacoes };

            return View(extratoViewModel);
        }
    }
}