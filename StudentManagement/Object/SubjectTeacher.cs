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
        private Monhoc monhoc;
        [ObservableProperty]
        private ObservableCollection<Giaovien> teachers = new ObservableCollection<Giaovien>()
        {
        };

        private Giaovien sgiaovien;

        public Giaovien Sgiaovien
        {
            set 
            { 
                this.sgiaovien = value;
                OnPropertyChanged();
            }
            get { return this.sgiaovien; }
        }

        public void SetSGiaoVien(Giaovien sgiaovien)
        {
            this.sgiaovien = sgiaovien;
        }
        private Phanconggiangday phanconggiangday;
        public Phanconggiangday Phanconggiangday
        {
            set { phanconggiangday = value; }
            get { return phanconggiangday; }
        }

        public SubjectTeacher(String Subject, String Teacher)
        {
            this.Subject = Subject;
            this.Teacher = Teacher;
        }

        public SubjectTeacher(Monhoc monhoc)
        {
            this.Monhoc = monhoc;
        }

        public void AddTeacher(Giaovien teacher)
        {
            teachers.Add(teacher);
        }


    }
}
