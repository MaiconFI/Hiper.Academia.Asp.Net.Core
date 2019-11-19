using Hiper.Academia.AspNetCore.Domain.ContasBancarias;
using Hiper.Academia.AspNetCore.Dtos.Extrato;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Hiper.Academia.AspNetCore.Repositories.ContasBancarias
{
    public interface IContaBancariaRepository
    {
        Task<ContaBancaria> GetContaBancariaAsync(Guid contaBancariaIdExterno, CancellationToken cancellationToken);

        Task<ContaBancaria> GetContaBancariaPadraoAsync(CancellationToken cancellationToken);

        Task<ICollection<MovimentacaoBancaria>> GetMovimentacoesAsync(Guid contaBancariaIdExterno, CancellationToken cancellationToken);

        Task<decimal> GetSaldoAsync(Guid contaBancariaIdExterno, CancellationToken cancellationToken);
    }
}