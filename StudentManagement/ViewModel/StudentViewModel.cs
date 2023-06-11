using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
        private string searchStudentValue = "";
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
        public void SearchingValue()
        {
            var studentList = DataProvider.ins.context.Hocsinhs.ToList();
            if (SearchStudentValue.Trim() != "")
            {
                StudentList.Clear();
                if (choosing == "Họ tên")
                    foreach (var student in studentList)
                    {
                        string temp1 = Diacritics.RemoveDiacritics(student.Hotenhs), temp2 = Diacritics.RemoveDiacritics(searchStudentValue);
                        if (temp1.Contains(temp2))
                        {
                            StudentList.Add(new StudentDataGridItem(student));
                        }
                    }
                else
                {
                    foreach (var student in studentList)
                    {
                        string temp1 = Diacritics.RemoveDiacritics(student.Cccd), temp2 = Diacritics.RemoveDiacritics(searchStudentValue);
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
        [ObservableProperty]
        StudentDataGridItem studentDataGridItemSelected;
        [RelayCommand]
        public void ChangeTTHocSinh()
        {
            if (studentDataGridItemSelected == null)
                return;
            else
            {
                AddStudent changeTTHocSinh = new AddStudent(studentDataGridItemSelected.hocsinh);
                changeTTHocSinh.ShowDialog();
                if(changeTTHocSinh.DialogResult == true)
                {
                    if(changeTTHocSinh.isEdited) {
                        DataProvider.ins.context.Hocsinhs.Update(changeTTHocSinh.Hocsinh);
                        DataProvider.ins.context.SaveChanges();
                        StudentList.Clear();
                        foreach (var student in DataProvider.ins.context.Hocsinhs.ToList())
                        {
                            StudentList.Add(new StudentDataGridItem(student));
                        }
                        MessageBox.Show("Cập nhật thành công!");
                    }
                    else
                    {
                        DataProvider.ins.context.Hocsinhs.Add(changeTTHocSinh.Hocsinh);
                        DataProvider.ins.context.SaveChanges();
                        StudentList.Add(new StudentDataGridItem(changeTTHocSinh.Hocsinh));
                        MessageBox.Show("Thêm thành công");
                    }
                }
            }
        }
    }
}
