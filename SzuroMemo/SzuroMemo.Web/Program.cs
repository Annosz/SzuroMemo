using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Win32.TaskScheduler;
using SzuroMemo.Dal;
using SzuroMemo.Dal.Extensions;
using SzuroMemo.Dal.Seed;
using SzuroMemo.Web.Extensions;
using SzuroMemo.Web.Ssl;

namespace SzuroMemo.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args)
                .MigrateDatabase<SzuroMemoDbContext>()
                .Seed<ScreeningDataSeeder, SzuroMemoDbContext, SzuroMemoSeedData>()
                .SeedAdministrator()
                .ScheduleEmails()
                .Run();
        }


        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseKestrel(options => options.ConfigureEndpoints())
                .Build();
    }
}
