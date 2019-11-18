using System;

namespace Hiper.Academia.AspNetCore.Web.ViewModels.Conta.Saque
{
    public class SaqueViewModel
    {
        public Guid ContaBancariaId { get; set; }
        public decimal Saldo { get; set; }
    }
}