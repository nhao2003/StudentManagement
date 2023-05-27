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
             new SubjectTeacher("Toán", new List<String> { "Teacher A", "Teacher B", "Teacher C" }),
             new SubjectTeacher("Lý", new List<String> { "Teacher A", "Teacher B", "Teacher C" }),
             new SubjectTeacher("Hóa", new List<String> { "Teacher A", "Teacher B", "Teacher C" }),
             new SubjectTeacher("Tin", new List<String> { "Teacher A", "Teacher B", "Teacher C" }),
             new SubjectTeacher("Sinh", new List<String> { "Teacher A", "Teacher B", "Teacher C" }),
             new SubjectTeacher("Anh", new List<String> { "Teacher A", "Teacher B", "Teacher C" })
        };

    }
}
