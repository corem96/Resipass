using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resipass.Domain.modelos.RegistroPago;

namespace Resipass.Data.contexto.DataConfig
{
    public class RegistroPagoConfig : IEntityTypeConfiguration<RegistroPago>
    {
        public void Configure(EntityTypeBuilder<RegistroPago> builder)
        {
            builder.HasKey(registropago => new
            {
                registropago.ResidenteId,
                registropago.TarjetaId
            });
            builder.Property(x => x.FechaPago)
                .IsRequired()
                .HasDefaultValue(DateTime.UtcNow);
            builder.Property(x => x.FechaVencimiento)
                .IsRequired()
                .HasDefaultValue(DateTime.UtcNow.AddDays(30));
            builder.Property(x => x.Importe)
                .IsRequired()
                .HasDefaultValue(300);
            builder.HasOne(x => x.Residente)
                .WithMany(x => x.RegistroPagos)
                .HasForeignKey(x => x.ResidenteId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Tarjeta)
                .WithMany(x => x.RegistroPagos)
                .HasForeignKey(x => x.TarjetaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}