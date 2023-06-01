using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentManagement.Object;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudentManagement.ViewModel
{
    public partial class ClassConfigViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<SubjectTeacher> subjectTeacherList = new ObservableCollection<SubjectTeacher> {
             new SubjectTeacher("Toán", "Teacher A"),
             new SubjectTeacher("Lý", "Teacher B"),
             new SubjectTeacher("Hóa", "Teacher C"),
             new SubjectTeacher("Tin", "Teacher D"),
             new SubjectTeacher("Sinh", "Teacher E"),
             new SubjectTeacher("Anh", "Teacher F")
        };

    }
}
