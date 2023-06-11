using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MaterialDesignThemes.Wpf;
using Microsoft.Data.SqlClient;
using StudentManagement.Models;
using StudentManagement.Object;
using StudentManagement.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.DirectoryServices.ActiveDirectory;
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
        [ObservableProperty]
        TaiKhoanDataGridItem taiKhoanDataGridItemSelected;
        public ObservableCollection<TaiKhoanDataGridItem> TaikhoanList { get; set; }
        [ObservableProperty]
        private string searchNhanVienValue = "";
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
        public void SearchingValue()
        {           
            var teacherList = DataProvider.ins.context.Taikhoans.ToList();
            if (SearchNhanVienValue.Trim() != "")
            {
                TaikhoanList.Clear();
                if (choosing == "Họ tên")
                    foreach (var teacher in teacherList)
                    {            
                        string temp1 = Diacritics.RemoveDiacritics(teacher.Hoten), temp2 = Diacritics.RemoveDiacritics(searchNhanVienValue);
                        if (temp1.Contains(temp2))
                        {
                            TaikhoanList.Add(new TaiKhoanDataGridItem(teacher));
                        }
                    }
                else
                {
                    foreach (var teacher in teacherList)
                    {
                        string temp1 = Diacritics.RemoveDiacritics(teacher.Username), temp2 = Diacritics.RemoveDiacritics(searchNhanVienValue);
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
            if (taiKhoanDataGridItemSelected == null)
                return;
            else
            {
                Addnhanvien changeNVInfo = new Addnhanvien(taiKhoanDataGridItemSelected.taikhoan);
                changeNVInfo.ShowDialog();
                if(changeNVInfo.DialogResult == true)
                {
                    if(changeNVInfo.isEdited)
                    {
                        DataProvider.ins.context.Taikhoans.Update(changeNVInfo.Taikhoan);
                        DataProvider.ins.context.SaveChanges();
                        TaikhoanList.Clear();
                        foreach (var teacher in DataProvider.ins.context.Taikhoans.ToList())
                        {
                            TaikhoanList.Add(new TaiKhoanDataGridItem(teacher));
                        }
                        MessageBox.Show("Cập nhật thành công!");
                    }
                    else
                    {
                        DataProvider.ins.context.Taikhoans.Add(changeNVInfo.Taikhoan);
                        DataProvider.ins.context.SaveChanges();
                        TaikhoanList.Add(new TaiKhoanDataGridItem(changeNVInfo.Taikhoan));
                        MessageBox.Show("Thêm thành công");
                    }
                }
            }
        }
    }
}
