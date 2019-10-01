using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resipass.Domain.modelos.Residente;

namespace Resipass.Data.contexto.DataConfig
{
    public class ResidenteConfig : IEntityTypeConfiguration<Residente>
    {
        public void Configure(EntityTypeBuilder<Residente> builder)
        {
            builder.ToTable("residente")
                .HasKey(x => x.Id);
            builder.Property(x => x.Nombre)
                .IsRequired()
                .HasMaxLength(80);
            builder.Property(x => x.Apellido)
                .IsRequired()
                .HasMaxLength(80);
            builder.Property(x => x.NombreUsuario)
                .IsRequired()
                .HasMaxLength(20);
            builder.Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(20);
            builder.HasOne(x => x.Domicilio)
                .WithMany(x => x.Residentes)
                .HasForeignKey(x => x.DomicilioId);
        }
    }
}