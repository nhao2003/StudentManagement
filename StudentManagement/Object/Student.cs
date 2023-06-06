using CommunityToolkit.Mvvm.ComponentModel;
using StudentManagement.Models;
using System;

namespace StudentManagement.Model
{
    public partial class Student : ObservableObject
    {
        [ObservableProperty]
        private String id;
        [ObservableProperty]
        private String name;
        [ObservableProperty]
        private String urlAvatar;

        private Hocsinh hocsinh;

        public Student(Hocsinh hs)
        {
            this.id = hs.Mahs;
            this.name = hs.Hotenhs;
            this.urlAvatar = "/Resource/images/student.png";
            hocsinh = hs;
        }
    }
}
