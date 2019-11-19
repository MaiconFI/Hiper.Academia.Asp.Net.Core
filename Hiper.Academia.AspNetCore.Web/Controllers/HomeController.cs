using Hiper.Academia.AspNetCore.Repositories.ContasBancarias;
using Hiper.Academia.AspNetCore.Web.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
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
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var contaBancaria = await GetContaBancariaPadraoAsync(cancellationToken);
            return View(await _contaBancariaRepository.GetSaldoAsync(contaBancaria.IdExterno, cancellationToken));
        }
    }
}