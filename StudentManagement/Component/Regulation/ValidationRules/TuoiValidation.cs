using Castle.Core.Internal;
using System.Globalization;
using System.Windows.Controls;

namespace StudentManagement.Component.Regulation.ValidationRules
{
    public class TuoiValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int Tuoi;

            if (value.ToString() == null || value.ToString().Trim().IsNullOrEmpty() || !int.TryParse(value.ToString(), out Tuoi) || Tuoi <= 0)
            {
                return new ValidationResult(false, "Tuổi không được rỗng và có dạng số nguyên không âm.");
            }
            if (value.ToString().Length > 1000)
            {
                return new ValidationResult(false, "Tuổi vượt quá số ký tự quy định");
            }
            
            return ValidationResult.ValidResult;
        }
    }
}
