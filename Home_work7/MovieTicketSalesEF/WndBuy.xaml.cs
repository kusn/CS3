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
    /// Логика взаимодействия для WndBuy.xaml
    /// </summary>
    public partial class WndBuy : Window
    {
        MovieDBContainer _dbContainer;
        int ID;

        public WndBuy(int Id)
        {
            InitializeComponent();
            _dbContainer = new MovieDBContainer();
            _dbContainer.Seances.Load();
            //_dbContainer.Orders.Load();
            ID = Id;
            //MessageBox.Show(_dbContainer.Seances.Find(Id).MovieName);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tblName.Text = _dbContainer.Seances.Find(ID).MovieName;
            tblTime.Text = _dbContainer.Seances.Find(ID).SeanceTime.ToString();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _dbContainer.Orders.Add(new Order { OrderTime = DateTime.Now.TimeOfDay, SeanceSeanceId = ID, TiketsCount = Convert.ToInt32(tbCount.Text) });
                //_dbContainer.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Ошибка введённых данных");
            }

            if (_dbContainer.SaveChanges() != 0)
            {
                MessageBox.Show("Заказ оформлен");
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Заказ не оформлен!");
                this.DialogResult = false;
            }
        }
    }
}
