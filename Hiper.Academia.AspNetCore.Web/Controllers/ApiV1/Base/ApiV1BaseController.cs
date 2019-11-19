using Hiper.Academia.AspNetCore.Domain.ContasBancarias;
using Hiper.Academia.AspNetCore.Dtos.Base;
using Hiper.Academia.AspNetCore.Repositories.ContasBancarias;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Hiper.Academia.AspNetCore.Web.Controllers.ApiV1.Base
{
    [ApiController]
    [ApiVersion("1")]
    public abstract class ApiV1BaseController : ControllerBase
    {
        private readonly IContaBancariaRepository _contaBancariaRepository;

        protected ApiV1BaseController(IContaBancariaRepository contaBancariaRepository)
        {
            _contaBancariaRepository = contaBancariaRepository;
        }

        protected async Task<ContaBancaria> GetContaBancariaPadraoAsync(CancellationToken cancellationToken)
            => await _contaBancariaRepository.GetContaBancariaPadraoAsync(cancellationToken);

        protected IActionResult TratarRetorno(DtoBase dto)
            => dto.Errors?.Any() ?? true
                ? (IActionResult)BadRequest(dto)
                : Ok(dto);
    }
}