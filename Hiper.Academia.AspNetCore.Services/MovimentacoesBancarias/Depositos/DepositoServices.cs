using AutoMapper;
using Hiper.Academia.AspNetCore.Database.Context;
using Hiper.Academia.AspNetCore.Domain.MovimentacoesBancarias;
using Hiper.Academia.AspNetCore.Domain.MovimentacoesBancarias.Depositos.Builders;
using Hiper.Academia.AspNetCore.Dtos.MovimentacoesBancarias;
using Hiper.Academia.AspNetCore.Repositories.ContasBancarias;
using Hiper.Academia.AspNetCore.Repositories.MovimentacoesBancarias;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Hiper.Academia.AspNetCore.Services.MovimentacoesBancarias.Depositos
{
    public class DepositoServices : MovimentacaoBancariaServices, IDepositoServices
    {
        private readonly IContaBancariaRepository _contaBancariaRepository;

        public DepositoServices(IContaBancariaRepository contaBancariaRepository,
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

            var deposito = new DepositoBuilder()
                .WithContaBancaria(contaBancaria)
                .WithData(DateTime.Now)
                .WithValor(dto.Valor)
                .Build();

            return deposito;
        }
    }
}