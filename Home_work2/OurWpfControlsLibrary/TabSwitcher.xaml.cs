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

namespace OurWpfControlsLibrary
{
    /// <summary>
    /// Interaction logic for TabSwitcher.xaml
    /// </summary>
    public partial class TabSwitcher : UserControl
    {
        public TabSwitcher()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty PrevTextProperty = DependencyProperty.Register("PrevText", typeof(string), typeof(TabSwitcher));
        public string PrevText
        {
            get
            {
                return (string)GetValue(PrevTextProperty);
            }
            set
            {
                SetValue(PrevTextProperty, value);
            }
        }

        public static readonly DependencyProperty NextTextProperty = DependencyProperty.Register("NextText", typeof(string), typeof(TabSwitcher));
        public string NextText
        {
            get
            {
                return (string)GetValue(NextTextProperty);
            }
            set
            {
                SetValue(NextTextProperty, value);
            }
        }

        protected override void OnContentChanged(object oldContent, object newContent)
        {
            if (oldContent != null)
                throw new InvalidOperationException("You can't change Content!");
        }

        public static readonly RoutedEvent btnPrevClickEvent = EventManager.RegisterRoutedEvent("btnPrevClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(TabSwitcher));
        public static readonly RoutedEvent btnNextClickEvent = EventManager.RegisterRoutedEvent("btnNextClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(TabSwitcher));

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {           
            e.Handled = true;
            RoutedEventArgs args = new RoutedEventArgs(btnPrevClickEvent);
            RaiseEvent(args);
        }

        public event RoutedEventHandler btnPrevClick
        {
            add { AddHandler(btnPrevClickEvent, value); }
            remove { RemoveHandler(btnPrevClickEvent, value); }
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            RoutedEventArgs args = new RoutedEventArgs(btnNextClickEvent);
            RaiseEvent(args);
        }

        public event RoutedEventHandler btnNextClick
        {
            add { AddHandler(btnNextClickEvent, value); }
            remove { RemoveHandler(btnNextClickEvent, value); }
        }
    }
}
