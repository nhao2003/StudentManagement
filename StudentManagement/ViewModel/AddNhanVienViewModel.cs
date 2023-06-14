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
        private int vaitroIndex = 0;
        
        partial void OnVaitroIndexChanged(int value)
        {
            if (value == 0)
            {
                int nhanVienCount = DataProvider.ins.context.Nhanvienphongdaotaos.Count() + 1;
                MaNVorGV = "Mã nhân viên";
                ChucVuOrHocVi = "Chức vụ";
                MaNhanVien = $"NV{nhanVienCount}";
            }
            else
            {
                int nhanVienCount = DataProvider.ins.context.Giaoviens.Count() + 1;
                MaNVorGV = "Mã giáo viên";
                ChucVuOrHocVi = "Học vị";
                MaNhanVien = $"GV{nhanVienCount}";
            }
        }
        [ObservableProperty]
        private String hoten;
        [ObservableProperty]
        private String title;
        [ObservableProperty]
        public bool isEdit = false;
        public bool Result = false;
        public Taikhoan taikhoan;
        [ObservableProperty]
        private String maNhanVien;
        [ObservableProperty]
        private String chucVu;
        [ObservableProperty]
        private String maNVorGV;
        [ObservableProperty]
        private String chucVuOrHocVi;
        [ObservableProperty]
        public ObservableCollection<MonHocItemDataGrid> monhocList = new();
        public AddNhanVienViewModel() {

            foreach (var item in DataProvider.ins.context.Monhocs.ToList())
            {
                monhocList.Add(new MonHocItemDataGrid(item));
            }
            int nhanVienCount = DataProvider.ins.context.Nhanvienphongdaotaos.Count()+1;
            MaNhanVien = $"NV{nhanVienCount}";
            title = "Thêm nhân viên";
            MaNVorGV = "Mã nhân viên";
            ChucVuOrHocVi = "Chức vụ";

        }
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
            if (tk.Vaitro == "NV") vaitroIndex = 0;
            else vaitroIndex = 1;
            foreach (var item in DataProvider.ins.context.Monhocs.ToList())
            {
                monhocList.Add(new MonHocItemDataGrid(item));
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
                MaNVorGV = "Mã nhân viên";
                ChucVuOrHocVi = "Chức vụ";
            }
            else if (tk.Vaitro == "GV")
            {
                title = "Chỉnh sửa giáo viên";
                maNVorGV = "Mã giáo viên";
                ChucVuOrHocVi = "Học vị";
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
                foreach (var item in monhocList)
                {
                    foreach(var gd in giaovien.Khananggiangdays)
                    {
                        if(gd.Mamh == item.MaMonHoc && gd.Isdeleted == false)
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
            string errorMessage = ValidateStrings();
            if (!string.IsNullOrEmpty(errorMessage))
            {
                // Hiển thị thông báo lỗi cho người dùng, ví dụ:
                MessageBox.Show(errorMessage);
                return;
            }
            Result = true;
            if (isEdit)
            {
                taikhoan.Hoten = Hoten;
                taikhoan.Dchi = Dchi;
                taikhoan.Gioitinh = (GioitinhIndex == 0);
                taikhoan.Passwrd = Password;
                taikhoan.Ngsinh = DateTime.Parse(Ngsinh);
                taikhoan.Email = Email;
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
                if (vaitroIndex == 0) taikhoan.Vaitro = "NV";
                else taikhoan.Vaitro = "GV";
            }
            window.Close();
        }
        public string ValidateStrings()
        {
            if (string.IsNullOrEmpty(username))
            {
                return "Username không được rỗng";
            }
            if (string.IsNullOrEmpty(hoten))
            {
                return "Họ tên không được rỗng";
            }

            if (string.IsNullOrEmpty(ngsinh))
            {
                return "Ngày sinh không được rỗng";
            }

            if (string.IsNullOrEmpty(email))
            {
                return "Email không được rỗng";
            }

            if (string.IsNullOrEmpty(dchi))
            {
                return "Địa chỉ không được rỗng";
            }
            if (string.IsNullOrEmpty(Password))
            {
                return "Mật khẩu không được rỗng";
            }
            if (string.IsNullOrEmpty(chucVu))
            {
                return "Chức vụ / học vị không được rỗng";
            }

            return ""; // Trả về chuỗi rỗng nếu không có lỗi
        }
    }

}
