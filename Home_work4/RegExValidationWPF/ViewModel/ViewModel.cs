using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegExValidationWPF.ViewModel
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region Публичное свойство для привязки Account
        public Model.Account Account { get; set; } = new Model.Account("None", "None");        
        #endregion
    }
}
