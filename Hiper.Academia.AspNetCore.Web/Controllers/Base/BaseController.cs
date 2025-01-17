﻿using Hiper.Academia.AspNetCore.Domain.ContasBancarias;
using Hiper.Academia.AspNetCore.Repositories.ContasBancarias;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace Hiper.Academia.AspNetCore.Web.Controllers.Base
{
    public abstract class BaseController : Controller
    {
        private readonly IContaBancariaRepository _contaBancariaRepository;

        protected BaseController(IContaBancariaRepository contaBancariaRepository)
        {
            _contaBancariaRepository = contaBancariaRepository;
        }

        protected async Task<ContaBancaria> GetContaBancariaPadraoAsync(CancellationToken cancellationToken)
            => await _contaBancariaRepository.GetContaBancariaPadraoAsync(cancellationToken);
    }
}