using System;

namespace Hiper.Academia.AspNetCore.Repositories.ContasBancarias
{
    public interface IContaBancariaRepository
    {
        decimal GetSaldo(Guid contaBancariaIdExterno);
    }
}