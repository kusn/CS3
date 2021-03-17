using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaesarsСipher;

namespace CaesarsCipherApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите пароль:");
            string password = Console.ReadLine();
            string c_pass = CodePassword.getCodPassword(password);
            Console.WriteLine("Зашифрованный пароль:");
            Console.WriteLine(c_pass);
            Console.WriteLine("Расшифрованный пароль:");
            Console.WriteLine(CodePassword.getPassword(c_pass));
            Console.ReadLine();
        }
    }
}
