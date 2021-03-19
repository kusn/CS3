using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegExValidationWPF.Model
{
    public class Account : INotifyPropertyChanged, IDataErrorInfo
    //Нередко модель реализует интерфейсы INotifyPropertyChanged или INotifyCollectionChanged,которые позволяют уведомлять систему об изменениях свойств модели.
    {
        private string login = "None";
        private string password = "None";
        public int Number { get; set; }

        public string Login
        {
            get => login;
            set
            {
                if (value != login)
                {
                    login = value;
                    //Если у элемента OneWayToSource - PropertyChanged.Invoke не обновляет данные    
                    Console.WriteLine("1");
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Login"));
                }
            }
        }
        public string Password
        {
            get => password;
            set
            {
                if (value != password)
                {
                    password = value;
                    //Если у элемента OneWayToSource - PropertyChanged.Invoke не обновляет данные    
                    Console.WriteLine("1");
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Password"));

                    //if (password.Contains(' ')) throw new ArgumentException();
                }
            }
        }

        public string Error { get; private set; }

        public string this[string columnName]
        {
            get
            {
                string Error = String.Empty;
                switch (columnName)
                {
                    case "Login":
                        if ((Login.Length < 2) || (Login.Length > 10))
                        {
                            Error = "Длина логина должна быть от 2 до 10 символов";
                            Console.WriteLine(Error);
                        }
                        break;
                    case "Password":
                        if ((Password.Length < 2) || (Password.Length > 10))
                        {
                            Error = "Длина пароля должна быть от 2 до 10 символов";
                            Console.WriteLine(Error);
                        }
                        Console.WriteLine(Error);
                        break;
                }
                return Error;
            }
        }


        public Account(string login, string password)
        {
            this.login = login;
            this.password = password;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
