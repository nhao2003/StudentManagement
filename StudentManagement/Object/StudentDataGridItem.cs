using CommunityToolkit.Mvvm.ComponentModel;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StudentManagement.Object
{
    public partial class StudentDataGridItem : ObservableObject
    {
        [ObservableProperty]
        private bool isSelected = false;
        [ObservableProperty]
        private string cccd;
        [ObservableProperty]
        private string hotenhs;
        [ObservableProperty]
        private string ngsinh;
        [ObservableProperty]
        private string email;
        [ObservableProperty]
        private string sdt;
        [ObservableProperty]
        private string gioitinhDisplay;
        [ObservableProperty]
        private string dchi;
        [ObservableProperty]
        private string tongiao;
        [ObservableProperty]
        private string dantoc;
        Hocsinh hocsinh;
        public StudentDataGridItem(Hocsinh hocsinh)
        {
            this.hocsinh = hocsinh;
            cccd = hocsinh.Cccd;
            hotenhs = hocsinh.Hotenhs;
            ngsinh = hocsinh.Ngsinh.ToString();
            email = hocsinh.Email;
            sdt = hocsinh.Sdt;
            dchi = hocsinh.Dchi;
            gioitinhDisplay = (hocsinh.Gioitinh ? "Nam" : "Nữ");
            tongiao = hocsinh.Tongiao;
            dantoc = hocsinh.Dantoc;
        }
    }
}
