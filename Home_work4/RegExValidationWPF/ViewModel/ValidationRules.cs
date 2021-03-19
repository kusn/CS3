using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace RegExValidationWPF.ViewModel
{
    public class LoginValidationRule : ValidationRule
    {
        Regex regex = new Regex(@"^([a-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$");

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string login = value.ToString();
            if (!regex.IsMatch(login)) return new ValidationResult(false, "Неверный формат!");
            return new ValidationResult(true, null);
        }
    }
}
