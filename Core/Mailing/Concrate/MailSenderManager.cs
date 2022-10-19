using Core.Mailing.Abstract;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace Core.Mailing.Concrate
{
    public class MailSenderManager : IMailSender
    {
        IConfiguration _configuration;
        SmtpConfig _smtpConfig;
        public MailSenderManager(IConfiguration configuration)
        {
            _configuration = configuration;
            _smtpConfig = _configuration.GetSection("Smtp").Get<SmtpConfig>();
        }

        public async Task SendMail(MailMessage mailMessage)
        {
            var mailMessageData = new MailMessage
            {
                Subject = mailMessage.Subject,
                Body = mailMessage.Body,
                From = new MailAddress(""),
            };

            mailMessageData.To.Add("");

            SmtpClient smtpClient = new SmtpClient
            {
                Host = _smtpConfig.Host,
                Port = _smtpConfig.Port,
                //ssl kullanıp kullanılmayacağını belirtiyoruz.
                EnableSsl = _smtpConfig.UseSSL,
                //mail gönderenin kimlik doğrulaması.
                Credentials = new NetworkCredential(_smtpConfig.UserName, _smtpConfig.Password)
            };
            await smtpClient.SendMailAsync(mailMessageData);
        }
    }
}