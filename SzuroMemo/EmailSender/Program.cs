using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SzuroMemo.Dal;
using SzuroMemo.Dal.Services;

namespace EmailSender
{
    class Program
    {
        public static IConfigurationRoot Configuration { get; set; }

        static void Main(string[] args)
        {
            var devEnvironmentVariable = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");
            var isDevelopment = string.IsNullOrEmpty(devEnvironmentVariable) || devEnvironmentVariable.ToLower() == "development";

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddUserSecrets<GridSecret>()
                .AddEnvironmentVariables();

            if (isDevelopment) //only add secrets in development
            {
                builder.AddUserSecrets<GridSecret>();
            }

            Configuration = builder.Build();

            var services = new ServiceCollection()
                .Configure<GridSecret>(Configuration.GetSection(nameof(GridSecret)))
                .AddOptions()
                .BuildServiceProvider();

            

            var task = new WeeklyTask(services.GetService<IOptions<GridSecret>>());
            task.ExecuteAsync().GetAwaiter().GetResult();
        }
    }
}
