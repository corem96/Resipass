using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resipass.Domain.modelos.Domicilio;

namespace Resipass.Data.contexto.DataConfig
{
    public class DomicilioConfig : IEntityTypeConfiguration<Domicilio>
    {
        public void Configure(EntityTypeBuilder<Domicilio> builder)
        {
            builder.ToTable("domicilio")
                .HasKey(x => x.Id);
            builder.Property(x => x.Direccion)
                .IsRequired()
                .HasMaxLength(250);
            builder.Property(x => x.Numero)
                .IsRequired()
                .HasMaxLength(8);
        }
    }
}