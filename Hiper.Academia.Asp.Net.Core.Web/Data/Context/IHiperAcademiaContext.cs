using Hiper.Academia.Asp.Net.Core.Web.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Hiper.Academia.Asp.Net.Core.Web.Data.Context
{
    public interface IHiperAcademiaContext
    {
        DbSet<Cliente> Clientes { get; set; }

        DbSet<ContaBancaria> ContasBancarias { get; set; }

        DbSet<InstituicaoFinanceira> InstituicoesFinanceiras { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        bool AllMigrationsApplied();
    }
}
