using Microsoft.AspNetCore.Mvc;

namespace Hiper.Academia.AspNetCore.Web.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}