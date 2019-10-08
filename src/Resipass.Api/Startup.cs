using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json.Serialization;
using Resipass.Api.Config;

namespace Resipass.Api
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcSetup();
            services.AddDbContextStup(Configuration.GetConnectionString("Default"));
            services.AddAutoMapperSetup();
            services.AddSpaFileSetup(Configuration["clientUi:path"]);
            services.AddCorsSetup();
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
            app.UseCors("AllowedOrigins");
            app.UseSpaStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), UiPath))
            });
            app.UseMvc();
        }
    }
}