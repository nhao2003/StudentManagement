using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Object
{
    public partial class SubjectTeacher : ObservableObject
    {
        [ObservableProperty]
        private String subject;
        [ObservableProperty]
        private String teacher;
        [ObservableProperty]
        private List<String> teachers;

        public SubjectTeacher(String Subject, String Teacher)
        {
            this.Subject = Subject;
            this.Teacher = Teacher;
        }

        public SubjectTeacher(String Subject, List<String> teachers)
        {
            this.Subject = Subject;
            this.Teachers = teachers;
        }
    }
}
