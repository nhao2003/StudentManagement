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
        [ObservableProperty]
        private String title;
        [ObservableProperty]
        public bool isEdit = false;
        public bool Result = false;
        public Hocsinh hocsinh;

        public AddNewStudentViewModel() {title = "Thêm học sinh";
        }
        public AddNewStudentViewModel(Hocsinh hs) 
        {
            title = "Chỉnh sửa học sinh";
            isEdit = true;
            hocsinh = hs;
            hoTen = hocsinh.Hotenhs;
            cccd = hocsinh.Cccd;
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
                hocsinh.Hotenhs = hoTen;
                hocsinh.Cccd = cccd;
                hocsinh.Ngsinh = DateTime.Parse(ngSinh);
                hocsinh.Email = email;
                hocsinh.Dchi = dchi;
                hocsinh.Gioitinh = (gioiTinhIndex == 0);
                hocsinh.Dantoc = danToc;
                hocsinh.Tongiao = tonGiao;
            }
            else
            {
                hocsinh = new Hocsinh();
                hocsinh.Hotenhs = hoTen;
                hocsinh.Cccd = cccd;
                hocsinh.Ngsinh = DateTime.Parse(ngSinh);
                hocsinh.Email = email;
                hocsinh.Dchi = dchi;
                hocsinh.Gioitinh = (gioiTinhIndex == 0);
                hocsinh.Dantoc = danToc;
                hocsinh.Tongiao = tonGiao;
                hocsinh.Mahs = maHs;
            }
            window.Close();
        }
    }
}
