using CommunityToolkit.Mvvm.ComponentModel;
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

        public Student(String id, String name, String urlAvatar)
        {
            this.id = id;
            this.name = name;
            this.urlAvatar = urlAvatar;
        }
    }
}
