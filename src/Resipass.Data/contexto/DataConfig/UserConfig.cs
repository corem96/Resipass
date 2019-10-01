using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resipass.Domain.modelos.Usuario;

namespace Resipass.Data.contexto.DataConfig
{
    public class UserConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuario")
                .HasKey(x => x.Id);
            builder.Property(x => x.Nombre)
                .IsRequired()
                .HasMaxLength(70);
            builder.Property(x => x.Apellido)
                .IsRequired();
        }
    }
}