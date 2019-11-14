using Hiper.Academia.AspNetCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Hiper.Academia.AspNetCore.Database.Context
{
    public interface IHiperAcademiaContext : IDisposable
    {
        DbSet<Cliente> Clientes { get; set; }

        DbSet<ContaBancaria> ContasBancarias { get; set; }

        DatabaseFacade Database { get; }

        DbSet<InstituicaoFinanceira> InstituicoesFinanceiras { get; set; }

        bool AllMigrationsApplied();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        void Seed();
    }
}