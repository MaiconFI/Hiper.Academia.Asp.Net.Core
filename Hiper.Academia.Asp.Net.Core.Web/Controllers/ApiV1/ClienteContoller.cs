using Hiper.Academia.Asp.Net.Core.Web.Controllers.ApiV1.Base;
using Hiper.Academia.AspNetCore.Database.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Hiper.Academia.Asp.Net.Core.Web.Controllers.ApiV1
{
    [Route("v{version:apiVersion}/cliente")]
    public class ClienteContoller : ApiV1BaseController
    {
        private readonly IHiperAcademiaContext _hiperAcademiaContext;

        public ClienteContoller(IHiperAcademiaContext hiperAcademiaContext)
        {
            _hiperAcademiaContext = hiperAcademiaContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync() => Ok(await _hiperAcademiaContext.Clientes.FirstOrDefaultAsync());
    }
}