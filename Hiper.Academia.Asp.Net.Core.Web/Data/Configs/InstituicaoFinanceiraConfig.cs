using Hiper.Academia.Asp.Net.Core.Web.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hiper.Academia.Asp.Net.Core.Web.Data.Configs
{
    public class InstituicaoFinanceiraConfig : IEntityTypeConfiguration<InstituicaoFinanceira>
    {
        public void Configure(EntityTypeBuilder<InstituicaoFinanceira> builder)
        {
            builder.ToTable(nameof(InstituicaoFinanceira));
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Codigo).HasMaxLength(InstituicaoFinanceira.CodigoMaxLength).IsRequired();
            builder.Property(x => x.Nome).HasMaxLength(InstituicaoFinanceira.NomeMaxLength).IsRequired();
        }
    }
}