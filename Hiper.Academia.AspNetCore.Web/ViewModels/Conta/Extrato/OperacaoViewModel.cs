using System;

namespace Hiper.Academia.AspNetCore.Web.ViewModels.Conta.Extrato
{
    public class OperacaoViewModel
    {
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public bool IsEntrada { get; set; }
        public decimal Valor { get; set; }
    }
}