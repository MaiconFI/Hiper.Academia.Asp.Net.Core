using Hiper.Academia.AspNetCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hiper.Academia.AspNetCore.Database.Configs
{
    public class ClienteConfig : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable(nameof(Cliente));
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Cidade).HasMaxLength(Cliente.CidadeMaxLength).IsRequired();
            builder.Property(x => x.DataDeNascimento).IsRequired();
            builder.Property(x => x.Nome).HasMaxLength(Cliente.NomeMaxLength).IsRequired();
            builder.Property(x => x.Telefone).HasMaxLength(Cliente.TelefoneMaxLength).IsRequired();

            builder.HasIndex(x => x.IdExterno).IsUnique();
        }
    }
}