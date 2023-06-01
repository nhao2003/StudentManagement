using CommunityToolkit.Mvvm.ComponentModel;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Object
{
    public partial class ClassSubjectSummaryData : ObservableObject
    {
        [ObservableProperty]
        private int stt;
        [ObservableProperty]
        private String hoTen;
        [ObservableProperty]
        private double diemTB;
        [ObservableProperty]
        private bool dat;
        [ObservableProperty]
        private int hang;
        public ClassSubjectSummaryData(int Stt, String HoTen, double DiemTB, bool Dat, int Hang)
        {
            this.Stt = Stt;
            this.HoTen = HoTen;
            this.DiemTB = DiemTB;
            this.Dat = Dat;
            this.Hang = Hang;
        }
        public ClassSubjectSummaryData(int Stt,Hocsinh hocsinh, String Manh, String Mahk, String Mamh)
        {
            this.Stt= Stt;
            this.HoTen = hocsinh.Hotenhs; 
            var kq = hocsinh.Kqhockymonhocs
            .FirstOrDefault(kq => kq.Manh == Manh && kq.Mahk == Mahk && kq.Mamh == Mamh);

            this.DiemTB = kq?.DtbmonHocKy ?? 0.0;

            this.Dat = (DiemTB > 5);
        }
    }
}
