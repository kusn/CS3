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
using System.Data.Entity;

namespace MovieTicketSalesEF
{
    /// <summary>
    /// Логика взаимодействия для WndAddSeance.xaml
    /// </summary>
    public partial class WndAddSeance : Window
    {
        MovieDBContainer _dbContainer;

        public WndAddSeance()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbName.Text) && !string.IsNullOrWhiteSpace(tpTime.Text))
            {
                _dbContainer.Seances.Add(new Seance { MovieName = tbName.Text, SeanceTime = tpTime.TimeInterval });
                if (_dbContainer.SaveChanges() != 0)
                {
                    MessageBox.Show("Сеанс добавлен!");
                    this.DialogResult = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Сеанс не добавлен");
                    this.DialogResult = false;
                }
            }
            else
                MessageBox.Show("Не все поля заполнены");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _dbContainer = new MovieDBContainer();
        }
    }
}
