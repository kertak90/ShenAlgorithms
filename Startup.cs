using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ShenAlgorithms.Services;

namespace ShenAlgorithms
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(c =>
                {
                    c.EnableAnnotations();
                    c.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = "Api",
                        Description = "Task solves of Shen-programmirovanie_teoremy_i_zadachi book",
                        Version = "v1"
                    });
                });
            services.AddMvc(options => options.EnableEndpointRouting = false);
            
            services.AddScoped<AlgorithmsTasksSolvingService>();
            services.AddScoped<SortAlgorithmsService>();
            services.AddScoped<TreeService>();
            services.AddScoped<SomeArrayAlgorithmsService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "api/swagger/{documentName}/swagger.json";
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/api/swagger/v1/swagger.json", "Sample API");
                c.RoutePrefix = "api/swagger";
            });
            app.UseMvc();
        }
    }
}
