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
    public class ManvgvValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value.ToString() == null || value.ToString().Trim().IsNullOrEmpty())
            {
                return new ValidationResult(false, "Mã giáo viên không được rỗng");
            }
            if (value.ToString().Length > 7)
            {
                return new ValidationResult(false, "Mã giáo viên vượt quá số ký tự quy định (7).");
            }
            return ValidationResult.ValidResult;
        }
    }
}
