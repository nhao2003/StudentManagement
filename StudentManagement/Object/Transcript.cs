﻿using CommunityToolkit.Mvvm.ComponentModel;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Object
{
    public partial class TranscriptConfig : ObservableObject
    {
        [ObservableProperty]
        private Hocsinh student;
        public Hocsinh Hocsinh;
        public Hocky semeter;
        public Monhoc subject;
        public Namhoc namhoc;
        [ObservableProperty]
        private ObservableCollection<PointType> pointTypes = new ObservableCollection<PointType>();
        public TranscriptConfig(Hocsinh hocsinh, Hocky hocky, Monhoc monhoc, Namhoc namhoc)
        {
            this.Hocsinh = hocsinh;
            this.student = hocsinh;
            this.semeter = hocky;
            this.subject = monhoc;
            this.namhoc = namhoc;
            var loaidiem = DataProvider.ins.context.Loaikiemtras.ToList();
            foreach(var diem in loaidiem)
            {

                pointTypes.Add(new PointType(diem, this));
            }
            //foreach (var ld in loaidiem)
            //{
            //    Diemmonhoc diem = DataProvider.ins.context.Diemmonhocs.Where(x => x.Mahs == student.Mahs && x.Mamh == monhoc.Mamh && x.Manh == namhoc.Manh && x.Mahk == semeter.Mahk && x.Malkt == ld.Malkt).FirstOrDefault();
            //    kqhockymonh = DataProvider.ins.context.Kqhockymonhocs.Where(x=>x.Manh == namhoc.Manh && x.Mamh == monhoc.Mamh && x.Mahs== student.Mahs && x.Mahk == hocky.Mahk ).FirstOrDefault();
            //    if(kqhockymonh == null)
            //    {
            //        kqhockymonh = new Kqhockymonhoc();
            //        kqhockymonh.Manh = namhoc.Manh;
            //        kqhockymonh.Mahk = hocky.Mahk;
            //        kqhockymonh.DtbmonHocKy = 0;
            //        kqhockymonh.Mahs = hocsinh.Mahs;
            //        kqhockymonh.Mamh = monhoc.Mamh;
            //        DataProvider.ins.context.Kqhockymonhocs.Add(kqhockymonh);
            //        DataProvider.ins.context.SaveChanges();
            //    }
            //    if (diem == null)
            //    {
            //        diem = new Diemmonhoc();
            //        diem.Manh = namhoc.Manh;
            //        diem.Mahk = semeter.Mahk;
            //        diem.Malkt = ld.Malkt;
            //        diem.Mahs = student.Mahs;
            //        diem.Mamh = monhoc.Mamh;
            //        diem.MamhNavigation = monhoc;
            //        diem.MahkNavigation = hocky;
            //        diem.ManhNavigation = namhoc;
            //        diem.MahsNavigation = hocsinh;
            //        diem.MalktNavigation = ld;
            //        diemmonhocs.Add(diem);
                  
            //        DataProvider.ins.context.Diemmonhocs.Add(diem);
            //        DataProvider.ins.context.SaveChanges();
            //    }
            //    else
            //    {
            //        diemmonhocs.Add(diem);
            //    }
            //    DiemTB += diem.Diem * diem.MalktNavigation.Tile;
            //}
            //foreach (var diem in diemmonhocs) {
            //    diemDisplays.Add(new Point(diem));    
            //}
        }
        public void saveData()
        {
            foreach(var diem in pointTypes) {
                diem.saveSubPoint();
            }
        }
        public void saveData2()
        {
            foreach (var diem in pointTypes)
            {
                diem.saveSubPoint2();
            }

        }
    }
}
