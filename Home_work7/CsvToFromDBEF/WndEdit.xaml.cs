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
using System.Windows.Shapes;
using System.ComponentModel;

namespace CsvToFromDBEF
{
    /// <summary>
    /// Логика взаимодействия для WndEdit.xaml
    /// </summary>
    public partial class WndEdit : Window, INotifyPropertyChanged
    {
        ContactsDBContainer _dBContainer;
        public event PropertyChangedEventHandler PropertyChanged;
        static int ID;

        public WndEdit(int n)
        {
            InitializeComponent();
            ID = n;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _dBContainer = new ContactsDBContainer();
            tbName.Text = _dBContainer.ContactDBSet.Find(ID).Name;
            tbEmail.Text = _dBContainer.ContactDBSet.Find(ID).Email;
            tbPhone.Text = _dBContainer.ContactDBSet.Find(ID).Phone;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            _dBContainer.ContactDBSet.Find(ID).Name = tbName.Text;
            _dBContainer.ContactDBSet.Find(ID).Email = tbEmail.Text;
            _dBContainer.ContactDBSet.Find(ID).Phone = tbPhone.Text;

            if (_dBContainer.SaveChanges() != 0)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("_dBContainer.ContactDBSet.Find(ID).Name")); //? Как включить реакцию на изменения в Базе
                MessageBox.Show("Изменения внесены");
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Изменения не внесены!");
                this.DialogResult = false;
            }
        }
    }
}
