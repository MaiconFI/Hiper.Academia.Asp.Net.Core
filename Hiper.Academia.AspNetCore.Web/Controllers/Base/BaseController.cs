using Hiper.Academia.AspNetCore.Domain.ContasBancarias;
using Hiper.Academia.AspNetCore.Repositories.ContasBancarias;
using Microsoft.AspNetCore.Mvc;
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

        protected async Task<ContaBancaria> GetContaBancariaPadraoAsync()
            => await _contaBancariaRepository.GetContaBancariaPadraoAsync();
    }
}