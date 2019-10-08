using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using AutoMapper;
using Resipass.Data.contexto;

namespace Resipass.Api.Config
{
    public static class ServiceCollectionExtensions
    {
        public static void AddMvcSetup(this IServiceCollection services)
        {
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(opt =>
                {
                    opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });
        }
        
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
        }

        public static void AddDbContextStup(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(opt =>
                opt.UseSqlServer(connectionString));
        }

        public static void AddSpaFileSetup(this IServiceCollection services, string clientPath)
        {
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = clientPath;
            });
        }

        public static void AddCorsSetup(this IServiceCollection services)
        {
            services.AddCors(opt =>
            {
                opt.AddPolicy("AllowedOrigins", builder =>
                {
                    builder.AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin();
                });
            });
        }
    }
}