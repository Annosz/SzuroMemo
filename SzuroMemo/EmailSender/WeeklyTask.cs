using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SzuroMemo.Dal;
using SzuroMemo.Dal.Services;

namespace EmailSender
{
    public class WeeklyTask
    {

        public WeeklyTask(IOptions<GridSecret> secrets)
        {
            Secrets = secrets.Value;
        }


        private readonly GridSecret Secrets;

        public async System.Threading.Tasks.Task ExecuteAsync()
        {
            var optionsBuilder = new DbContextOptionsBuilder<SzuroMemoDbContext>();
            optionsBuilder.UseSqlServer(Secrets.SzuroMemoDbContext);

            using (SzuroMemoDbContext ctx = new SzuroMemoDbContext(optionsBuilder.Options))
            {
                var users = ctx.Users.Select(u => new { id = u.Id, email = u.Email });

                RegistrationService registrationService = new RegistrationService(ctx);

                foreach (var user in users)
                {
                    var occasions = registrationService.GetOccasionsToUser(user.id).Where(o => o.StartTime >= DateTime.Now && o.StartTime <= DateTime.Now.AddDays(14));

                    if (occasions.Any())
                    {
                        string occasionList = String.Join('\n', occasions.Select(o => "* " + o.Screening + " a következő kórházban: " + o.Hospital));

                        var client = new SendGridClient(Secrets.SendGridKey);
                        var msg = new SendGridMessage()
                        {
                            From = new EmailAddress("emlekezteto@szuromemo.hu", "Szűrőmemo Emlékeztető"),
                            Subject = "Szűrővizsgálatokra jelentkezett a következ két hétre",
                            PlainTextContent =
                            "Kedves SzűrőMemo Felhasználó,\n" +
                            "\n" +
                            "Ön a következő hétre ezeket a szűrővizsgálatokat helyezte a naptárába:\n" +
                            occasionList +
                            "\n" +
                            "Reméljük minél többre sikerül ellátogatnia, egészsége megőrzése végett!\n" +
                            "További szűrővizsgálatokat és alkalmakat találhat magána a www.szuromemo.hu oldalon.\n" +
                            "\n" +
                            "Üdvözlettel,\n" +
                            "A Szűrőmemo csapata"
                        };
                        msg.AddTo(new EmailAddress(user.email));
                        var Result = await client.SendEmailAsync(msg);
                    }
                }

            }
        }

    }
}
