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
        private double DiemTB = -1;
        private string diemDisplay;
        public string Diemdisplay
        {
            get
            {
                return diemDisplay;
            }
            set
            {
               
                double diemdouble;
                if (double.TryParse(value, out diemdouble))
                {
                    diemdouble = Math.Round(diemdouble, 1);
                    diemdouble = Math.Round(diemdouble * 2, MidpointRounding.AwayFromZero) / 2;
                    if (diemdouble >= 0 && diemdouble <= 10)
                    {

                        DiemTB = diemdouble;
                        diemDisplay = diemdouble.ToString();
                        OnPropertyChanged();
                    }
                    else
                    {
                        return;
                    }

                }
                else
                {
                    diemDisplay = "";
                    // Conversion failed, handle the error
                }
            }
        }
        [ObservableProperty]
        private ObservableCollection<SubPoint> diemmonhocs = new ObservableCollection<SubPoint>();
        public PointType(Loaikiemtra loaikiemtra, TranscriptConfig config) 
        {
            
            this.loaikiemtra = loaikiemtra;
            this.config = config;
            var diemList = DataProvider.ins.context.Diemmonhocs.Where(x => x.Manh == config.namhoc.Manh && x.Mamh == config.subject.Mamh && x.Mahk == config.semeter.Mahk && x.Mahs == config.Hocsinh.Mahs && x.Malkt == loaikiemtra.Malkt).ToList();
            if(diemList != null || diemList.Count > 0)
            {
                DiemTB = 0;
                foreach (var diem in diemList)
                {
                    DiemTB += diem.Diem;
                    diemmonhocs.Add(new SubPoint(diem, this));
                }
                DiemTB = DiemTB / diemList.Count;
                Diemdisplay = DiemTB.ToString();
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
            RecountDiemTB();
        }
        public void saveSubPoint2()
        {
            if (Diemmonhocs.Count == 0 && DiemTB != -1 && DiemTB is double.NaN == false)
            {
                Diemmonhoc diem = new Diemmonhoc();
                diem.Manh = config.namhoc.Manh;
                diem.Mahk = config.semeter.Mahk;
                diem.Mamh = config.subject.Mamh;
                diem.Mahk = config.semeter.Mahk;
                diem.Malkt = loaikiemtra.Malkt;
                diem.Lankt = Diemmonhocs.Count;
                diem.Mahs = config.Student.Mahs;
                diem.Diem = DiemTB;
                Diemmonhocs.Add(new SubPoint(diem, this));
                DataProvider.ins.context.Diemmonhocs.Add(diem);
                DataProvider.ins.context.SaveChanges();
            }
            else if (Diemmonhocs.Count == 1 && DiemTB != -1 && DiemTB is double.NaN == false)
            {
                DiemTB = Diemmonhocs[0].Diem.Diem;
                Diemdisplay = DiemTB.ToString();
                DataProvider.ins.context.Update(Diemmonhocs[0].Diem);
                DataProvider.ins.context.SaveChanges();
            }
            else
            {
                DiemTB = 0;
                foreach (var diem in Diemmonhocs)
                {
                    DiemTB += diem.Diem.Diem;
                    DataProvider.ins.context.Update(diem.Diem);
                    DataProvider.ins.context.SaveChanges();
                }
                DiemTB = DiemTB / (Diemmonhocs.Count);
                Diemdisplay = DiemTB.ToString();
            }
        }
        public void saveSubPoint()
        {
            if (Diemmonhocs.Count == 0 && DiemTB != -1 && DiemTB is double.NaN == false)
            {
                    Diemmonhoc diem = new Diemmonhoc();
                    diem.Manh = config.namhoc.Manh;
                    diem.Mahk = config.semeter.Mahk;
                    diem.Mamh = config.subject.Mamh;
                    diem.Mahk = config.semeter.Mahk;
                    diem.Malkt = loaikiemtra.Malkt;
                    diem.Lankt = Diemmonhocs.Count;
                    diem.Mahs = config.Student.Mahs;
                    diem.Diem = DiemTB;
                    Diemmonhocs.Add(new SubPoint(diem, this));
                    DataProvider.ins.context.Diemmonhocs.Add(diem);
                    DataProvider.ins.context.SaveChanges();
            }
            else if(Diemmonhocs.Count == 1 && DiemTB != -1 && DiemTB is double.NaN == false)
            {
                Diemmonhocs[0].Diem.Diem = DiemTB;
                DataProvider.ins.context.Update(Diemmonhocs[0].Diem);
                DataProvider.ins.context.SaveChanges();
                Diemdisplay = DiemTB.ToString();
            }
            else
            {
                DiemTB = 0;
                foreach (var diem in Diemmonhocs)
                {
                    DiemTB += diem.Diem.Diem;
                    DataProvider.ins.context.Update(diem.Diem);
                    DataProvider.ins.context.SaveChanges();
                }
                DiemTB = DiemTB / (Diemmonhocs.Count);
                Diemdisplay = DiemTB.ToString();
            }
          
        }
        public void RecountDiemTB()
        {
            if(Diemmonhocs.Count == 0)
            {
                DiemTB = -1;
                Diemdisplay = "";
                return;
            }
            else
            {
                DiemTB = 0;
                foreach (var item in Diemmonhocs)
                {
                    DiemTB += item.Diem.Diem;

                }
                DiemTB = DiemTB / (Diemmonhocs.Count);
                Diemdisplay = DiemTB.ToString();
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
            RecountDiemTB();
        }
    }
}
