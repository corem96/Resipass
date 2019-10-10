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
                .HasDefaultValueSql("GETUTCDATE()");
            builder.Property(x => x.FechaVencimiento)
                .IsRequired()
                .HasDefaultValueSql("DATEADD(month, 1, GETUTCDATE())");
            builder.Property(x => x.Cajero)
                .IsRequired()
                .HasMaxLength(150);
            builder.Property(x => x.Sucursal)
                .IsRequired();
            builder.Property(x => x.NumeroAutorizacion)
                .IsRequired();
            builder.Property(x => x.NumeroFolio)
                .IsRequired();
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