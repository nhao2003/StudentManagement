using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace StudentManagement.ValidationRules
{
    public class ClassNameValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            String name = (String)value;
            if(name.Length <= 0)
            {
                return new ValidationResult(false, "Tên không được rỗng");
            }
            else if(name.Length >= 8)
            {
                return new ValidationResult(false, "Tên không được dài quá 7 kí tự");
            }
            return ValidationResult.ValidResult;
        }
    }
}
