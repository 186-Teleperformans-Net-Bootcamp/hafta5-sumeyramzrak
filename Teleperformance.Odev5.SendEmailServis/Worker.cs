
using Hangfire;
using MailKit.Net.Smtp;
using MimeKit;
using Teleperformance.Odev4.Services.Abstractions;

namespace Teleperformance.Odev5.SendEmailServis
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IUserService service;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);

                RecurringJob.AddOrUpdate(()=>SendEmail(), "35 7 * * MON - FRI"); //Hafta içi her sabah 07.35 de mail atsýn
            }
            Console.ReadKey();
        }
       
    public void SendEmail()
        {
            var userList = service.GetAllUsers();
            var content = "";
            foreach (var user in userList)
            {
                content = content + user.UserName;
            }

            var mailMessage = new MimeMessage();
            mailMessage.From.Add(new MailboxAddress("from name", "gönderici mail adresi"));
            mailMessage.To.Add(new MailboxAddress("to name", "alýcý mail adresi"));
            mailMessage.Subject = "User List";
            mailMessage.Body = new TextPart()
            {
                Text = content  
            };

            using (var smtpClient = new SmtpClient())
            {
                smtpClient.Connect("gönderici mail adresi", 587, true);
                smtpClient.Authenticate("user", "password");
                smtpClient.Send(mailMessage);
                smtpClient.Disconnect(true);
            }
        }
       

    }

    
  

}