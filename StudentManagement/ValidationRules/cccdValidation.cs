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
    public class cccdValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value.ToString() == null || value.ToString().Trim().IsNullOrEmpty())
            {
                return new ValidationResult(false, "Mã số CCCD không được rỗng");
            }
            else if (value.ToString() != null)
            {
                string s = value.ToString();
                for (int i = 0; i < s.Length; i++)
                {
                    if ('0' <= s[i] && s[i] <= '9') continue;
                    return new ValidationResult(false, "Mã số CCCD không được chứa ký tự khác từ 0 -> 9");
                }
            }
            if (value.ToString().Length > 12)
            {
                return new ValidationResult(false, "Mã CCCD vượt quá số ký tự quy định (12).");
            }
            return ValidationResult.ValidResult;
        }
    }
}
