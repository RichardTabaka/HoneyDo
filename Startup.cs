using HoneyDo.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HoneyDo.Data;
using HoneyDo.Models;

namespace HoneyDo
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
            services.AddMvc(x => x.EnableEndpointRouting = false);
            services.AddControllersWithViews();
            services.AddSingleton<IToDoList, ToDoList>();

            // Add EF6 DB:
            services.AddDbContext<HiveContext>(options => options.UseSqlite("Data Source=hive.db"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, HiveContext hiveContext) // Pass instance of HiveContext for DB Shenanigans
        {
            app.UseDeveloperExceptionPage();

            app.UseStaticFiles();

            app.UseMvc(
                    routes =>
                    {
                        routes.MapRoute(
                            "Default",
                            "{controller=Home}/{action=HomeIndex}/{id?}"
                            );
                    }

                );

            app.Run(async (context) => { await context.Response.WriteAsync("No route matched"); });


            // DB Shenanigans:
            hiveContext.Database.EnsureDeleted();
            hiveContext.Database.EnsureCreated();
        }
    }
}
