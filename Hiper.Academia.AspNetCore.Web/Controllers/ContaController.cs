using Hiper.Academia.AspNetCore.Web.ViewModels.Conta.Extrato;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Hiper.Academia.AspNetCore.Web.Controllers
{
    [Route("conta")]
    public class ContaController : Controller
    {
        [HttpGet("sacar")]
        public IActionResult Sacar()
            => View();

        [HttpGet("transferir")]
        public IActionResult Transferir()
            => View();

        [HttpGet("visualizar-extrato")]
        public IActionResult VisualizarExtrato()
            => View(GetExtrato());

        private ExtratoViewModel GetExtrato()
            => new ExtratoViewModel
            {
                Operacoes = new List<OperacaoViewModel> {
                    new OperacaoViewModel { Data = DateTime.Parse("2019-11-01"), Descricao = "Depósito ", IsEntrada = true, Valor = 1299.9m },
                    new OperacaoViewModel { Data = DateTime.Parse("2019-11-01"), Descricao = "Débito no cartão final 3552", Valor = 29.9m },
                    new OperacaoViewModel { Data = DateTime.Parse("2019-11-04"), Descricao = "Débito no cartão final 3552", Valor = 59.9m },
                    new OperacaoViewModel { Data = DateTime.Parse("2019-11-05"), Descricao = "Crédito no cartão final 3552", Valor = 156.9m },
                    new OperacaoViewModel { Data = DateTime.Parse("2019-11-06"), Descricao = "Débito no cartão final 3552", Valor = 5.9m },
                },
                Saldo = 1047.3m
            };
    }
}