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
        IMailMessage _mailMessage;
        public MailSenderManager(IConfiguration configuration , IMailMessage mailMessage)
        {
            _configuration = configuration;
            _mailMessage = mailMessage;
            _smtpConfig = _configuration.GetSection("Smtp").Get<SmtpConfig>();
        }

        public async Task SendMail(IMailMessage mailMessage)
        {
            var mailMessageData = new MailMessage
            {
                Subject = _mailMessage.Subject,
                Body = _mailMessage.Body,
                From = new MailAddress(_mailMessage.From),
            };

            mailMessageData.To.Add(_mailMessage.To);

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