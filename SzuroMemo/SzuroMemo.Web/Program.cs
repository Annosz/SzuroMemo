using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SzuroMemo.Dal;
using SzuroMemo.Dal.Extensions;
using SzuroMemo.Dal.Seed;

namespace SzuroMemo.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args)
                .MigrateDatabase<SzuroMemoDbContext>()
                .Seed<ScreeningDataSeeder, SzuroMemoDbContext, SzuroMemoSeedData>()
                .Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
