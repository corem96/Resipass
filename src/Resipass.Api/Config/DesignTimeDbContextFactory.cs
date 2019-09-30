using System.IO;
using Microsoft.EntityFrameworkCore.Design;
using Resipass.Data.contexto;

namespace Resipass.Api.Config
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var resolver = new DependencyResolver
            {
                CurrentDirectory = Path.Combine(Directory.GetCurrentDirectory(),
                    "../Resipass.Api")
            };
            return resolver
                .ServiceProvider
                .GetService(typeof(AppDbContext))as AppDbContext;
        }
    }
}