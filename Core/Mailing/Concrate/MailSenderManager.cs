using Core.Mailing.Abstract;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mailing.Concrate
{
    public class MailSenderManager : IMailSender

    {
        IConfiguration _configuration;
        SmtpConfig _smtpConfig;
        IMailMessage _mailMessage;
        public MailSenderManager(IConfiguration configuration)
        {
            _configuration = configuration;
            _smtpConfig = _configuration.GetSection("Smtp").Get<SmtpConfig>();
        }

        public async Task SendMailAsync(IMailMessage mailMessage)
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