using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTestMailSender
{
    public static class TestMailOptions
    {
        static string smtp = "smtp.yandex.ru";
        static int port = 25;
        static string sender = "sender@yandex.ru";

        public static string SmtpClient
        {
            get
            {
                return smtp;
            }
            set
            {
                smtp = value;
            }            
        }
        public static int Port
        {
            get
            {
                return port;
            }
            set
            {
                port = value;
            }
        }
        public static string Sender
        {
            get
            {
                return sender;
            }
            set
            {
                sender = value;
            }
        }
    }
}
