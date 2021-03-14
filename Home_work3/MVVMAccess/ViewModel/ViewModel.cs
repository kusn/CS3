using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace MVVMAccess.ViewModel
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region Публичное свойство для привязки Account
        public Model.Account Account { get; set; } = new Model.Account("None", "None");

        public int AttemptCount 
        { 
            get
            {
                return Model.AccessToApp.Attempt;
            } 
        }
        #endregion

        public bool Access
        {
            get
            {
                return Model.AccessToApp.Checks(Account);
            }            
        }


        private void Execute(object obj)
        {
            //Проверяем есть ли такой аккаунт в базе данных
            MVVMAccess.Model.AccessToApp.Checks(Account);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AttemptCount"));
            if (Access)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Access"));
                MessageBox.Show("Логин и пароль введены верно!");
            }            
        }

        private bool CanExecute(object obj)
        {
            return MVVMAccess.Model.AccessToApp.Attempt < 3;
        }

        public ICommand ClickAccess
        {
            get
            {
                return new DelegateCommand(Execute, CanExecute);
            }
        }

        public ICommand ClickClearLogin
        {
            get
            {
                return new DelegateCommand(ClearLoginExecute, ClearLoginCanExecute);
            }
        }

        private void ClearLoginExecute(object obj)
        {
            Account.Login = "";           
        }

        private bool ClearLoginCanExecute(object obj)
        {
            return Account.Login != "";
        }
        
        public ICommand ClickClearPassword
        {
            get
            {
                return new DelegateCommand(ClearPasswordExecute, ClearPasswordCanExecute);
            }
        }

        private void ClearPasswordExecute(object obj)
        {            
            Account.Password = "";
        }

        private bool ClearPasswordCanExecute(object obj)
        {
            return Account.Password != "";
        }
    }
}
