﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAccess.Model
{
    //Класс для логина и пароля
    public class Account : INotifyPropertyChanged
    //Нередко модель реализует интерфейсы INotifyPropertyChanged или INotifyCollectionChanged,которые позволяют уведомлять систему об изменениях свойств модели.
    {
        private string login = "None";
        private string password = "None";

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
                }
            }
        }

        public Account(string login, string password)
        {
            this.login = login;
            this.password = password;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }


    //класс для аккаунтов
    class Accounts
    {
        static List<Account> accounts = new List<Account>() {
                                  new Account("root", "root"),
                                  new Account("login","password"),
                                  new Account("admin","admin")
                                  };

        static public bool Find(Account account)
        {
            foreach (Account acc in Accounts.ListAccounts)
                if (acc.Login == account.Login && acc.Password == account.Password) return true;
            return false;
        }


        //Класс получающий аккаунты - заменить на получение аккаунтов из базы данных (см. пример получения списков емейлов)
        public static IEnumerable<Account> ListAccounts
        {

            get => accounts;
        }

        public static void Add(Account account)
        {

        }

        public static void Remove(Account account)
        {

        }

        public static void RemoveAt(int index)
        {

        }

    }

    public static class AccessToApp
    {
        static bool access = false;
        static public bool Access { get => access; set => access = value; }
        static public int Attempt { get; set; } = 0;


        static public bool Checks(Account account)
        {
            Attempt++;
            return Accounts.Find(account);
        }

    }
}
