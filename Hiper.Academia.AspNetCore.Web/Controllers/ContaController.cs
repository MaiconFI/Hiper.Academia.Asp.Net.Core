using Microsoft.AspNetCore.Mvc;

namespace Hiper.Academia.AspNetCore.Web.Controllers
{
    public class ContaController : Controller
    {
        [HttpGet]
        public IActionResult Sacar()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Extrato()
        {
            return View();
        }
    }
}