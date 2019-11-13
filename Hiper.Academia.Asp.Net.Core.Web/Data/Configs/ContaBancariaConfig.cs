using Hiper.Academia.Asp.Net.Core.Web.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hiper.Academia.Asp.Net.Core.Web.Data.Configs
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

            builder.HasOne(x => x.Cliente);
            builder.HasOne(x => x.InstituicaoFinanceira);
        }
    }
}