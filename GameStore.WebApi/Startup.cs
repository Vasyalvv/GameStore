using GameStore.DAL.Context;
using GameStore.Interfaces.Services;
using GameStore.Service.Data;
using GameStore.Service.Services.InSQL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.WebApi
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
            services.AddTransient<GameStoreDbInitializer>();
            services.AddDbContext<GameStoreDB>(o=>
                o.UseSqlServer(Configuration.GetConnectionString("SqlConnectionString"))
            );

            services.AddTransient<IGameService, SqlGameService>();
            services.AddTransient<IPublisherService, SqlPublisherService>();
            services.AddTransient<IGenreService, SqlGenreService>();
            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, GameStoreDbInitializer db)
        {
            db.Initialize();    //Инициализация БД тестовыми значениями

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
