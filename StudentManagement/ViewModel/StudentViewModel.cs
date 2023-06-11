using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentManagement.Models;
using StudentManagement.Object;
using StudentManagement.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudentManagement.ViewModel
{
    public sealed partial class StudentViewModel: ObservableObject
    {
        public StudentViewModel() {
            var studentList = DataProvider.ins.context.Hocsinhs.ToList();
            StudentList = new ObservableCollection<StudentDataGridItem>();
            foreach (var student in studentList)
            {
                StudentList.Add(new StudentDataGridItem(student));
            }
        }
        public ObservableCollection<StudentDataGridItem> StudentList { get; set; }
        [ObservableProperty]
        private string searchValue = "";
        [ObservableProperty]
        private string choosing = "";
        [RelayCommand]
        public void AddStudent()
        {
            AddStudent addStudent = new AddStudent();
            addStudent.ShowDialog();
            if(addStudent.DialogResult == true)
            {
                StudentList.Add(new StudentDataGridItem(addStudent.Hocsinh));
                DataProvider.ins.context.Hocsinhs.Add(addStudent.Hocsinh);
                DataProvider.ins.context.SaveChanges();

            }
        }
        [RelayCommand]
        public void ChoosingValue()
        {
            choosing = Choosing;
        }
        [RelayCommand]
        public void SearchingValue()
        {
            string sortBy = "";
            var studentList = DataProvider.ins.context.Hocsinhs.ToList();
            if (SearchValue.Trim() != "")
            {
                StudentList.Clear();
                if (choosing == "Họ tên")
                    foreach (var student in studentList)
                    {
                        string temp1 = Diacritics.RemoveDiacritics(student.Hotenhs), temp2 = Diacritics.RemoveDiacritics(searchValue);
                        if (temp1.Contains(temp2))
                        {
                            StudentList.Add(new StudentDataGridItem(student));
                        }
                    }
                else
                {
                    foreach (var student in studentList)
                    {
                        string temp1 = Diacritics.RemoveDiacritics(student.Cccd), temp2 = Diacritics.RemoveDiacritics(searchValue);
                        if (temp1.Contains(temp2))
                        {
                            StudentList.Add(new StudentDataGridItem(student));
                        }
                    }
                }
            }
            else
            {
                StudentList.Clear();
                foreach (var student in studentList)
                {
                    StudentList.Add(new StudentDataGridItem(student));
                }
            }
        }
    }
}
