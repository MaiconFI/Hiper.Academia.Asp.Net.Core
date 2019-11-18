using Hiper.Academia.AspNetCore.Domain.Base;
using Hiper.Academia.AspNetCore.Domain.MovimentacoesBancarias;
using System.Collections.Generic;

namespace Hiper.Academia.AspNetCore.Domain.ContasBancarias
{
    public class ContaBancaria : EntityBase
    {
        public const int DigitoDaAgenciaMaxLength = 3;
        public const int DigitoDaContaMaxLength = 3;
        public const int NumeroDaAgenciaMaxLength = 5;
        public const int NumeroDaContaMaxLength = 8;

        public ContaBancaria(Cliente cliente, InstituicaoFinanceira instituicaoFinanceira, string numeroDaAgencia, string digitoDaAgencia, string numeroDaConta, string digitoDaConta)
        {
            GerarIdExterno();

            SetCliente(cliente);
            SetInstituicaoFinanceira(instituicaoFinanceira);
            SetNumeroDaAgencia(numeroDaAgencia);
            SetDigitoDaAgencia(digitoDaAgencia);
            SetNumeroDaConta(numeroDaConta);
            SetDigitoDaConta(digitoDaConta);
        }

        protected ContaBancaria()
        {
        }

        public Cliente Cliente { get; private set; }
        public string DigitoDaAgencia { get; private set; }
        public string DigitoDaConta { get; private set; }
        public InstituicaoFinanceira InstituicaoFinanceira { get; private set; }
        public virtual ICollection<MovimentacaoBancaria> MovimentacoesBancarias { get; private set; }
        public string NumeroDaAgencia { get; private set; }
        public string NumeroDaConta { get; private set; }

        private void SetCliente(Cliente cliente)
        {
            if (cliente is null)
            {
                AddError("O cliente é obrigatório.");
                return;
            }

            Cliente = cliente;
        }

        private void SetDigitoDaAgencia(string digitoDaAgencia)
        {
            if (string.IsNullOrWhiteSpace(digitoDaAgencia))
            {
                AddError("A dígito da agência é obrigatório.");
                return;
            }

            DigitoDaAgencia = digitoDaAgencia;
        }

        private void SetDigitoDaConta(string digitoDaConta)
        {
            if (string.IsNullOrWhiteSpace(digitoDaConta))
            {
                AddError("A dígito da conta é obrigatório.");
                return;
            }

            DigitoDaConta = digitoDaConta;
        }

        private void SetInstituicaoFinanceira(InstituicaoFinanceira instituicaoFinanceira)
        {
            if (instituicaoFinanceira is null)
            {
                AddError("A instituição financeira é obrigatória.");
                return;
            }

            InstituicaoFinanceira = instituicaoFinanceira;
        }

        private void SetNumeroDaAgencia(string numeroDaAgencia)
        {
            if (string.IsNullOrWhiteSpace(numeroDaAgencia))
            {
                AddError("A numero da agência é obrigatório.");
                return;
            }

            NumeroDaAgencia = numeroDaAgencia;
        }

        private void SetNumeroDaConta(string numeroDaConta)
        {
            if (string.IsNullOrWhiteSpace(numeroDaConta))
            {
                AddError("A dígito da agência é obrigatório.");
                return;
            }

            NumeroDaConta = numeroDaConta;
        }
    }
}