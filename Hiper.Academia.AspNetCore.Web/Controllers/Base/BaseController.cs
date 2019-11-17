using Hiper.Academia.AspNetCore.Repositories.ContasBancarias;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Hiper.Academia.AspNetCore.Web.Controllers.Base
{
    public class BaseController : Controller
    {
        private readonly IContaBancariaRepository _contaBancariaRepository;

        public BaseController(IContaBancariaRepository contaBancariaRepository)
        {
            _contaBancariaRepository = contaBancariaRepository;
        }

        protected async Task<Guid> GetContaBancariaPadraoAsync()
            => (await _contaBancariaRepository.GetContaBancariaPadraoAsync()).IdExterno;
    }
}