using AutoMapper;
using Hiper.Academia.AspNetCore.Database.Context;
using Hiper.Academia.AspNetCore.Domain.MovimentacoesBancarias;
using Hiper.Academia.AspNetCore.Domain.MovimentacoesBancarias.Saques.Builders;
using Hiper.Academia.AspNetCore.Dtos.MovimentacoesBancarias;
using Hiper.Academia.AspNetCore.Repositories.ContasBancarias;
using Hiper.Academia.AspNetCore.Repositories.MovimentacoesBancarias;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Hiper.Academia.AspNetCore.Services.MovimentacoesBancarias.Saques
{
    public class SaqueServices : MovimentacaoBancariaServices, ISaqueServices
    {
        private readonly IContaBancariaRepository _contaBancariaRepository;

        public SaqueServices(IContaBancariaRepository contaBancariaRepository,
            IHiperAcademiaContext hiperAcademiaContext,
            IMapper mapper,
            IMovimentacaoBancariaRepository movimentacaoBancariaRepository)
            : base(hiperAcademiaContext,
                  mapper,
                  movimentacaoBancariaRepository)
        {
            _contaBancariaRepository = contaBancariaRepository;
        }

        protected override async Task<MovimentacaoBancaria> GetMovimentacaoBancariaAsync(CriarMovimentacaoBancariaDto dto, CancellationToken cancellationToken)
        {
            var contaBancaria = await _contaBancariaRepository.GetContaBancariaAsync(dto.ContaBancariaId, cancellationToken);

            var saque = new SaqueBuilder()
                .WithContaBancaria(contaBancaria)
                .WithData(DateTime.Now)
                .WithValor(dto.Valor)
                .Build();

            if (saque.IsValid())
            {
                var saldo = await _contaBancariaRepository.GetSaldoAsync(dto.ContaBancariaId, cancellationToken);
                if ((saldo - dto.Valor) <= default(decimal))
                    saque.AddError("O valor informado é menor que o saldo da conta.");
            }

            return saque;
        }
    }
}