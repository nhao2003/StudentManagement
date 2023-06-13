using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentManagement.Models;
using StudentManagement.Object;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudentManagement.ViewModel
{
    public partial class AddNhanVienViewModel : ObservableObject
    {
        [ObservableProperty]
        private String username;
        [ObservableProperty]
        private String password;
        [ObservableProperty]
        private String email;
        [ObservableProperty]
        private String ngsinh;
        [ObservableProperty]
        private String dchi;
        [ObservableProperty]
        private int gioitinhIndex;
        [ObservableProperty]
        private int vaitroIndex;
        [ObservableProperty]
        private String hoten;
        [ObservableProperty]
        private String title;
        public bool isEdit = false;
        public bool Result = false;
        public Taikhoan taikhoan;

        [ObservableProperty]
        public ObservableCollection<MonHocItemDataGrid> monhocList = new();
        public AddNhanVienViewModel() { title = "Thêm nhân viên"; }
        public AddNhanVienViewModel(Taikhoan tk)
        {
            title = "Chỉnh sửa nhân viên";
            isEdit = true;
            taikhoan = tk;
            hoten = taikhoan.Hoten;
            username = tk.Username;
            password = tk.Passwrd;
            email = tk.Email;
            ngsinh = tk.Ngsinh.ToString();
            dchi = tk.Dchi;
            gioitinhIndex = tk.Gioitinh ? 0 : 1;
            if (tk.Vaitro == "0") vaitroIndex = 0;
            else vaitroIndex = 1;
            foreach (var monhoc in DataProvider.ins.context.Monhocs.ToList())
                monhocList.Add(new MonHocItemDataGrid(monhoc)); 
        }
        [RelayCommand]
        private void ThemHoacCapNhatNhanVien(Window window)
        {
            Result = true;
            if(isEdit)
            {
                taikhoan.Hoten = hoten;
                taikhoan.Dchi = dchi;
                taikhoan.Gioitinh = (gioitinhIndex == 0);
                taikhoan.Passwrd = password;
                taikhoan.Ngsinh = DateTime.Parse(ngsinh);
                taikhoan.Email = email;
                if (vaitroIndex == 0) taikhoan.Vaitro = "NV";
                else taikhoan.Vaitro = "GV";
            }
            else
            {
                taikhoan = new Taikhoan();
                taikhoan.Username = username;
                taikhoan.Hoten = hoten;
                taikhoan.Dchi = dchi;
                taikhoan.Gioitinh = (gioitinhIndex == 0);
                taikhoan.Passwrd = password;
                taikhoan.Ngsinh = DateTime.Parse(ngsinh);
                taikhoan.Email = email;
                if (vaitroIndex == 0) taikhoan.Vaitro = "Nhân viên";
                else taikhoan.Vaitro = "Giáo viên";
            }
            window.Close();
        }
    }
}
