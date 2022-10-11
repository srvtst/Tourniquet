using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mailing.Abstract
{
    public interface IMailMessage
    {
        //e-posta iletisinin alıcılarını içeren adres koleksiyonu
        string To { get; }
        string From { get; }
        string Subject { get; }
        string Body { get; }
    }
}