using CommunityToolkit.Mvvm.ComponentModel;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private ObservableCollection<Giaovien> teachers = new ObservableCollection<Giaovien>()
        {
        };
        [ObservableProperty]
        private Giaovien sgiaovien;
        public SubjectTeacher(String Subject, String Teacher)
        {
            this.Subject = Subject;
            this.Teacher = Teacher;
        }

        public SubjectTeacher(String Subject)
        {
            this.Subject = Subject;
        }

        public void AddTeacher(Giaovien teacher)
        {
            teachers.Add(teacher);
        }

        public void SetGiaoVienPhanCong(Giaovien gv)
        {
            Sgiaovien = gv;
        }
    }
}
