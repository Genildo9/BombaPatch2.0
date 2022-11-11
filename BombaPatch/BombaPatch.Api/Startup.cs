using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BombaPatch.Application;
using BombaPatch.Application.Contratos;
using BombaPatch.Persistence;
using BombaPatch.Persistence.Contextos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using AutoMapper;

namespace BombaPatch.API
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
//trabalhando com arquitetura MVC
            services.AddDbContext<BombaPatchContext>(
                //fazendo a configuração do sqlite no app settings
                context => context.UseSqlite(Configuration.GetConnectionString("Default"))
            );
            services.AddControllers() //retorna o controller (1)
                    /*.AddNewtonsoftJson(XmlConfigurationExtensions => x.SerializerSettings.ReferenceLoopHandling
                    = Newtonsoft.Json.ReferenceLoopHandling.Ignore)*/;
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IJogoService, JogoService>();
            services.AddScoped<ISelecaoService, SelecaoService>();
            services.AddScoped<IGeralPersist, GeralPersist>();
            services.AddScoped<ISelecaoPersist, SelecaoPersist>();
            services.AddScoped<IJogoPersist, JogoPersist>();
            services.AddScoped<IGrupoPersist, GrupoPersist>();

            services.AddCors();
            services.AddSwaggerGen(c =>  //config swagger
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BombaPatch.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BombaPatch.API v1"));
            }
            // protocolo https
            app.UseHttpsRedirection();
            // https://localhost:7088;
           
            app.UseRouting(); //vai retornar o controller baseado em determinada rota (2)

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>     //aqui retorna os endpoints(3)
            {
                endpoints.MapControllers();
            });
        }
    }
}