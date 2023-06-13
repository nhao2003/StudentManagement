using CommunityToolkit.Mvvm.ComponentModel;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StudentManagement.Object
{
    public partial class PointType : ObservableObject
    {
        private TranscriptConfig config;
        [ObservableProperty]
        private Loaikiemtra loaikiemtra;
        [ObservableProperty]
        private double diemTB;
        [ObservableProperty]
        private ObservableCollection<SubPoint> diemmonhocs = new ObservableCollection<SubPoint>();
        public PointType(Loaikiemtra loaikiemtra, TranscriptConfig config) 
        {
            this.loaikiemtra = loaikiemtra;
            this.config = config;
            var diemList = DataProvider.ins.context.Diemmonhocs.Where(x => x.Manh == config.namhoc.Manh && x.Mamh == config.subject.Mamh && x.Mahk == config.semeter.Mahk && x.Mahs == config.Hocsinh.Mahs && x.Malkt == loaikiemtra.Malkt).ToList();
            foreach (var diem in diemList)
            {
                diemmonhocs.Add(new SubPoint(diem, this));
            }
        }

        public void addSubPoint()
        {
            Diemmonhoc diem = new Diemmonhoc();
            diem.Manh = config.namhoc.Manh;
            diem.Mahk = config.semeter.Mahk;
            diem.Mamh = config.subject.Mamh;
            diem.Mahk = config.semeter.Mahk;
            diem.Malkt = loaikiemtra.Malkt;
            diem.Lankt = Diemmonhocs.Count;
            diem.Mahs = config.Student.Mahs;
            Diemmonhocs.Add(new SubPoint(diem, this));
            DataProvider.ins.context.Diemmonhocs.Add(diem);
            DataProvider.ins.context.SaveChanges();

        }
        public void saveSubPoint()
        {
            foreach (var diem in Diemmonhocs)
            {
                DataProvider.ins.context.Update(diem.Diem);
                DataProvider.ins.context.SaveChanges();
            }
        }
        public void DeleteDiem(SubPoint diem)
        {
            if (Diemmonhocs.Contains(diem))
            {
                Diemmonhocs.Remove(diem);
                DataProvider.ins.context.Diemmonhocs.Remove(diem.Diem);
                DataProvider.ins.context.SaveChanges();
            }

        }
    }
}
