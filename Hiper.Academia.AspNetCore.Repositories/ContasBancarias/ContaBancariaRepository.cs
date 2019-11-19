using AutoMapper;
using Hiper.Academia.AspNetCore.Database.Context;
using Hiper.Academia.AspNetCore.Domain.ContasBancarias;
using Hiper.Academia.AspNetCore.Domain.MovimentacoesBancarias;
using Hiper.Academia.AspNetCore.Dtos.Extrato;
using Hiper.Academia.AspNetCore.Dtos.MovimentacoesBancarias;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hiper.Academia.AspNetCore.Repositories.ContasBancarias
{
    public class ContaBancariaRepository : IContaBancariaRepository
    {
        private readonly IHiperAcademiaContext _hiperAcademiaContext;
        private readonly IMapper _mapper;

        public ContaBancariaRepository(IHiperAcademiaContext hiperAcademiaContext, IMapper mapper)
        {
            _hiperAcademiaContext = hiperAcademiaContext;
            _mapper = mapper;
        }

        public async Task<ContaBancaria> GetContaBancariaPadraoAsync()
            => await _hiperAcademiaContext.ContasBancarias.FirstOrDefaultAsync();

        public async Task<ExtratoDto> GetExtratoAsync(Guid contaBancariaIdExterno)
        {
            var movimentacoes = await _hiperAcademiaContext.MovimentacoesBancarias
                //.Where(x => x.ContaBancaria.IdExterno == contaBancariaIdExterno) --entender pq não está funcionando
                .ToListAsync();
            return new ExtratoDto
            {
                Movimentacoes = _mapper.Map<ICollection<MovimentacaoBancariaDto>>(movimentacoes)
            };
        }

        public async Task<decimal> GetSaldoAsync(Guid contaBancariaIdExterno)
            => await _hiperAcademiaContext.MovimentacoesBancarias
                //.Where(x => x.ContaBancaria.IdExterno == contaBancariaIdExterno) --entender pq não está funcionando
                .Select(x => new
                {
                    Valor = x is Deposito ? x.Valor : -x.Valor
                })
                .SumAsync(x => x.Valor);
    }
}