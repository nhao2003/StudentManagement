﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Object
{
    public partial class ClassDetailsSummaryItem : ObservableObject
    {
        [ObservableProperty]
        private int stt;
        [ObservableProperty]
        private String hoTen;
        [ObservableProperty]
        private double diemTB;
        [ObservableProperty]
        private string dat;
        [ObservableProperty]
        private int hang;
        public ClassDetailsSummaryItem(int Stt, String HoTen, double DiemTB, string Dat, int Hang)
        {
            this.Stt = Stt;
            this.HoTen = HoTen;
            this.DiemTB = DiemTB;
            this.Dat = Dat;
            this.Hang = Hang;
        }
        public ClassDetailsSummaryItem()
        {
        }
        public ClassDetailsSummaryItem(int Stt,Hocsinh hocsinh, String Manh, String Mahk, String Mamh)
        {
            this.Stt= Stt;
            this.HoTen = hocsinh.Hotenhs;
            Kqhockymonhoc kq;
            using (QUANLYHOCSINHContext db = new QUANLYHOCSINHContext())
            {
                kq = db.Kqhockymonhocs.Where(kq => kq.Manh == Manh && kq.Mahk == Mahk && kq.Mamh == Mamh && hocsinh.Mahs == kq.Mahs).FirstOrDefault();
                this.DiemTB = Math.Round(kq?.DtbmonHocKy ?? 0.0,2);
                var diemDat = DataProvider.ins.context.Thamsos.Where(t => t.Id == "TS006").Select(t => t.Giatri).FirstOrDefault();
                this.Dat = (DiemTB >= double.Parse(diemDat)) ? "Đạt" : "Không đạt";
            }
        }
        public ClassDetailsSummaryItem(int Stt, Hocsinh hocsinh, String Manh, String Mahk)
        {
            this.Stt = Stt;
            this.HoTen = hocsinh.Hotenhs;
            Kqhockytonghop kq;
            using (QUANLYHOCSINHContext db = new QUANLYHOCSINHContext())
            {
                kq = db.Kqhockytonghops.Where(kq => kq.Manh == Manh && kq.Mahk == Mahk && hocsinh.Mahs == kq.Mahs).FirstOrDefault();
                this.DiemTB = Math.Round(kq?.DtbtatCaMonHocKy ?? 0.0,2);
                var diemDat = DataProvider.ins.context.Thamsos.Where(t => t.Id == "TS006").Select(t => t.Giatri).FirstOrDefault();
                this.Dat = (DiemTB >= double.Parse(diemDat)) ? "Đạt" : "Không đạt";
            }
        }
    }
}
