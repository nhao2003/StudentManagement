using CommunityToolkit.Mvvm.ComponentModel;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Object
{
    public partial class TaiKhoanDataGridItem : ObservableObject
    {
        [ObservableProperty]
        private bool isSelected = false;
        [ObservableProperty]
        private string hoten;
        [ObservableProperty]
        private string ngsinh;
        [ObservableProperty]
        private string email;
        [ObservableProperty]
        private string dchi;
        [ObservableProperty]
        private string gioitinhDisplay;
        [ObservableProperty]
        private string username;
        [ObservableProperty]
        private string vaitro;
        [ObservableProperty]
        private string password;
        public Taikhoan taikhoan;
        public TaiKhoanDataGridItem(Taikhoan taikhoan)
        {
            update(taikhoan);
        }
        public void update(Taikhoan taikhoan)
        {
            this.taikhoan = taikhoan;
            hoten = taikhoan.Hoten;
            ngsinh = taikhoan.Ngsinh.ToString();
            email = taikhoan.Email;
            dchi = taikhoan.Dchi;
            gioitinhDisplay = (taikhoan.Gioitinh ? "Nam" : "Nữ");
            username = taikhoan.Username;
            vaitro = taikhoan.Vaitro;
            password = taikhoan.Passwrd;
        }
    }
}
