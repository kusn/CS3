using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MailSender
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class WpfMailSender : Window
    {
        public WpfMailSender()
        {
            InitializeComponent();
            cbSenderSelect.ItemsSource = VariablesClass.Senders;
            cbSenderSelect.DisplayMemberPath = "Key";
            cbSenderSelect.SelectedValuePath = "Value";

            cbSmtpSelect.ItemsSource = SmtpServersClass.Servers;
            cbSmtpSelect.DisplayMemberPath = "Key";
            cbSmtpSelect.SelectedValuePath = "Value";

            DBclass db = new DBclass();
            dgEmails.ItemsSource = db.Emails;
        }

        private void mniClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnClock_Click(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedItem = tabPlanner;
        }

        private void btnSendAtOnce_Click(object sender, RoutedEventArgs e)
        {
            string strLogin = cbSenderSelect.Text;
            string strPassword;
            TextRange textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);

            if (textRange.Text == "\r\n") //Проверка заполнености письма
            {
                MessageBox.Show("Письмо не заполнено");
                tabControl.SelectedItem = tabEditText;
                return;
            }

            try
            {
                strPassword = cbSenderSelect.SelectedValue.ToString();
            }
            catch
            {
                MessageBox.Show("Выберите отправителя");
                return;
            }
            
            /*if (string.IsNullOrEmpty(strLogin))
            {
                MessageBox.Show("Выберите отправителя");
                return;
            }*/
            if (string.IsNullOrEmpty(strPassword))
            {
                MessageBox.Show("Укажите пароль отправителя");
                return;
            }

            EmailSendServiceClass emailSender = new EmailSendServiceClass(strLogin, strPassword);
            emailSender.Smtp = cbSmtpSelect.SelectedItem.ToString();
            emailSender.Port = SmtpServersClass.Servers[cbSmtpSelect.SelectedItem.ToString()];
            emailSender.SendMails((IQueryable<Emails>)dgEmails.ItemsSource);
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            SchedulerClass sc = new SchedulerClass();
            TimeSpan tsSendTime = sc.GetSendTime(timePiker.Text);   //Заменил TextBlock на TimePiker
            TextRange textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);

            if (textRange.Text == "\r\n")   //Проверка заполнености письма
            {
                MessageBox.Show("Письмо не заполнено");
                tabControl.SelectedItem = tabEditText;
                return;
            }

            if (tsSendTime == new TimeSpan())
            {
                MessageBox.Show("Некорректный формат даты");
                return;
            }
            DateTime dtSendDateTime = (cldSchedulDateTimes.SelectedDate ?? DateTime.Today).Add(tsSendTime);
            if (dtSendDateTime < DateTime.Now)
            {
                MessageBox.Show("Дата и время отправки писем не могут быть раньше, чем настоящее время");
                return;
            }
            EmailSendServiceClass emailSender = new EmailSendServiceClass(cbSenderSelect.Text, cbSenderSelect.SelectedValue.ToString());
            sc.SendEmails(dtSendDateTime, emailSender, (IQueryable<Emails>)dgEmails.ItemsSource);
        }

        private void tscTabSwitcher_btnNextClick(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 1;
        }

        private void tscTabSwitcher_btnPreviousClick(object sender, RoutedEventArgs e)
        {

        }        
    }
}
