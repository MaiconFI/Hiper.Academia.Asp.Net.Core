using Hiper.Academia.AspNetCore.Web.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace Hiper.Academia.AspNetCore.Web.Models.MovimentacoesBancarias
{
    public class CriarMovimentacaoBancariaViewModel : BaseViewModel
    {
        public Guid ContaBancariaId { get; set; }

        [Display(Name = "Saldo da conta")]
        public decimal Saldo { get; set; }

        [Display(Name = "Valor da movimentação")]
        [Required]
        [Range(1, 800, ErrorMessage = "Você deve movimentar um valor entre R$ 1,00 e R$ 800,00")]
        public decimal Valor { get; set; }
    }
}