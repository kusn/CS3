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

namespace EmailSendExample
{
    /// <summary>
    /// Логика взаимодействия для UserControlTest.xaml
    /// </summary>
    public partial class UserControlTest : UserControl
    {
        public UserControlTest()
        {
            InitializeComponent();
        }

        private void SomeClicked(object sender, MouseButtonEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(Button.ClickEvent, this));
            //throw new NotImplementedException();
        }
    }
}
