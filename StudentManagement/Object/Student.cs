using CommunityToolkit.Mvvm.ComponentModel;
using StudentManagement.Models;
using StudentManagement.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Model
{
    public partial class Student : ObservableObject
    {
        [ObservableProperty]
        private bool isSelected;
        [ObservableProperty]
        private Hocsinh hocsinh;
        public Student(Hocsinh hs)
        {
            this.isSelected = false;
            hocsinh = hs;
        }
    }
}
