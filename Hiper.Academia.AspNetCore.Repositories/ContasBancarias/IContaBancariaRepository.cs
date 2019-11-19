using Hiper.Academia.AspNetCore.Domain.ContasBancarias;
using Hiper.Academia.AspNetCore.Dtos.Extrato;
using System;
using System.Threading.Tasks;

namespace Hiper.Academia.AspNetCore.Repositories.ContasBancarias
{
    public interface IContaBancariaRepository
    {
        Task<ContaBancaria> GetContaBancariaPadraoAsync();

        Task<ExtratoDto> GetExtratoAsync(Guid contaBancariaIdExterno);

        Task<decimal> GetSaldoAsync(Guid contaBancariaIdExterno);
    }
}