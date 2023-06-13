using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace StudentManagement.ValidationRules
{
    public class ScoreValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            String score = (String)value;
            double number;
            if (score.Length <= 0)
            {
                return new ValidationResult(false, "Điểm không được rỗng");
            }
            else if (!double.TryParse(score, out number))
            {
                return new ValidationResult(false, "Số không hợp lệ");
            }
            else if (number <= 0)
            {
                return new ValidationResult(false, "Điểm không âm");
            }
            else if (number > 10)
            {
                return new ValidationResult(false, "Số không lớn hơn 10");
            }

            return ValidationResult.ValidResult;
        }
    }
}
