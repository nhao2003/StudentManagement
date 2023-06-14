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
    public class HoTenValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value.ToString() == null || value.ToString().Trim().IsNullOrEmpty())
            {
                return new ValidationResult(false, "Tên không được rỗng");
            }
            if (value.ToString().Length > 30)
            {
                return new ValidationResult(false, "Tên vượt quá số ký tự quy định (30).");
            }
            return ValidationResult.ValidResult;
        }
    }
}
