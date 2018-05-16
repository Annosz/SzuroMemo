using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SzuroMemo.Dal;
using SzuroMemo.Dal.Entities;
using SzuroMemo.Dal.Seed;
using SzuroMemo.Dal.Services;
using SzuroMemo.Dal.OData;
using SzuroMemo.Services;
using SzuroMemo.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;

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
            services.AddScoped<MedicalRecordService>();
            services.AddScoped<RegistrationService>();
            services.AddScoped<HospitalHeaderService>();


            services.AddIdentity<User, IdentityRole<int>>(config =>
            {
                config.SignIn.RequireConfirmedEmail = true;
            })
                .AddEntityFrameworkStores<SzuroMemoDbContext>()
                .AddDefaultTokenProviders();
            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new RequireHttpsAttribute());
            });
            services.AddAuthentication().AddGoogle(googleOptions =>
            {
                googleOptions.ClientId = Configuration["Authentication:Google:ClientId"];
                googleOptions.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
            });
            services.AddAuthentication().AddFacebook(facebookOptions =>
            {
                facebookOptions.AppId = Configuration["Authentication:Facebook:AppId"];
                facebookOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
            });
            services.AddSingleton<IEmailSender, EmailSender>();
            services.Configure<AuthMessageSenderOptions>(Configuration);

            services.AddOData();
            services.AddTransient<OccasionsModelBuilder>();

            services.AddMvc()
                .AddRazorPagesOptions(options =>
                {
                    options.Conventions.AddPageRoute("/Index", "Fooldal");
                    options.Conventions.AddPageRoute("/Screenings", "Ismertetok");
                    options.Conventions.AddPageRoute("/Occasions", "Aktualis_szuresek");
                    options.Conventions.AddPageRoute("/Account/Login", "Bejelentkezes");
                    options.Conventions.AddPageRoute("/Account/Personal/Profile", "Profilom");
                    options.Conventions.AddPageRoute("/Account/Personal/Details", "Adataim");
                    options.Conventions.AddPageRoute("/Account/Personal/Calendar", "Naptaram");
                    options.Conventions.AddPageRoute("/NewOccasion", "Uj_szures");
                    options.Conventions.AddPageRoute("/Occasion", "Szures");

                    options.Conventions.AuthorizeFolder("/Account/Manage");
                    options.Conventions.AuthorizePage("/Account/Logout");
                })
                .AddJsonOptions(opt =>
                {
                    opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, OccasionsModelBuilder modelBuilder)
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

            var options = new RewriteOptions().AddRedirectToHttps();
            app.UseRewriter(options);

            app.UseAuthentication();

            app.UseMvc(routeBuilder =>
            {
                routeBuilder.MapODataServiceRoute("ODataRoutes", "odata", modelBuilder.GetEdmModel(app.ApplicationServices));
            }
            /*routes =>
        {
            routes.MapRoute(
                name: "default",
                template: "{controller}/{action=Index}/{id?}");
        }*/);
        }
    }
}
