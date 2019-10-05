using System;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using Resipass.Data.contexto;
using Resipass.Middleware;
using VueCliMiddleware;

namespace Resipass.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private const string AllowedOrigins = "AllowedOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(opt =>
                {
                    opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });
            services.AddDbContext<AppDbContext>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString("Default")));
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = Configuration["clientUi:path"];
            });
            services.AddCors(opt =>
            {
                opt.AddPolicy(AllowedOrigins, builder =>
                {
                    builder.AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin();
//                        .WithOrigins("http://localhost:8080");
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            var UiPath = Configuration["clientUi:path"];
            if (!Directory.Exists(UiPath))
                throw new Exception($"La ruta de la aplicación frontend no existe: {Path.GetFullPath(UiPath)}");
            
            app.UseHttpsRedirection();
            app.UseCors(AllowedOrigins);
//            app.UseCors();
//            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), UiPath))
            });
//            app.UseSpa(spa =>
//            {
//                spa.Options.SourcePath = UiPath;
//                spa.UseProxyToSpaDevelopmentServer("http://localhost:8080");
////                spa.UseVueCli(npmScript: "serve", port: 8080);
////                spa.Options.SourcePath = UiPath;
////                if (env.IsDevelopment())
////                    spa.UseVueDevelopmentServer(npmScript: "serve");
//            });
            app.UseMvc();
        }
    }
}