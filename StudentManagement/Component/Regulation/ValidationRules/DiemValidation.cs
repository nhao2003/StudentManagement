using Castle.Core.Internal;
using MaterialDesignThemes.Wpf.Internal;
using System.Globalization;
using System.Windows.Controls;

namespace StudentManagement.Component.Regulation.ValidationRules
{
    public class DiemValidation : ValidationRule
    {

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            double diem;
            if (value.ToString() == null || value.ToString().Trim().IsNullOrEmpty() || double.TryParse(value.ToString(), out diem) || diem < 0)
            {

                return new ValidationResult(false, "Điểm không được rỗng và là số thực lớn hơn hoặc bằng 0.");
            }
            if (value.ToString().Length > 1000)
            {
                return new ValidationResult(false, "Điểm vượt quá số ký tự quy định");
            }
            return ValidationResult.ValidResult;
        }
    }
}
