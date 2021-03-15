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
                return new DelegateCommand(MIExitExecute, MIExitCanExecute);
            }
        }

        private void MIExitExecute(object obj)
        {
        }

        private bool MIExitCanExecute(object obj)
        {
            return true;
        }
    }
}
