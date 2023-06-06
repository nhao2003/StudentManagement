using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.ViewModel
{
    public sealed partial class StudentViewModel: ObservableObject
    {
        public StudentViewModel() {
            var studentList = DataProvider.ins.context.Hocsinhs.ToList();
            StudentList = new ObservableCollection<Hocsinh>(studentList);
        }
        public ObservableCollection<Hocsinh> StudentList { get; set; }

        [RelayCommand]
        public void AddStudent()
        {
            AddStudent addStudent = new AddStudent();
            addStudent.Show();
        }
    }
}
