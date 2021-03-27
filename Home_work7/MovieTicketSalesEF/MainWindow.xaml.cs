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
using System.Windows.Forms.Integration;

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
            ReportViewer.Load += ReportViewer_Load;
        }

        private void ReportViewer_Load(object sender, EventArgs e)
        {
            ReportDataSource reportDataSource = new ReportDataSource();
            MovieDBDataSet dataSet = new MovieDBDataSet();
            //_Database_mdfDataSet dataset = new _Database_mdfDataSet();
            dataSet.BeginInit();
            reportDataSource.Name = "DataSet";
            reportDataSource.Value = dataSet.Orders;
            ReportViewer.LocalReport.DataSources.Add(reportDataSource);
            ReportViewer.LocalReport.ReportPath = "../../Report.rdlc";
            dataSet.EndInit();
            MovieDBDataSetTableAdapters.OrdersTableAdapter ordersTableAdapter = new MovieDBDataSetTableAdapters.OrdersTableAdapter { ClearBeforeFill = true };            
            ordersTableAdapter.Fill(dataSet.Orders);
            ReportViewer.RefreshReport();
        }

        private void btnAddSeance_Click(object sender, RoutedEventArgs e)
        {
            WndAddSeance wndAddSeance = new WndAddSeance();

            if (wndAddSeance.ShowDialog() == true)
            {
                _dbContainer.Seances.Load();
                Grid.Items.Refresh();
            }
        }

        private void cmmiBuy_Click(object sender, RoutedEventArgs e)
        {
            Seance seance = new Seance();
            seance = (Seance)Grid.SelectedItem;            
            new WndBuy(seance.SeanceId).ShowDialog();
        }

        private void btnDelSeance_Click(object sender, RoutedEventArgs e)
        {
            Seance seance = new Seance();
            seance = (Seance)Grid.SelectedItem;
            if (seance == null)
                MessageBox.Show("Выберите сеанс");
            else
            {
                _dbContainer.Seances.Remove(seance);
                if (_dbContainer.SaveChanges() != 0)
                {
                    MessageBox.Show("Сеанс удалён!");
                    _dbContainer.Seances.Load();
                    Grid.Items.Refresh();
                }
            }
        }
    }
}
