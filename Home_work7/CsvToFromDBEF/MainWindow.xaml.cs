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
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.IO;

namespace CsvToFromDBEF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ContactsDBContainer _dBContainer;
        List<Contact> contactList = new List<Contact>();
        List<Contact> contactListToExport = new List<Contact>();
        string fileName = "..\\..\\Example.csv";

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = _dBContainer;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _dBContainer = new ContactsDBContainer();
            _dBContainer.ContactDBSet.Load();
            dgContacts.ItemsSource = _dBContainer.ContactDBSet.Local;
        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            Import();
            foreach(var contact in contactList)
            {                
                _dBContainer.ContactDBSet.Add(new ContactDB { Name = contact.Name, Email = contact.Email, Phone = contact.Phone });
                _dBContainer.SaveChanges();
            }
            _dBContainer.ContactDBSet.Load();
            dgContacts.Items.Refresh();
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            Export();
        }

        private void Import()
        {
            using(StreamReader sr = new StreamReader(fileName))
            {
                while(!sr.EndOfStream)
                {                    
                    string[] str = sr.ReadLine().Split(';');
                    Contact contact = new Contact { Name = str[0], Email = str[1], Phone = str[2] };
                    contactList.Add(contact);
                }
            }
        }

        private void Export()
        {
            using(StreamWriter sw = new StreamWriter(fileName, false, Encoding.Default))
            {
                List<ContactDB> contactDBList = new List<ContactDB>();
                contactDBList = _dBContainer.ContactDBSet.ToList();
                
                foreach(var v in contactDBList)
                    sw.WriteLine(v.Name + ";" + v.Email + ";" + v.Phone);
            }
        }

        private void cmiEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cmiRemove_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
