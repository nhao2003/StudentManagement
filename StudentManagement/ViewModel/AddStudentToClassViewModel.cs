using CommunityToolkit.Mvvm.ComponentModel;
using StudentManagement.Object.SchoolYear;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.ViewModel;

public sealed partial class AddStudentToClassViewModel : ObservableObject
{
    public AddStudentToClassViewModel()
    {
        Namhoc namhoc = DataProvider.ins.Context.Namhocs.ToList().First();
        var hocsinh = DataProvider.ins.Context.Hocsinhs.ToArray();
        students = new List<StudentWithClassItem>();
        foreach ( var h in hocsinh)
        {
            students.Add(new StudentWithClassItem(h, namhoc));
        }
    }
    [ObservableProperty]
    private List<StudentWithClassItem> students;    
}
