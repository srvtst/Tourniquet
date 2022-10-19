using Core.Mailing.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mailing.Abstract
{
    public interface IMailSender
    {
        Task SendMail(MailMessage mailMessage);
    }
}