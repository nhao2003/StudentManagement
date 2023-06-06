using Castle.Core.Internal;
using System.Globalization;
using System.Windows.Controls;

namespace StudentManagement.Component.Regulation.ValidationRules
{
    public class SiSoValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int siso;
            if (value.ToString() == null || value.ToString().Trim().IsNullOrEmpty() || !int.TryParse(value.ToString(), out siso) || siso <= 0)
            {
                return new ValidationResult(false, "Sỉ số phải không rỗng và là số nguyên và lớn hơn 0");
            }
            if (value.ToString().Length > 1000)
            {
                return new ValidationResult(false, "Tham số vượt quá số ký tự quy định");
            }
            
            
            return ValidationResult.ValidResult;
        }
    }
}
