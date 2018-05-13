using Microsoft.AspNetCore.Hosting;
using Microsoft.Win32.TaskScheduler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SzuroMemo.Web.Extensions
{
    public static class EmailSchedulerExtensions
    {
        public static IWebHost ScheduleEmails(this IWebHost webHost)
        {
            using (TaskService ts = new TaskService())
            {
                // Remove the task we created previously
                //ts.RootFolder.DeleteTask("SzuroMemoReminder");

                // Create a new task definition and assign properties
                TaskDefinition td = ts.NewTask();
                td.RegistrationInfo.Description = "Sends reminder e-mails to SzuroMemo users";

                // Create a trigger that will fire the task at this time every other day
                td.Triggers.Add(new DailyTrigger { DaysInterval = 7, StartBoundary = DateTime.Now.AddSeconds(5) });

                // Create an action that will send emails
                string runable = Path.Combine(Directory.GetCurrentDirectory(), @"Runable\EmailSender\EmailSender.exe").ToString();
                td.Actions.Add(new ExecAction(runable));

                // Register the task in the root folder
                ts.RootFolder.RegisterTaskDefinition(@"SzuroMemoReminder", td);
            }

            return webHost;
        }
    }
}
