using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resipass.Domain.modelos.Tarjeta;

namespace Resipass.Data.contexto.DataConfig
{
    public class TarjetaConfig : IEntityTypeConfiguration<Tarjeta>
    {
        public void Configure(EntityTypeBuilder<Tarjeta> builder)
        {
            builder.ToTable("tarjeta")
                .HasKey(x => x.Id);
            builder.Property(x => x.Codigo)
                .IsRequired()
                .HasMaxLength(20);
            builder.Property(x => x.Vigencia)
                .IsRequired();
            builder.Property(x => x.Activa)
                .IsRequired()
                .HasDefaultValue(true);
            builder.HasOne(x => x.Residente)
                .WithMany(x => x.Tarjetas)
                .HasForeignKey(x => x.ResidenteId);
        }
    }
}