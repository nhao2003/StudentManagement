﻿using CommunityToolkit.Mvvm.ComponentModel;
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
                if(student.Isdeleted == false)
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
            //Không truyền vào AddNewStudentViewModel thì thêm học sinh
            AddStudent addStudent = new AddStudent(new AddNewStudentViewModel());
            addStudent.ShowDialog();
            AddNewStudentViewModel result = (AddNewStudentViewModel)addStudent.DataContext;
            if (result.Result == true)
            {
                StudentList.Add(new StudentDataGridItem(result.hocsinh));
                DataProvider.ins.context.Hocsinhs.Add(result.hocsinh);
                DataProvider.ins.context.SaveChanges();
                MessageBox.Show("Thêm học sinh thành công!");
            }
        }
        [RelayCommand]
        public void SearchingValue()
        {
            var studentList = DataProvider.ins.context.Hocsinhs.ToList();
            if (searchStudentValue.Trim() != "")
            {
                StudentList.Clear();
                if (choosing == "Họ tên")
                    foreach (var student in studentList)
                    {
                        if (student.Isdeleted == true) continue;
                        string temp1 = Diacritics.RemoveDiacritics(student.Hotenhs), temp2 = Diacritics.RemoveDiacritics(searchStudentValue);
                        if (temp1.Contains(temp2) )
                        {
                            StudentList.Add(new StudentDataGridItem(student));
                        }
                    }
                else
                {
                    foreach (var student in studentList)
                    {
                        if (student.Isdeleted == true) continue;
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
                    if (student.Isdeleted == false)
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
                //Truyền HocSinh vào AddNewStudentViewModel nếu cập nh
                AddStudent changeTTHocSinh = new AddStudent(new AddNewStudentViewModel(studentDataGridItemSelected.hocsinh));
                changeTTHocSinh.ShowDialog();
                AddNewStudentViewModel result = (AddNewStudentViewModel)changeTTHocSinh.DataContext;
                if (result.Result == true)
                {
                    if(result.isEdit) {
                        DataProvider.ins.context.Hocsinhs.Update(result.hocsinh);
                        DataProvider.ins.context.SaveChanges();
                        StudentList.Clear();
                        foreach (var student in DataProvider.ins.context.Hocsinhs.ToList())
                        {
                            if (student.Isdeleted == false)
                                StudentList.Add(new StudentDataGridItem(student));
                        }
                        MessageBox.Show("Cập nhật thành công!");
                    }
                    else
                    {
                        DataProvider.ins.context.Hocsinhs.Add(result.hocsinh);
                        DataProvider.ins.context.SaveChanges();
                        StudentList.Add(new StudentDataGridItem(result.hocsinh));
                        MessageBox.Show("Thêm thành công");
                    }
                }
            }
        }
        [RelayCommand]
        public void DeleteStudent()
        {
            MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa những học sinh này?", "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                List<StudentDataGridItem> hsToRemove = new List<StudentDataGridItem>();

                foreach (StudentDataGridItem hs in StudentList)
                {
                    if (hs.IsSelected)
                    {
                        hsToRemove.Add(hs);
                        hs.hocsinh.Isdeleted = true;
                        DataProvider.ins.context.Update(hs.hocsinh);
                    }
                }
                DataProvider.ins.context.SaveChanges();
                foreach (StudentDataGridItem hs in hsToRemove)
                {
                    StudentList.Remove(hs);
                }

                MessageBox.Show("Xóa thành công!", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
