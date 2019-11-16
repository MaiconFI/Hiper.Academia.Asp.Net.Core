using Hiper.Academia.AspNetCore.Domain.ContasBancarias;
using Hiper.Academia.AspNetCore.Domain.MovimentacoesBancarias;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hiper.Academia.AspNetCore.Repositories.ContasBancarias
{
    public interface IContaBancariaRepository
    {
        Task<ContaBancaria> GetContaBancariaLogadaAsync();

        Task<ICollection<MovimentacaoBancaria>> GetMovimentacoesAsync(Guid contaBancariaIdExterno);

        Task<decimal> GetSaldoAsync(Guid contaBancariaIdExterno);
    }
}