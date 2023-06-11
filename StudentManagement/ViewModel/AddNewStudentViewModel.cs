using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudentManagement.ViewModel
{
    public partial class AddNewStudentViewModel : ObservableObject
    {
        [ObservableProperty]
        String cccd = "";
        [ObservableProperty]
        private String hoTen;
        [ObservableProperty]
        private String ngSinh;
        [ObservableProperty]
        private String email;
        [ObservableProperty]
        private String dchi;
        [ObservableProperty]
        private int gioiTinhIndex;
        [ObservableProperty]
        private String maHs;
        [ObservableProperty]
        private String danToc;
        [ObservableProperty]
        private String tonGiao;

        public bool isEdit = false;
        public bool Result = false;
        public Hocsinh hocsinh;

        public AddNewStudentViewModel() {
        }
        public AddNewStudentViewModel(Hocsinh hs) {
            isEdit = true;
            hocsinh = hs;
            HoTen = hocsinh.Hotenhs;
            Cccd = hocsinh.Cccd;
            ngSinh = hocsinh.Ngsinh.ToString();
            email = hocsinh.Email;
            dchi = hocsinh.Dchi;
            gioiTinhIndex = hocsinh.Gioitinh ? 0 : 1;
            maHs = hocsinh.Mahs;
            danToc = hocsinh.Dantoc;
            tonGiao = hocsinh.Tongiao;
        }

        [RelayCommand]
        private void ThemHoacCapNhatHocSinh(Window window)
        {
            Result = true;
            if(isEdit)
            {
                hocsinh.Hotenhs = HoTen;
                hocsinh.Cccd = Cccd;
                hocsinh.Ngsinh = DateTime.Parse(NgSinh);
                hocsinh.Email = Email;
                hocsinh.Dchi = Dchi;
                hocsinh.Gioitinh = (GioiTinhIndex == 0);
                hocsinh.Dantoc = DanToc;
                hocsinh.Tongiao = TonGiao;
            }
            else
            {
                hocsinh = new Hocsinh();
                hocsinh.Hotenhs = HoTen;
                hocsinh.Cccd = Cccd;
                hocsinh.Ngsinh = DateTime.Parse(NgSinh);
                hocsinh.Email = Email;
                hocsinh.Dchi = Dchi;
                hocsinh.Gioitinh = (GioiTinhIndex == 0);
                hocsinh.Dantoc = DanToc;
                hocsinh.Tongiao = TonGiao;
                hocsinh.Mahs = MaHs;
            }
            window.Close();
        }
    }
}
