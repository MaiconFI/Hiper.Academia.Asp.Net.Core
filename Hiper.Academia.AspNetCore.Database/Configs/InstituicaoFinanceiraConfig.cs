using Hiper.Academia.AspNetCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hiper.Academia.AspNetCore.Database.Configs
{
    public class InstituicaoFinanceiraConfig : IEntityTypeConfiguration<InstituicaoFinanceira>
    {
        public void Configure(EntityTypeBuilder<InstituicaoFinanceira> builder)
        {
            builder.ToTable(nameof(InstituicaoFinanceira));
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Codigo).HasMaxLength(InstituicaoFinanceira.CodigoMaxLength).IsRequired();
            builder.Property(x => x.Nome).HasMaxLength(InstituicaoFinanceira.NomeMaxLength).IsRequired();

            builder.HasIndex(x => x.IdExterno).IsUnique();
        }
    }
}