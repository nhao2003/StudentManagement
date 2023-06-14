using CommunityToolkit.Mvvm.ComponentModel;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Object
{
    public partial class TermSummaryItem : ObservableObject
    {
        [ObservableProperty]
        private int stt;
        [ObservableProperty]
        private String tenLop;
        [ObservableProperty]
        private int siSo;
        [ObservableProperty]
        private int soLuongDat;
        [ObservableProperty]
        private String tiLe;

        private Lophocthucte lophocthucte;

        public Lophocthucte Lophtt
        {
            get { return lophocthucte; }
            set { lophocthucte = value; }
        }


        public TermSummaryItem(int Stt, String TenLop, int SiSo, int SoLuongDat, String TiLe)
        {
            this.Stt = Stt;
            this.TenLop = TenLop;
            this.SiSo = SiSo;
            this.SoLuongDat = SoLuongDat;
            this.TiLe = TiLe;
        }
        public TermSummaryItem(int Stt,Lophocthucte lhtt, string Manh, string Mahk, string Mamh)
        {
            this.Lophtt = lhtt;
            this.Stt = Stt;
            this.TenLop = lhtt.MalopNavigation.Tenlop;
            List<string> mahsList = Lophtt.Mahs.Select(x => x.Mahs).ToList();
            this.SiSo = Lophtt.Mahs.Count();
            var diemDat = DataProvider.ins.context.Thamsos.Where(t => t.Id == "TS006").Select(t => t.Giatri).FirstOrDefault();
            int soluongdat = DataProvider.ins.context.Kqhockymonhocs
                .Where(kq => mahsList.Contains(kq.Mahs)
                            && kq.DtbmonHocKy > double.Parse(diemDat)
                            && kq.Manh == Manh
                            && kq.Mahk == Mahk
                            && kq.Mamh == Mamh)
                .Count();
            this.SoLuongDat = soluongdat;
            if(SiSo != 0)
                this.TiLe = (soluongdat * 100 / SiSo).ToString("0.##") + "%";
        }
        public TermSummaryItem(int Stt, Lophocthucte lhtt, string Manh, string Mahk)
        {
            this.Lophtt = lhtt;
            this.Stt = Stt;
            this.TenLop = lhtt.MalopNavigation.Tenlop;
            List<string> mahsList = Lophtt.Mahs.Select(x => x.Mahs).ToList();
            this.SiSo = Lophtt.Mahs.Count();
            var diemDat = DataProvider.ins.context.Thamsos.Where(t => t.Id == "TS006").Select(t => t.Giatri).FirstOrDefault();

            int soluongdat = DataProvider.ins.context.Kqhockytonghops
                .Where(kq => mahsList.Contains(kq.Mahs)
                            && kq.DtbtatCaMonHocKy > double.Parse(diemDat)
                            && kq.Manh == Manh
                            && kq.Mahk == Mahk)
                .Count();
            this.SoLuongDat = soluongdat;
            if (SiSo != 0)
                this.TiLe = (soluongdat * 100 / SiSo).ToString("0.##") + "%";
        }
    }
}
