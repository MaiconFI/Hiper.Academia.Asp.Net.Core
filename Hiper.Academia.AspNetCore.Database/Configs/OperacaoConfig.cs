using Hiper.Academia.AspNetCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hiper.Academia.AspNetCore.Database.Configs
{
    public class OperacaoConfig : IEntityTypeConfiguration<Operacao>
    {
        public void Configure(EntityTypeBuilder<Operacao> builder)
        {
            builder.ToTable(nameof(Operacao));
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Data).IsRequired();
            builder.Property(x => x.Descricao).HasMaxLength(Operacao.DescricaoDaOperacaoMaxLength).IsRequired();
            builder.Property(x => x.IsEntrada).IsRequired();
            builder.Property(x => x.Valor).IsRequired();

            builder.HasOne(x => x.ContaBancaria).WithMany(x => x.Operacoes);
        }
    }
}