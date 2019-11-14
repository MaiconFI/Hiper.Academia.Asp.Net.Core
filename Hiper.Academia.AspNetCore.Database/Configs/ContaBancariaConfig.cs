using Hiper.Academia.AspNetCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hiper.Academia.AspNetCore.Database.Configs
{
    public class ContaBancariaConfig : IEntityTypeConfiguration<ContaBancaria>
    {
        public void Configure(EntityTypeBuilder<ContaBancaria> builder)
        {
            builder.ToTable(nameof(ContaBancaria));
            builder.HasKey(x => x.Id);

            builder.Property(x => x.DigitoDaAgencia).HasMaxLength(ContaBancaria.DigitoDaAgenciaMaxLength).IsRequired();
            builder.Property(x => x.DigitoDaConta).HasMaxLength(ContaBancaria.DigitoDaContaMaxLength).IsRequired();
            builder.Property(x => x.NumeroDaAgencia).HasMaxLength(ContaBancaria.NumeroDaAgenciaMaxLength).IsRequired();
            builder.Property(x => x.NumeroDaConta).HasMaxLength(ContaBancaria.NumeroDaContaMaxLength).IsRequired();

            builder.HasOne(x => x.Cliente).WithMany(x => x.ContasBancarias);
            builder.HasOne(x => x.InstituicaoFinanceira);
        }
    }
}