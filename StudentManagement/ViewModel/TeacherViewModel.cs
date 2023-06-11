using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MaterialDesignThemes.Wpf;
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
using System.Windows.Controls;

namespace StudentManagement.ViewModel
{
    internal sealed partial class TeacherViewModel : ObservableObject
    {
        public TeacherViewModel()
        {
            var teacherList = DataProvider.ins.context.Taikhoans.ToList();
            TaikhoanList = new ObservableCollection<TaiKhoanDataGridItem>();

            foreach (var teacher in teacherList)
            {
                TaikhoanList.Add(new TaiKhoanDataGridItem(teacher));
            }
        }
        public ObservableCollection<TaiKhoanDataGridItem> TaikhoanList { get; set; }
        [ObservableProperty]
        private string searchValue = "";
        [ObservableProperty]
        private string choosing = "";
        [RelayCommand]
        public void AddNhanvien()
        {
            Addnhanvien addNhanvien = new Addnhanvien();
            addNhanvien.ShowDialog();
            if(addNhanvien.DialogResult== true)
            {
                TaikhoanList.Add(new TaiKhoanDataGridItem(addNhanvien.Taikhoan));
                DataProvider.ins.context.Taikhoans.Add(addNhanvien.Taikhoan);
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
            string sortBy ="";
            var teacherList = DataProvider.ins.context.Taikhoans.ToList();
            if (SearchValue.Trim() != "")
            {
                TaikhoanList.Clear();
                if (choosing == "Họ tên")
                    foreach (var teacher in teacherList)
                    {            
                        string temp1 = Diacritics.RemoveDiacritics(teacher.Hoten), temp2 = Diacritics.RemoveDiacritics(searchValue);
                        if (temp1.Contains(temp2))
                        {
                            TaikhoanList.Add(new TaiKhoanDataGridItem(teacher));
                        }
                    }
                else
                {
                    foreach (var teacher in teacherList)
                    {
                        string temp1 = Diacritics.RemoveDiacritics(teacher.Username), temp2 = Diacritics.RemoveDiacritics(searchValue);
                        if (temp1.Contains(temp2))
                        {
                            TaikhoanList.Add(new TaiKhoanDataGridItem(teacher));
                        }
                    }
                }
            }                
            else
            {
                TaikhoanList.Clear();
                foreach (var teacher in teacherList)
                {
                    TaikhoanList.Add(new TaiKhoanDataGridItem(teacher));
                }
            }    
        }
        [RelayCommand]
        public void UpdateNhanVien()
        {
            MessageBox.Show("Bruh");
        }
    }
}
