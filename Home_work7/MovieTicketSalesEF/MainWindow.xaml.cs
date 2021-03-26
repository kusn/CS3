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
using Microsoft.Reporting.WinForms;
using System.Data.Entity.Core.Objects;

namespace MovieTicketSalesEF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MovieDBContainer _dbContainer;

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = _dbContainer;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _dbContainer = new MovieDBContainer();
            _dbContainer.Seances.Load();
            Grid.ItemsSource = _dbContainer.Seances.Local;
        }

        private void btnAddSeance_Click(object sender, RoutedEventArgs e)
        {
            WndAddSeance wndAddSeance = new WndAddSeance();
            //wndAddSeance.Show();

            if (wndAddSeance.ShowDialog() == true)
            {
                _dbContainer.Seances.Load();
                Grid.Items.Refresh();
            }
        }

        private void cmmiBuy_Click(object sender, RoutedEventArgs e)
        {
            WndBuy wndBuy = new WndBuy();
            wndBuy.Show();
            //wndBuy.ShowDialog();
        }
    }
}
