// Кудряшов Сергей

// 2. Написать класс с методами шифрования и дешифровки строки данных (например используя шифр Цезаря - побуквенный сдвиг всех символов
// на один). Создать для класса Unit тесты, которые будут проверять работу методов.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarsСipher
{
    public class CodePassword
    {
        public static string getPassword(string p_sPassw)
        {
            string password = "";
            foreach (char a in p_sPassw)
            {
                char ch = a;
                ch--;
                password += ch;
            }

            return password;
        }
        /// <summary>
        /// На вход подаем пароль, на выходе получаем зашифрованный пароль
        /// </summary>
        /// <param name="p_sPassword"></param>
        /// <returns></returns>
        public static string getCodPassword(string p_sPassword)
        {
            string sCode = "";
            foreach (char a in p_sPassword)
            {
                char ch = a;
                ch++;
                sCode += ch;
            }
            return sCode;
        }
    }
}
