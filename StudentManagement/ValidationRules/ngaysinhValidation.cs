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
    public class ngaysinhValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value.ToString() == null || value.ToString().Trim().IsNullOrEmpty())
            {
                return new ValidationResult(false, "Ngày sinh không được rỗng");
            }
            else if (value.ToString() != null)
            {
                try
                {
                    DateTime.Parse(value.ToString());
                    return ValidationResult.ValidResult;
                }
                catch 
                {
                    return new ValidationResult(false, "Ngày sinh không hợp lệ");
                }
            }
            if (value.ToString().Length > 10)
            {
                return new ValidationResult(false, "Ngày sinh vượt quá số ký tự quy định (10).");
            }
            return ValidationResult.ValidResult;
        }
    }
}
