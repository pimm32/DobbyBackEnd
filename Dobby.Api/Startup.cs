using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dobby.Core.Repositories;
using Dobby.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MySql.Data.EntityFrameworkCore.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Dobby.Core.Services;
using Dobby.Services;
using Swashbuckle.AspNetCore.Swagger;
using AutoMapper;

namespace Dobby.Api
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Dobby", Version = "v1" });
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IPartijService, PartijService>();
            services.AddTransient<IZetService, ZetService>();
            services.AddTransient<IBerichtService, BerichtService>();
            services.AddTransient<IChatService, ChatService>();
            services.AddTransient<IGebruikerService, GebruikerService>();
            services.AddTransient<ISpelerService, SpelerService>();
            services.AddDbContext<DobbyDbContext>(options 
                => options.UseMySQL(Configuration.GetConnectionString("Default"), 
                x => x.MigrationsAssembly("Dobby.Data")
            ));
            services.AddAutoMapper(typeof(Startup));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dobby v1"));
            }

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
