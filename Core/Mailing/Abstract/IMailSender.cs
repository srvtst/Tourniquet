using Core.Mailing.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mailing.Abstract
{
    public interface IMailSender
    {
        Task SendMailAsync(IMailMessage mailMessage);
    }
}