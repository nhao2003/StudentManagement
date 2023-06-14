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
                int TuoiToiTieu = 22, TuoiToiDa = 65;
                try
                {
                    DateTime birthDate = DateTime.Parse(value.ToString());
                    DateTime currentDate = DateTime.Now; // Thời gian hiện tại

                    int age = currentDate.Year - birthDate.Year; // Số tuổi dựa trên năm

                    // Kiểm tra nếu chưa đến sinh nhật trong năm nay thì giảm số tuổi đi 1
                    if (currentDate.Month < birthDate.Month || (currentDate.Month == birthDate.Month && currentDate.Day < birthDate.Day))
                    {
                        age--;
                    }
                    if (age > TuoiToiDa || age < TuoiToiTieu) return new ValidationResult(false, "Tuổi học sinh nằm ngoài khoảng " + TuoiToiTieu.ToString() + " - " + TuoiToiDa.ToString());
                }
                catch
                {
                    return new ValidationResult(false, "Ngày sinh phải có format là mm/dd/yyyy và độ tuổi nằm trong khoảng " + TuoiToiTieu.ToString() + " - " + TuoiToiDa.ToString());
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
