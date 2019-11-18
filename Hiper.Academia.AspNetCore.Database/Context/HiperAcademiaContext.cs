using Hiper.Academia.AspNetCore.Database.Seeds;
using Hiper.Academia.AspNetCore.Domain;
using Hiper.Academia.AspNetCore.Domain.ContasBancarias;
using Hiper.Academia.AspNetCore.Domain.MovimentacoesBancarias;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Linq;

namespace Hiper.Academia.AspNetCore.Database.Context
{
    public class HiperAcademiaContext : DbContext, IHiperAcademiaContext
    {
        public HiperAcademiaContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ContaBancaria> ContasBancarias { get; set; }
        public DbSet<InstituicaoFinanceira> InstituicoesFinanceiras { get; set; }
        public DbSet<MovimentacaoBancaria> MovimentacoesBancarias { get; set; }

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

        public void Seed() => new Seed(this).Execute();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IHiperAcademiaContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}