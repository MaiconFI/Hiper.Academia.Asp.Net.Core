using Hiper.Academia.Asp.Net.Core.Web.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hiper.Academia.Asp.Net.Core.Web.Data.Configs
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
        }
    }
}