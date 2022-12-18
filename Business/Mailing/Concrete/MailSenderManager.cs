using Business.Mailing.Abstract;
using Microsoft.Extensions.Configuration;
using System.Net.Mail;
using System.Net;

namespace Business.Mailing.Concrete
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

        public void SendMail(string fromAddress,  string body)
        {
            var mailMessageData = new MailMessage
            {
                Subject = "Tourniquet",
                Body = body,
                From = new MailAddress(_smtpConfig.UserName),
            };

            mailMessageData.To.Add(new MailAddress(fromAddress));

            SmtpClient smtpClient = new SmtpClient
            {
                Host = _smtpConfig.Host,
                Port = _smtpConfig.Port,
                EnableSsl = _smtpConfig.EnableSsl,
                Credentials = new NetworkCredential(_smtpConfig.UserName, _smtpConfig.Password),
                UseDefaultCredentials = false,
            };

            smtpClient.Send(mailMessageData);
        }
    }
}