using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace StudentManagement.Object
{
    public partial class SubjectTeacher : ObservableObject
    {
        [ObservableProperty]
        private String subject;
        [ObservableProperty]
        private String teacher;

        public SubjectTeacher(String Subject, String Teacher)
        {
            this.Subject = Subject;
            this.Teacher = Teacher;
        }
    }
}
