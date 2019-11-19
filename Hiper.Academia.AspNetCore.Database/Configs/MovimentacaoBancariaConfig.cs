using Hiper.Academia.AspNetCore.Domain.MovimentacoesBancarias;
using Hiper.Academia.AspNetCore.Domain.MovimentacoesBancarias.Depositos;
using Hiper.Academia.AspNetCore.Domain.MovimentacoesBancarias.Saques;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hiper.Academia.AspNetCore.Database.Configs
{
    public class MovimentacaoBancariaConfig : IEntityTypeConfiguration<MovimentacaoBancaria>
    {
        public void Configure(EntityTypeBuilder<MovimentacaoBancaria> builder)
        {
            builder.ToTable(nameof(MovimentacaoBancaria));
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Data).IsRequired();
            builder.Property(x => x.Valor).IsRequired();

            builder.HasDiscriminator<string>("Discriminator")
                .HasValue<Deposito>(nameof(Deposito))
                .HasValue<Saque>(nameof(Saque));

            builder.HasOne(x => x.ContaBancaria).WithMany(x => x.MovimentacoesBancarias);

            builder.HasIndex(x => x.IdExterno).IsUnique();
            builder.HasIndex("Discriminator").IsUnique();
        }
    }
}