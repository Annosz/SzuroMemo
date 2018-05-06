using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SzuroMemo.Dal;
using SzuroMemo.Dal.Entities;
using SzuroMemo.Dal.Seed;
using SzuroMemo.Dal.Services;

namespace SzuroMemo.Web
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
            services.AddDbContext<SzuroMemoDbContext>(
                o => o.UseSqlServer(Configuration.GetConnectionString(nameof(SzuroMemoDbContext))));
            services.AddTransient<ScreeningDataSeeder>();
            services.AddTransient<SzuroMemoSeedData>();
            services.AddTransient<AdministratorSeeder>();

            services.AddScoped<OccasionService>();
            services.AddScoped<ScreeningService>();
            services.AddScoped<ScreeningHeaderService>();

            services.AddIdentity<User, IdentityRole<int>>()
                .AddEntityFrameworkStores<SzuroMemoDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc()
                .AddRazorPagesOptions(options =>
                {
                    options.Conventions.AddPageRoute("/Index", "Fooldal");
                    options.Conventions.AddPageRoute("/Screenings", "Ismertetok");
                    options.Conventions.AddPageRoute("/Occasions", "Aktualis_szuresek");
                    options.Conventions.AddPageRoute("/Account/Login", "Bejelentkezes");
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
        }
    }
}
