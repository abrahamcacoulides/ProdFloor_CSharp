using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ProdFloor.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ProdFloor
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
                Configuration["Data:ProdFloorJobs:ConnectionString"]));
            services.AddTransient<IJobRepository, EFJobRepository>();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvc(routes => {

                routes.MapRoute(
                    name: null,
                    template: "{jobType}/Page{jobPage:int}",
                    defaults: new { controller = "Job", action = "List" }
                );

                routes.MapRoute(
                    name: null,
                    template: "Page{jobPage:int}",
                    defaults: new{ controller = "Job", action = "List",
                        jobPage = 1 }
                );

                routes.MapRoute(
                    name: null,
                    template: "{jobType}",
                    defaults: new { controller = "Job", action = "List",
                        jobPage = 1 }
                );

                routes.MapRoute(
                    name: null,
                    template: "",
                    defaults: new { controller = "Job", action = "List",
                        jobPage = 1 });

                routes.MapRoute(name: null, template: "{controller}/{action}/{id?}");
            });
            SeedData.EnsurePopulated(app);
        }
    }
}
