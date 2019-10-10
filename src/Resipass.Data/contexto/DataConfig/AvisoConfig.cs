using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resipass.Domain.modelos.Aviso;

namespace Resipass.Data.contexto.DataConfig
{
    public class AvisoConfig : IEntityTypeConfiguration<Aviso>
    {
        public void Configure(EntityTypeBuilder<Aviso> builder)
        {
            builder.ToTable("aviso")
                .HasKey(x => x.Id);
            builder.Property(x => x.Comunicado)
                .HasMaxLength(250);
            builder.Property(x => x.FechaPublicacion)
                .HasDefaultValueSql("GETUTCDATE()");
            builder.HasOne(x => x.Usuario)
                .WithMany(x => x.Avisos)
                .HasForeignKey(x => x.UsuarioId);
        }
    }
}