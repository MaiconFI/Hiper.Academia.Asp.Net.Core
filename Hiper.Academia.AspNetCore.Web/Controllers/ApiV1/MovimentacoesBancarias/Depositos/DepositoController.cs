using Hiper.Academia.AspNetCore.Dtos.MovimentacoesBancarias;
using Hiper.Academia.AspNetCore.Repositories.ContasBancarias;
using Hiper.Academia.AspNetCore.Services.MovimentacoesBancarias.Depositos;
using Hiper.Academia.AspNetCore.Web.Controllers.ApiV1.Base;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace Hiper.Academia.AspNetCore.Web.Controllers.ApiV1.MovimentacoesBancarias.Depositos
{
    [Route("v{version:apiVersion}/deposito")]
    public class DepositoController : ApiV1BaseController
    {
        private readonly IDepositoServices _depositoServices;

        public DepositoController(IContaBancariaRepository contaBancariaRepository,
            IDepositoServices depositoServices)
            : base(contaBancariaRepository)
        {
            _depositoServices = depositoServices;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(CriarMovimentacaoBancariaDto dto, CancellationToken cancellationToken)
        {
            dto.ContaBancariaId = (await GetContaBancariaPadraoAsync(cancellationToken)).IdExterno;
            return TratarRetorno(await _depositoServices.CriarMovimentacaoBancariaAsync(dto, cancellationToken));
        }
    }
}