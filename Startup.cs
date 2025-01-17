using ApiSeriesAlex.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiSeriesAlex.Repositories;
using Microsoft.OpenApi.Models;

namespace ApiSeriesAlex
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
            string cadenaConexion = this.Configuration.GetConnectionString("cadenasql");

            services.AddSwaggerGen(
            options =>
            {
                options.SwaggerDoc(
                    name: "v1", new OpenApiInfo
                    {
                        Title = "Api Series ",
                        Version = "v1",
                        Description = "Api paraExamenSeries"
                    });
            });


            services.AddTransient<PersonajesRepository>();
            services.AddTransient<SeriesRepository>();
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(cadenaConexion));
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    options.SwaggerEndpoint(
                        url: "/swagger/v1/swagger.json", name: "Api v1");
                    options.RoutePrefix = "";
                });


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
