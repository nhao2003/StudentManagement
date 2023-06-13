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
            Addnhanvien addNhanVien = new Addnhanvien(new AddNhanVienViewModel());
            addNhanVien.ShowDialog();
            AddNhanVienViewModel result = (AddNhanVienViewModel)addNhanVien.DataContext;
            if (result.Result == true)
            {
                TaikhoanList.Add(new TaiKhoanDataGridItem(result.taikhoan));
                DataProvider.ins.context.Taikhoans.Add(result.taikhoan);
                if (result.taikhoan.Vaitro == "NV")
                {
                    Nhanvienphongdaotao nhanvienphongdaotao = new Nhanvienphongdaotao();
                    nhanvienphongdaotao.Manv = result.MaNhanVien;
                    nhanvienphongdaotao.Chucvu = result.ChucVu;
                    nhanvienphongdaotao.Username = result.Username;
                    DataProvider.ins.context.Nhanvienphongdaotaos.Add(nhanvienphongdaotao);
                    DataProvider.ins.context.SaveChanges();
                }
                else if(result.taikhoan.Vaitro == "GV")
                {
                    Giaovien giaovien = new Giaovien();
                    giaovien.Magv = result.MaNhanVien;
                    giaovien.Hocvi = result.ChucVu;
                    giaovien.Username = result.Username;
                    foreach(var item in result.MonhocList)
                    {
                        if (item.IsCheckedMonHoc)
                        {
                            Khananggiangday khananggiangday = new Khananggiangday();
                            khananggiangday.Magv = result.MaNhanVien;
                            khananggiangday.Mamh = item.MaMonHoc;
                            DataProvider.ins.context.Khananggiangdays.Add(khananggiangday);
                        }
                    }
                    DataProvider.ins.context.Giaoviens.Add(giaovien);
                    DataProvider.ins.context.SaveChanges();
                }
                MessageBox.Show("Thêm thành công!");
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
            if (TaiKhoanDataGridItemSelected == null)
                return;
            else
            {
                Addnhanvien changeNVInfo = new Addnhanvien(new AddNhanVienViewModel(TaiKhoanDataGridItemSelected.taikhoan));
                changeNVInfo.ShowDialog();
                AddNhanVienViewModel result = (AddNhanVienViewModel)changeNVInfo.DataContext;
                if (result.Result == true)
                {
                    DataProvider.ins.context.Taikhoans.Update(result.taikhoan);
                    if(result.taikhoan.Vaitro == "NV")
                    {
                        foreach(var nv in DataProvider.ins.context.Nhanvienphongdaotaos)
                        {
                            if(nv.Username == result.taikhoan.Username)
                            {
                                nv.Chucvu = result.ChucVu;
                                DataProvider.ins.context.Nhanvienphongdaotaos.Update(nv);
                                break;
                            }
                        }
                    } else
                    {
                        foreach(var gv in DataProvider.ins.context.Giaoviens)
                        {
                            if(gv.Username == result.taikhoan.Username)
                            {
                                gv.Hocvi = result.ChucVu;
                                gv.Khananggiangdays.Clear();
                                foreach(var mh in result.MonhocList)
                                {
                                    if (mh.IsCheckedMonHoc)
                                    {
                                        Khananggiangday khananggiangday = new Khananggiangday();
                                        khananggiangday.Magv = gv.Magv;
                                        khananggiangday.Mamh = mh.MaMonHoc;
                                        gv.Khananggiangdays.Add(khananggiangday);
                                    }
                                }
                                DataProvider.ins.context.Giaoviens.Update(gv);
                                break;
                            }
                        }
                    }
                    
                    DataProvider.ins.context.SaveChanges();
                    MessageBox.Show("Cập nhật thành công!");
                    TaikhoanList.Clear();
                    foreach (var teacher in DataProvider.ins.context.Taikhoans.ToList())
                    {
                        TaikhoanList.Add(new TaiKhoanDataGridItem(teacher));
                    }
                }
            }
        }
    }
}
