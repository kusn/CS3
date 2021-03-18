using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace MailerMVVM.ViewModel
{
    public class PasswordValidationRule : ValidationRule
    {
        Regex regex = new Regex(@"(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n})(?=.*[A-Z])(?=.*[a-z]).*$");

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string password = value.ToString();
            if (!regex.IsMatch(password)) return new ValidationResult(false, "от 6 символов с использованием цифр, спец. символов, латиницы, начиная с прописных символов");
            return new ValidationResult(true, null);
        }
    }

    public class LoginValidationRule : ValidationRule
    {
        Regex regex = new Regex(@"^([a-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$");

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string login = value.ToString();
            if (!regex.IsMatch(login)) return new ValidationResult(false, "Неверный формат строки");
            return new ValidationResult(true, null);
        }
    }
}
