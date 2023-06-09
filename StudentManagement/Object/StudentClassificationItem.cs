﻿using CommunityToolkit.Mvvm.ComponentModel;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Object
{
    public partial class StudentClassificationItem : ObservableObject
    {
        [ObservableProperty]
        String hoTen;
        [ObservableProperty]
        int stt;
        [ObservableProperty]
        double? diemTB;
        [ObservableProperty]
        string hocLuc;
        [ObservableProperty]
        string hanhKiem;
        [ObservableProperty]
        Hocsinh hs;

        public StudentClassificationItem()
        {

        }
        public StudentClassificationItem(int stt, Hocsinh hocsinh, string Manh, string Mahk)
        {
            this.Hs = hocsinh;
            Kqhockytonghop kq;
            using (QUANLYHOCSINHContext db = new QUANLYHOCSINHContext())
            {
                kq = db.Kqhockytonghops.Where(x => x.Mahs == hocsinh.Mahs && x.Mahk == Mahk && x.Manh == Manh).FirstOrDefault();
                if (kq != null)
                {
                    this.HoTen = hocsinh.Hotenhs;
                    this.Stt = stt;
                    this.DiemTB = Math.Round((double)kq.DtbtatCaMonHocKy,2);
                    if(kq.MaHocLucNavigation != null)
                        this.HocLuc = kq.MaHocLucNavigation.TenHocLuc;
                    this.HanhKiem = kq.MaHanhKiemNavigation.TenHanhKiem;
                }
            }
        }
        public StudentClassificationItem(int stt, Hocsinh hocsinh, string Manh)
        {
            this.Hs = hocsinh;
            Kqnamhoc kq;
            using (QUANLYHOCSINHContext db = new QUANLYHOCSINHContext())
            {
                kq = db.Kqnamhocs.Where(x => x.Mahs == hocsinh.Mahs && x.Manh == Manh).FirstOrDefault();
                if (kq != null)
                {
                    this.HoTen = hocsinh.Hotenhs;
                    this.Stt = stt;
                    this.DiemTB = Math.Round((double)kq.DtbnamHoc,2);
                    if (kq.MaHocLucNavigation != null)
                        this.HocLuc = kq.MaHocLucNavigation.TenHocLuc;
                    this.HanhKiem = kq.MaHanhKiemNavigation.TenHanhKiem;
                }
            }
        }
    }
}
