using Castle.Core.Internal;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace StudentManagement.ValidationRules
{
    public class NotnullValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value.ToString() == null || value.ToString().Trim().IsNullOrEmpty())
            {
                return new ValidationResult(false, "Ô không được rỗng");
            }
            return ValidationResult.ValidResult;
        }
    }
}
