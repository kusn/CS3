using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace WpfTestMailSender
{
    public class EmailSendServiceClass
    {
        WpfMailSender mailSender = new WpfMailSender();

        List<string> listStrMails;
        string sendTest;
        string strPassword;
        string smtpClient;
        int port;

        public EmailSendServiceClass(WpfMailSender mlSender)
        {
            mailSender = mlSender;
            listStrMails = new List<string> { "testEmail@gmail.com", "email@yandex.ru" };  // Список email'ов //кому мы отправляем письмо
            strPassword = mailSender.passwordBox.Password;  // для WinForms - string strPassword = passwordBox.Text;
            smtpClient = TestMailOptions.SmtpClient;
            port = TestMailOptions.Port;
            sendTest = TestMailOptions.Sender;            
        }

        public void Start()
        {
            foreach (string mail in listStrMails)
            {
                // Используем using, чтобы гарантированно удалить объект MailMessage после использования
                using (MailMessage mm = new MailMessage(sendTest, mail))
                {
                    // Формируем письмо
                    mm.Subject = mailSender.tbName.Text; // Заголовок письма
                    mm.Body = mailSender.tbBody.Text;       // Тело письма
                    mm.IsBodyHtml = false;           // Не используем html в теле письма
                                                     // Авторизуемся на smtp-сервере и отправляем письмо
                                                     // Оператор using гарантирует вызов метода Dispose, даже если при вызове 
                                                     // методов в объекте происходит исключение.
                    using (SmtpClient sc = new SmtpClient(smtpClient, port))
                    {
                        sc.EnableSsl = true;
                        sc.Credentials = new NetworkCredential(sendTest, strPassword);
                        try
                        {
                            sc.Send(mm);
                        }
                        catch (Exception ex)
                        {
                            MessageBoxMailSender messageBoxMailSender = new MessageBoxMailSender();
                            messageBoxMailSender.txtBlockSendEnd.Text = "Невозможно отправить письмо " + ex.ToString();
                            messageBoxMailSender.ShowDialog();
                        }
                    }
                } //using (MailMessage mm = new MailMessage("sender@yandex.ru", mail))
            }
            SendEndWindow sew = new SendEndWindow();
            sew.ShowDialog();
        }
    }
}
