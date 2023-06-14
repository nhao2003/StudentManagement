using CommunityToolkit.Mvvm.ComponentModel;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudentManagement.Object
{
    public partial class AvgSubject : ObservableObject
    {
        [ObservableProperty]
        private string subject;
        [ObservableProperty]
        private double dtb;

        public AvgSubject()
        {

        }
        public AvgSubject(Hocsinh hs, string Manh, string Mahk, string Mamh)
        {

            Kqhockymonhoc kq;
            using (QUANLYHOCSINHContext db = new QUANLYHOCSINHContext())
            {
                kq = db.Kqhockymonhocs.Where(x => x.Mahs == hs.Mahs
                        && x.Manh == Manh
                        && x.Mahk == Mahk
                        && x.Mamh == Mamh).FirstOrDefault();
                if (kq != null)
                {
                    this.Subject = kq.MamhNavigation.Tenmh;
                    this.Dtb = kq.DtbmonHocKy;
                }
            }
        }
        public AvgSubject(Hocsinh hs, string Manh, string Mamh)
        {
            Diemtrungbinhmonhocnamhoc kq;
            using (QUANLYHOCSINHContext db = new QUANLYHOCSINHContext())
            {
                kq = db.Diemtrungbinhmonhocnamhocs.Where(x => x.Mahs == hs.Mahs
                        && x.Manh == Manh
                        && x.Mamh == Mamh).FirstOrDefault();
                if (kq != null)
                {
                    this.Subject = kq.MamhNavigation.Tenmh;
                    this.Dtb = kq.DtbmonHocNamHoc;
                }
            }
        }
    }
}
