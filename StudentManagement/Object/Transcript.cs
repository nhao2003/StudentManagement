using CommunityToolkit.Mvvm.ComponentModel;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Object
{
    public partial class TranscriptConfig : ObservableObject
    {
        [ObservableProperty]
        private Hocsinh student;
        private Hocky semeter;
        private Monhoc subject;
        private Namhoc namhoc;
        [ObservableProperty]
        private double diemTB;
        [ObservableProperty]
        private ObservableCollection<Diemmonhoc> diemmonhocs = new ObservableCollection<Diemmonhoc>();
        public TranscriptConfig(Hocsinh hocsinh, Hocky hocky, Monhoc monhoc)
        {
            this.student = hocsinh;
            this.semeter = hocky;
            this.subject = monhoc;
            this.namhoc = DataProvider.ins.context.Namhocs.First();
            var loaidiem = DataProvider.ins.context.Loaikiemtras.ToList();
            foreach (var ld in loaidiem)
            {
                Diemmonhoc diem = DataProvider.ins.context.Diemmonhocs.Where(x => x.Mahs == student.Mahs && x.Mamh == monhoc.Mamh && x.Manh == namhoc.Manh && x.Mahk == semeter.Mahk && x.Malkt == ld.Malkt).FirstOrDefault();
                if (diem == null)
                {
                    diem = new Diemmonhoc();
                    diem.Manh = namhoc.Manh;
                    diem.Mahk = semeter.Mahk;
                    diem.Malkt = ld.Malkt;
                    diem.Mahs = student.Mahs;
                    diem.Mamh = monhoc.Mamh;
                    diem.MamhNavigation = monhoc;
                    diem.MahkNavigation = hocky;
                    diem.ManhNavigation = namhoc;
                    diem.MahsNavigation = hocsinh;
                    diem.MalktNavigation = ld;
                    diemmonhocs.Add(diem);
                    DataProvider.ins.context.Diemmonhocs.Add(diem);
                    DataProvider.ins.context.SaveChanges();
                }
                else
                {
                    diemmonhocs.Add(diem);
                }
                DiemTB += diem.Diem * diem.MalktNavigation.Tile;
            }

        }
        public void saveData()
        {
            DiemTB = 0;
            foreach (var d in diemmonhocs)
            {
                DiemTB += d.Diem*d.MalktNavigation.Tile; 
            }
            DataProvider.ins.context.Diemmonhocs.UpdateRange(diemmonhocs);
            DataProvider.ins.context.SaveChanges();
        }
    }
}
