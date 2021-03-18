using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;

namespace MailerMVVM.ViewModel
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand TSBtnPrevClic
        {
            get
            {
                return new DelegateCommand(TSBtnPrevExecute, TSBtnPrevCanExecute);
            }
        }

        private void TSBtnPrevExecute(object obj)
        {
        }

        private bool TSBtnPrevCanExecute(object obj)
        {
            return true;
        }

        public ICommand MIExitClick
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    (obj as MainWindow).Close();
                }, (obj) => true);
            }
        }

        public ICommand MITaskClick
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    View.TaskWindow taskWindow = new View.TaskWindow();
                    taskWindow.Show();
                }, (obj) => true);
            }
        }

        public ICommand MIAboutClick
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    View.AboutWindow aboutWindow = new View.AboutWindow();
                    aboutWindow.Show();
                }, (obj) => true);
            }
        }
    }
}
