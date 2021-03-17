using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace MVVMAccess.ViewModel
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
        Regex regex = new Regex(@"^[a-zA-Z][a-zA-Z0-9-_\.]{1,20}$");

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string login = value.ToString();
            if (!regex.IsMatch(login)) return new ValidationResult(false, "ограничение 2-20 символов, которыми могут быть буквы и цифры, первый обязятельно буква");
            return new ValidationResult(true, null);
        }
    }
}
