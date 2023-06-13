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
        private String maNhanVien;
        [ObservableProperty]
        private String chucVu;
        [ObservableProperty]
        public ObservableCollection<MonHocItemDataGrid> monhocList = new();
        public AddNhanVienViewModel() {

            foreach (var item in DataProvider.ins.context.Monhocs.ToList())
            {
                MonhocList.Add(new MonHocItemDataGrid(item));
            }
            title = "Thêm nhân viên"; }
        public AddNhanVienViewModel(Taikhoan tk)
        {
            isEdit = true;
            taikhoan = tk;
            hoten = taikhoan.Hoten;
            username = tk.Username;
            password = tk.Passwrd;
            email = tk.Email ?? "";
            ngsinh = tk.Ngsinh.ToString();
            dchi = tk.Dchi ?? "";
            gioitinhIndex = tk.Gioitinh ? 0 : 1;
            if (tk.Vaitro == "0") vaitroIndex = 0;
            else vaitroIndex = 1;
            foreach (var item in DataProvider.ins.context.Monhocs.ToList())
            {
                MonhocList.Add(new MonHocItemDataGrid(item));
            }
            if (tk.Vaitro == "NV")
            {
                Nhanvienphongdaotao nhanvienphongdaotao = new();
                foreach (var item in DataProvider.ins.context.Nhanvienphongdaotaos)
                {
                    if (taikhoan.Username == item.Username)
                    {
                        maNhanVien = item.Manv;
                        chucVu = item.Chucvu??"";
                        break;
                    }
                }
                title = "Chỉnh sửa nhân viên";
            }
            else if (tk.Vaitro == "GV")
            {
                title = "Chỉnh sửa giáo viên";
                Giaovien giaovien = new();
                foreach(var item in DataProvider.ins.context.Giaoviens)
                {
                    if(taikhoan.Username == item.Username)
                    {
                        maNhanVien = item.Magv;
                        chucVu = item.Hocvi ?? "";
                        giaovien = item;
                        break;
                    }
                }
                foreach (var item in MonhocList)
                {
                    foreach(var gd in giaovien.Khananggiangdays)
                    {
                        if(gd.Mamh == item.MaMonHoc)
                        {
                            item.IsCheckedMonHoc = true;
                        }
                    }
                }
            }
        }
        [RelayCommand]
        private void ThemHoacCapNhatNhanVien(Window window)
        {
            Result = true;
            if (isEdit)
            {
                taikhoan.Hoten = Hoten;
                taikhoan.Dchi = Dchi;
                taikhoan.Gioitinh = (GioitinhIndex == 0);
                taikhoan.Passwrd = Password;
                taikhoan.Ngsinh = DateTime.Parse(Ngsinh);
                taikhoan.Email = Email;
                if (VaitroIndex == 0) taikhoan.Vaitro = "NV";
                else taikhoan.Vaitro = "GV";
            }
            else
            {
                taikhoan = new Taikhoan();
                taikhoan.Username = Username;
                taikhoan.Hoten = Hoten;
                taikhoan.Dchi = Dchi;
                taikhoan.Gioitinh = (GioitinhIndex == 0);
                taikhoan.Passwrd = Password;
                taikhoan.Ngsinh = DateTime.Parse(Ngsinh);
                taikhoan.Email = Email;
                if (VaitroIndex == 0) taikhoan.Vaitro = "NV";
                else taikhoan.Vaitro = "GV";
            }
            window.Close();
        }
    }
}
