using Microsoft.EntityFrameworkCore;
using Resipass.Data.contexto.DataConfig;
using Resipass.Domain.modelos.Aviso;
using Resipass.Domain.modelos.Domicilio;
using Resipass.Domain.modelos.RegistroPago;
using Resipass.Domain.modelos.Residente;
using Resipass.Domain.modelos.Tarjeta;
using Resipass.Domain.modelos.Usuario;

namespace Resipass.Data.contexto
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {}

        public DbSet<Aviso> Avisos { get; set; }
        public DbSet<Tarjeta> Tarjetas { get; set; }
        public DbSet<Domicilio> Domicilios { get; set; }
        public DbSet<Residente> Residentes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<RegistroPago> RegistroPagos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new AvisoConfig())
                .ApplyConfiguration(new TarjetaConfig())
                .ApplyConfiguration(new DomicilioConfig())
                .ApplyConfiguration(new ResidenteConfig())
                .ApplyConfiguration(new UsuarioConfig())
                .ApplyConfiguration(new RegistroPagoConfig());
        }
    }
}