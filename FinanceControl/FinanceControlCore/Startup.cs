using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanceControl.Infrastructure;
using FinanceControl.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FinanceControl
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => {
                options.EnableEndpointRouting = false;
            });

            services.AddDbContext<FinanceControlContext>(options => {   
                options.UseSqlServer(Configuration.GetConnectionString("FinanceControlContext"));
            });

            services.AddTransient<ISpentService, SpentService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
            
        }
    }
}
