using Hiper.Academia.Asp.Net.Core.Web.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hiper.Academia.Asp.Net.Core.Web.Data.Context
{
    public class HiperAcademiaContext : DbContext, IHiperAcademiaContext
    {

        protected HiperAcademiaContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<ContaBancaria> ContasBancarias { get; set; }

        public DbSet<InstituicaoFinanceira> InstituicoesFinanceiras { get; set; }

        public bool AllMigrationsApplied()
        {
            var idsDasMigrationsJaExecutadas = this.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(x => x.MigrationId);

            var idsDeTodasAsMigrations = this.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(x => x.Key);

            return !idsDeTodasAsMigrations.Except(idsDasMigrationsJaExecutadas).Any();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IHiperAcademiaContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
