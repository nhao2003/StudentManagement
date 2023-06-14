using Castle.Core.Internal;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace StudentManagement.ValidationRules
{
    public class UsernameValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value.ToString() == null || value.ToString().Trim().IsNullOrEmpty())
            {
                return new ValidationResult(false, "Username không được rỗng");
            }
            else if (value.ToString() != null)
            {
                string check = value.ToString().Trim();
                foreach (var tk in DataProvider.ins.context.Taikhoans.ToList())
                {
                    if(check.ToLower() == tk.Username.Trim().ToLower()) {
                        return new ValidationResult(false, "Username đã tồn tại");
                    }
                }
            }
            if (value.ToString().Length > 100)
            {
                return new ValidationResult(false, "Username vượt quá số ký tự quy định (100).");
            }
            return ValidationResult.ValidResult;
        }
    }
}
