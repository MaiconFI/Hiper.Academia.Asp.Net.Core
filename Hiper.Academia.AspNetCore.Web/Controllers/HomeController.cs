using Hiper.Academia.AspNetCore.Repositories.ContasBancarias;
using Hiper.Academia.AspNetCore.Web.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hiper.Academia.AspNetCore.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IContaBancariaRepository _contaBancariaRepository;

        public HomeController(IContaBancariaRepository contaBancariaRepository) :
            base(contaBancariaRepository)
        {
            _contaBancariaRepository = contaBancariaRepository;
        }

        [Route("")]
        public async Task<IActionResult> Index()
        {
            var contaBancariaId = await GetContaBancariaPadraoAsync();
            return View(await _contaBancariaRepository.GetSaldoAsync(contaBancariaId));
        }
    }
}