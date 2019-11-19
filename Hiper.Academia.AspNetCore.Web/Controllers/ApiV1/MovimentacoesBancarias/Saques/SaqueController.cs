using Hiper.Academia.AspNetCore.Dtos.MovimentacoesBancarias;
using Hiper.Academia.AspNetCore.Repositories.ContasBancarias;
using Hiper.Academia.AspNetCore.Services.MovimentacoesBancarias.Saques;
using Hiper.Academia.AspNetCore.Web.Controllers.ApiV1.Base;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace Hiper.Academia.AspNetCore.Web.Controllers.ApiV1.MovimentacoesBancarias.Depositos
{
    [Route("v{version:apiVersion}/saque")]
    public class SaqueController : ApiV1BaseController
    {
        private readonly ISaqueServices _saqueServices;

        public SaqueController(IContaBancariaRepository contaBancariaRepository,
            ISaqueServices saqueServices)
            : base(contaBancariaRepository)
        {
            _saqueServices = saqueServices;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(CriarMovimentacaoBancariaDto dto, CancellationToken cancellationToken)
        {
            dto.ContaBancariaId = (await GetContaBancariaPadraoAsync(cancellationToken)).IdExterno;
            return TratarRetorno(await _saqueServices.CriarMovimentacaoBancariaAsync(dto, cancellationToken));
        }
    }
}