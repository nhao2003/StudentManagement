using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace StudentManagement.ValidationRules
{
    public class ClassNameValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            String name = (String)value;
            if(name.Length <= 0)
            {
                return new ValidationResult(false, "Tên không được rỗng");
            }
            else if(name.Length >= 8)
            {
                return new ValidationResult(false, "Tên không được dài quá 7 kí tự");
            }
            else if (IsDuplicate(name))
            {
                return new ValidationResult(false, "Tên bị trùng");
            }

            return ValidationResult.ValidResult;
        }

        public bool IsDuplicate(String name)
        {
            List<Lophocthucte> lops = DataProvider.ins.context.Lophocthuctes.ToList();
            // ktra neu trung 1 lan la chinh no, lan 2 thi break
            int check = 0;
            foreach(var lop in lops)
            {
                if (lop.MalopNavigation.Tenlop.Equals(name))
                {
                    check++;
                    if(check == 2)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    } 
}
