using Microsoft.EntityFrameworkCore;

namespace Resipass.Data.contexto
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {}
    }
}