using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender
{
    public static class SmtpServersClass
    {
        public static Dictionary<string, int> Servers
        {
            get { return dicServers; }
        }

        private static Dictionary<string, int> dicServers = new Dictionary<string, int>()
        {
            {"smtp.yandex.ru", 465 },
            {"smtp.gmail.com", 465 },
            {"smtp.mail.ru", 465 },
            {"smtp.rambler.ru", 465 }
        };
    }
}
