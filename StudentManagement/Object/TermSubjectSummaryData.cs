using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudentManagement.Object
{
    public partial class TermSubjectSummaryData : ObservableObject
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
        [ObservableProperty]
        private bool selected;

        partial void OnSelectedChanged(bool oldValue, bool newValue)
        {
            WeakReferenceMessenger.Default.Send(new PropertyChangedMessage<bool>(this,"Selected",oldValue,newValue));
        }

        private Lophocthucte lophocthucte;

        public Lophocthucte Lophtt
        {
            get { return lophocthucte; }
            set { lophocthucte = value; }
        }


        public TermSubjectSummaryData(int Stt, String TenLop, int SiSo, int SoLuongDat, String TiLe)
        {
            this.Stt = Stt;
            this.TenLop = TenLop;
            this.SiSo = SiSo;
            this.SoLuongDat = SoLuongDat;
            this.TiLe = TiLe;
        }
        public TermSubjectSummaryData(int Stt,Lophocthucte lhtt, string Manh, string Mahk, string Mamh)
        {
            this.Lophtt = lhtt;
            this.Stt = Stt;
            this.TenLop = lhtt.MalopNavigation.Tenlop;
            List<string> mahsList = Lophtt.Mahs.Select(x => x.Mahs).ToList();
            this.SiSo = Lophtt.Mahs.Count();
            int soluongdat = DataProvider.ins.context.Kqhockymonhocs
                .Where(kq => mahsList.Contains(kq.Mahs)
                            && kq.DtbmonHocKy > 5
                            && kq.Manh == Manh
                            && kq.Mahk == Mahk
                            && kq.Mamh == Mamh)
                .Count();
            this.SoLuongDat = soluongdat;
            this.TiLe = (soluongdat * 100 / SiSo).ToString("0.##") + "%";
        }
    }
}
